using MediatR;

namespace BookStoreService.Application.Books.Commands.CreateBook
{
    public record CreateBookCommand(string Title, string Author, decimal Price) : IRequest;
}
