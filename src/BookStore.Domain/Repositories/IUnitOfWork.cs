﻿namespace BookStore.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Books { get; }
        ICategoryRepository Categories { get; }
        IUserRepository Users { get; }
        ICartRepository Carts { get; }
        int Complete();
        Task<int> CompleteAsync();
    }
}
