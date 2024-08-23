using BookStoreService.Api.Models;
using BookStoreService.Application.Books.Queries.GetAllBooks;
using BookStoreService.Domain.Interfaces.Repositories;
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
        private readonly IBookRepository _bookRepository;

        public BooksController(ISender sender, IMemoryCache memoryCache, IBookRepository bookRepository)
        {
            _sender = sender;
            _memoryCache = memoryCache;
            _bookRepository = bookRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllBooks(CancellationToken cancellationToken)
        {
            const string cacheKey = "GetAllBooks";
            if (!_memoryCache.TryGetValue(cacheKey, out var books))
            {
                books = await _sender.Send(new GetAllBooksQuery(), cancellationToken);
                var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(1));
                _memoryCache.Set(cacheKey, books, cacheOptions);
            }

            var links = new List<Link>
            {
                new(Url.Action("GetAllBooks", "Books"), "self", "GET")
            };

            return Ok(new { data = books, links });
        }
    }
}
