using BookStoreService.Domain.Interfaces.DomainServices;
using BookStoreService.Domain.Interfaces.Repositories;
using MediatR;

namespace BookStoreService.Application.Books.Commands.MarkBookAsFeatured
{
    public class MarkBookAsFeaturedHandler : IRequestHandler<MarkBookAsFeaturedCommand, bool>
    {
        private readonly IBookDomainService _bookService;
        private readonly IBookRepository _bookRepository;

        public MarkBookAsFeaturedHandler(IBookDomainService bookService)
        {
            _bookService = bookService;
        }

        public async Task<bool> Handle(MarkBookAsFeaturedCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.BookId);
            if (book == null)
                return false;

            return await _bookService.MarkBookAsFeaturedAsync(book);
        }
    }
}
