using BookStoreService.Domain.Entities;
using BookStoreService.Domain.Interfaces.DomainServices;
using BookStoreService.Domain.Interfaces.Repositories;

namespace BookStoreService.Domain.DomainServices
{
    public class BookDomainService : IBookDomainService
    {
        private readonly IBookRepository _bookRepository;

        public BookDomainService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<bool> MarkBookAsFeaturedAsync(Book book, CancellationToken cancellationToken)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));

            if (book.Sales > 1000 || book.Rating > 4.5)
            {
                book.IsFeatured = true;
                await _bookRepository.UpdateAsync(book, cancellationToken);
                return true;
            }

            return false;
        }
    }
}
