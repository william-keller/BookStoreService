using BookStoreService.Api.Models;
using BookStoreService.Api.Models.Books;
using BookStoreService.Application.Books.Commands.CreateBook;
using BookStoreService.Application.Books.Commands.DeleteBook;
using BookStoreService.Application.Books.Queries.GetAllBooks;
using BookStoreService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace BookStoreService.Api.Controllers.v1
{
    //[Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMemoryCache _memoryCache;

        public BooksController(ISender sender, IMemoryCache memoryCache)
        {
            _sender = sender;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllBooks(CancellationToken cancellationToken)
        {
            const string cacheKey = "GetAllBooks";
            if (!_memoryCache.TryGetValue(cacheKey, out List<Book>? cachedBooks))
            {
                var books = await _sender.Send(new GetAllBooksQuery(), cancellationToken);
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(5))
                    .SetSize(1024 * 1024); // 1MB

                _memoryCache.Set(cacheKey, books.ToList(), cacheOptions);
                cachedBooks = _memoryCache.Get<List<Book>>(cacheKey);
            }

            var links = new List<Link>
            {
                new(Url.Action("GetAllBooks", "Books"), "self", "GET")
            };

            return Ok(new GetAllBooksResponse(cachedBooks, links));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Consumes("application/json")]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookRequest createBookRequest, CancellationToken cancellationToken)
        {
            await _sender.Send(new CreateBookCommand(createBookRequest.Title, createBookRequest.Author, createBookRequest.Price), cancellationToken);

            return Created();
        }

        [HttpDelete("{bookId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteBook(Guid bookId)
        {
            await _sender.Send(new DeleteBookCommand(bookId));

            return Ok();
        }
    }
}
