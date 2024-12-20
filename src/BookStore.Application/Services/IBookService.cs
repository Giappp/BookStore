﻿using BookStore.Application.DTOs;
using BookStore.Domain.Entities;

namespace BookStore.Application.Services
{
    public interface IBookService
    {
        Task<Book?> GetByIdAsync(long id);
        Task<IEnumerable<Book>> GetAllAsync();
        Task<IEnumerable<HomePageBookDto>> GetBooksForHomepageAsync();
        (IEnumerable<BookDto> Books, int TotalCount) Find(string search, int page, int pageSize);
        IEnumerable<CategoryDto> GetAllBookCategories();
        int getTotal();
        Task<CartSummaryDto?> HandleGetCartPageAsync();
        Task AddBookToCartAsync(long bookId, long quantity);
        Task HandleRemoveCartDetail(long cartDetailId);
        Task HandleUpdateCartBeforeCheckout(List<CartDetailDto> cartDetailDtos);
        Task<CheckoutDto?> GetUserCheckoutDataAsync();
        Task HandleAddOrderAndOrderDetail(string receivedName, string receivedPhone,
            string receivedAddress, string orderNotes);
        Task<int> CreateNewBookAsync(BookDto bookdto);
        Task<bool> DeleteBookAsync(long id);
        Task<bool> UpdateBookAsync(CreateOrUpdateBookRequest bookdto);
        Task<List<BookDto>> GetRelatedBooksAsync(Book book);
        Task<List<BookDto>> GetTopDiscountedBooksAsync();
        (IEnumerable<BookDto> Books, int TotalCount) Find(BookFilterDto filter, int pageSize);
    }
}
