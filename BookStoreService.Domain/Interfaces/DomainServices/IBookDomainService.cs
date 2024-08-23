using BookStoreService.Domain.Entities;

namespace BookStoreService.Domain.Interfaces.DomainServices
{
    public interface IBookDomainService
    {
        Task<bool> MarkBookAsFeaturedAsync(Book book, CancellationToken cancellationToken);
    }
}
