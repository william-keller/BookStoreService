using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreService.Domain.Entities;
using BookStoreService.Domain.Interfaces.Repositories;
using MediatR;

namespace BookStoreService.Application.Books.Commands.CreateBook
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        public CreateBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book(request.Title, request.Author, request.Price);

            await _bookRepository.InsertAsync(book, cancellationToken);
        }
    }
}
