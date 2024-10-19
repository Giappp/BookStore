﻿using BookStore.Application.Services;
using BookStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Client.Controllers
{
    public class ItemController : Controller
    {
        private readonly IService<Book> _bookService;

        public ItemController(IService<Book> bookService)
        {
            _bookService = bookService;
        }
        public async Task<IActionResult> GetBookDetail(long bookId)
        {
            Book book = await _bookService.GetByIdAsync(bookId);

            /*if (book == null)
            {
                return NotFound("Book not found.");
            }*/

            return View(book);
        }
    }
}