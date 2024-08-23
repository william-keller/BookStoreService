using BookStoreService.Domain.Entities;
using BookStoreService.Domain.Interfaces.Repositories;
using BookStoreService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStoreService.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _context;

        public BookRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context
                .Books
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(Book book, CancellationToken cancellationToken)
        {
            _context
                .Books
                .Update(book);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context
                .Books
                .FirstOrDefaultAsync(book => book.Id == id, cancellationToken);
        }

        public async Task InsertAsync(Book book, CancellationToken cancellationToken)
        {
            await _context
                .AddAsync(book, cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _context
                .Books
                .Where(book => book.Id == id)
                .ExecuteDeleteAsync(cancellationToken);
        }
    }
}
