using BookStoreService.Domain.Entities;
using MediatR;

namespace BookStoreService.Application.Books.Queries.GetAllBooks
{
    public sealed record GetAllBooksQuery : IRequest<IEnumerable<Book>>;
}
