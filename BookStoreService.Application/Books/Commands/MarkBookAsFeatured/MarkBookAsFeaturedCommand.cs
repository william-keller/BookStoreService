using MediatR;

namespace BookStoreService.Application.Books.Commands.MarkBookAsFeatured
{
    public class MarkBookAsFeaturedCommand : IRequest<bool>
    {
        public Guid BookId { get; }

        public MarkBookAsFeaturedCommand(Guid bookId)
        {
            BookId = bookId;
        }
    }
}
