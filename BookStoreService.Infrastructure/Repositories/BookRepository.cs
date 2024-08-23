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

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);

            await _context.SaveChangesAsync();
        }

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            return await _context.Books.FirstOrDefaultAsync(book => book.Id == id);
        }
    }
}
