﻿using BookStore.Application.DTOs;
using BookStore.Domain.Entities;
using BookStore.Domain.Repositories;
using Microsoft.AspNetCore.Http;

namespace BookStore.Application.Services.Impl
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        public BookService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Book?> GetByIdAsync(long id)
        {
            return await _unitOfWork.Books.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _unitOfWork.Books.GetAllAsync();

        }
        public int getTotal()
        {
            return _unitOfWork.Books.count();
        }

        public IEnumerable<BookDto> findAll()
        {
            var books = _unitOfWork.Books.GetAllAsync().Result;
            var bookList = books.Select(book => new BookDto
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                DetailDesc = book.DetailDesc,
                Factory = book.Factory,
                Image = book.Image,
                Price = book.Price,
                Quantity = book.Quantity,
                ShortDesc = book.ShortDesc,
                Sold = book.Sold,
                Discount = book.Discount,
                CategoryIds = book.Categories.Select(c => c.Id).ToList()
            });
            return bookList;
        }

        public (IEnumerable<BookDto> Books, int TotalCount) Find(string search, int page, int pageSize)
        {
            if (page < 1) page = 1;
            IQueryable<Book> booksQuery = _unitOfWork.Books.GetAll();
            // Apply filtering if search term is provided
            if (!string.IsNullOrWhiteSpace(search))
            {
                booksQuery = booksQuery.Where(book => book.Name.Contains(search) || book.Author.Contains(search));
            }

            // Get the total count of books that match the criteria (for pagination)
            var totalCount = booksQuery.Count();

            // Apply paging
            var books = booksQuery.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // Map to BookDto
            var bookDtos = books.Select(book => new BookDto
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                DetailDesc = book.DetailDesc,
                Factory = book.Factory,
                Image = book.Image,
                Price = book.Price,
                Quantity = book.Quantity,
                ShortDesc = book.ShortDesc,
                Sold = book.Sold,
            });

            return (bookDtos, totalCount);
        }

        public IEnumerable<Category> GetAllBookCategories()
        {
            return _unitOfWork.Categories.GetAll();
        }

        public async Task<CartSummaryDto?> HandleGetCartPageAsync()
        {
            User currentUser = _userService.GetCurrentUser();
            if (currentUser != null)
            {
                Cart? cart = await _unitOfWork.Carts.FetchByUserIdAsync(currentUser.Id);
                List<CartDetail> cartDetails = cart == null ? new List<CartDetail>() : cart.CartDetails.ToList();

                double totalPrice = 0;
                double totalDiscount = 0;

                foreach (var cartDetail in cartDetails)
                {
                    totalPrice += (double)(cartDetail.Price * cartDetail.Quantity);
                    var discount = await _unitOfWork.Books.FetchBookDiscountByIdAsync(cartDetail.BookId) / 100;
                    totalDiscount += (double)(cartDetail.Price * discount * cartDetail.Quantity);
                }

                return new CartSummaryDto(totalPrice, totalDiscount, cartDetails);
            }

            return null;
        }
        public async Task AddBookToCartAsync(long bookId, long quantity)
        {
            User user = _userService.GetCurrentUser();
            if (user != null)
            {
                Cart? cart = await _unitOfWork.Carts.FetchByUserIdAsync(user.Id);
                if (cart == null)
                {
                    cart = new Cart { UserId = user.Id, Sum = 0 };
                    await _unitOfWork.Carts.AddAsync(cart);
                    await _unitOfWork.CompleteAsync();
                }

                Book? book = await _unitOfWork.Books.GetByIdAsync(bookId);
                if (book != null)
                {
                    var oldCartDetail = await _unitOfWork.CartDetails.GetCartDetailByCartAndBookAsync(cart.Id, bookId);

                    if (oldCartDetail != null)
                    {
                        oldCartDetail.Quantity += quantity;
                        _unitOfWork.CartDetails.Update(oldCartDetail);
                    }
                    else
                    {
                        var newCartDetail = new CartDetail
                        {
                            Cart = cart,
                            Book = book,
                            Price = book.Price,
                            Quantity = quantity
                        };
                        await _unitOfWork.CartDetails.AddAsync(newCartDetail);
                        if (_httpContextAccessor.HttpContext != null)
                        {
                            int sum = cart.Sum + 1;
                            _httpContextAccessor.HttpContext.Session.SetInt32("sum-cart-detail", sum);
                            cart.Sum = sum;
                            _unitOfWork.Carts.Update(cart);
                        }
                    }
                }
                await _unitOfWork.CompleteAsync();
            }
        }
        public async Task HandleRemoveCartDetail(long cartDetailId)
        {
            var cartDetail = await _unitOfWork.CartDetails.GetByIdAsync(cartDetailId)
                     ?? throw new InvalidOperationException("CartDetail not exit.");

            var currentCart = await _unitOfWork.Carts.GetByIdAsync(cartDetail.CartId)
                             ?? throw new InvalidOperationException("Cart not exit.");

            _unitOfWork.CartDetails.Delete(cartDetail);

            if (currentCart.Sum > 1)
            {
                currentCart.Sum--;
                _httpContextAccessor.HttpContext.Session.SetInt32("sum-cart-detail", currentCart.Sum);
                _unitOfWork.Carts.Update(currentCart);
            }
            else
            {
                _unitOfWork.Carts.Delete(currentCart);
                _httpContextAccessor.HttpContext.Session.SetInt32("sum-cart-detail", 0);
            }

            await _unitOfWork.CompleteAsync();
        }
    }
}
