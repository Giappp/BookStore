﻿using BookStore.Application.Services;
using BookStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IService<Book> _service;

        public HomeController(ILogger<HomeController> logger, IService<Book> service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var books = await _service.GetAllAsync();
            return View(books);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
