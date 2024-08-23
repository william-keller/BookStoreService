using BookStoreService.Application.Books.Queries.GetAllBooks;
using BookStoreService.Domain.Entities;
using BookStoreService.Domain.Interfaces.Repositories;
using Moq;

namespace BookStoreService.Tests.Application
{
    public class GetAllBooksHandlerTests
    {
        private readonly Mock<IBookRepository> _bookRepositoryMock;
        private readonly GetAllBooksHandler _getAllBooksHandler;

        public GetAllBooksHandlerTests()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();
            _getAllBooksHandler = new GetAllBooksHandler(_bookRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ReturnsAllBooks()
        {
            // Arrange
            var books = new List<Book> { new() { Id = Guid.NewGuid(), Title = "Test Book" } };
            _bookRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(books);

            // Act
            var result = await _getAllBooksHandler.Handle(new GetAllBooksQuery(), CancellationToken.None);

            // Assert
            Assert.Equal(books, result);
        }
    }
}
