﻿using BookStore.Domain.Entities;
using System.Linq.Expressions;

namespace BookStore.Domain.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        public int count();
        public IEnumerable<Book> Find(Expression<Func<Book, bool>> predicate, int pageNumber, int pageSize);
        Task<decimal?> FetchBookDiscountByIdAsync(long bookId);
        Task<List<long>> GetNewArrivalBookIdsAsync();
        Task<List<long>> GetMostBuyBookIdsAsync();
        Task<List<Book>> GetRelatedBooksAsync(Book book);
        Task<List<Book>> GetTopDiscountedBooksAsync(int count = 10);
    }
}
