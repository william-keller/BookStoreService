using BookStoreService.Domain.Entities;

namespace BookStoreService.Domain.Interfaces.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task UpdateAsync(Book book, CancellationToken cancellationToken);
        Task<Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task InsertAsync(Book book, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
