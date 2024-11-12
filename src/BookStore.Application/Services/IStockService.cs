﻿using BookStore.Application.DTOs;

namespace BookStore.Application.Services
{
    public interface IStockService
    {
        Task<bool> CreateImportOrder(StockImportOrderDto request);
        Task<(IEnumerable<StockImportOrderDto> stockImportOrders, int FilteredCount, int TotalCount)> FindAsync(string search, int page, int pageSize);
    }
}
