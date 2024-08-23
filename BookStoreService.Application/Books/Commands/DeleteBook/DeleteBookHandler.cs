using BookStoreService.Domain.Interfaces.Repositories;
using MediatR;

namespace BookStoreService.Application.Books.Commands.DeleteBook
{
    public sealed class DeleteBookHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await _bookRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
