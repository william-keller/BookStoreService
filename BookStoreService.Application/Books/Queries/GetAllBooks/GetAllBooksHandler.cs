using BookStoreService.Domain.Entities;
using BookStoreService.Domain.Interfaces.Repositories;
using MediatR;

namespace BookStoreService.Application.Books.Queries.GetAllBooks
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<Book>>
    {
        private readonly IBookRepository _bookRepository;

        public GetAllBooksHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetAllAsync(cancellationToken);
        }
    }
}
