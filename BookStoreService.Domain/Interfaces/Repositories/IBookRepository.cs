using BookStoreService.Domain.Entities;

namespace BookStoreService.Domain.Interfaces.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task UpdateAsync(Book book);
        Task<Book?> GetByIdAsync(Guid id);
    }
}
