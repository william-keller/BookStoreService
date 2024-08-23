using BookStoreService.Domain.Entities;

namespace BookStoreService.Api.Models.Books
{
    public class GetAllBooksResponse
    {
        public GetAllBooksResponse(List<Book>? books, List<Link> links)
        {
            Books = books;
            Links = links;
        }

        public List<Book>? Books { get; set; }
        public List<Link> Links { get; set; }
    }
}
