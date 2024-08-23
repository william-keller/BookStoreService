using MediatR;

namespace BookStoreService.Application.Books.Commands.DeleteBook
{
    public sealed record DeleteBookCommand(Guid Id) : IRequest;
}
