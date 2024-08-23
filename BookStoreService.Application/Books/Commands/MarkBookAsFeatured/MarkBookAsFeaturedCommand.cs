using MediatR;

namespace BookStoreService.Application.Books.Commands.MarkBookAsFeatured
{
    public record MarkBookAsFeaturedCommand : IRequest<bool>
    {
        public Guid BookId { get; }

        public MarkBookAsFeaturedCommand(Guid bookId)
        {
            BookId = bookId;
        }
    }
}
