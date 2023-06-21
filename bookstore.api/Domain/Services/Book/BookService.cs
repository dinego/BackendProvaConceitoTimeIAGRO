using Common;
using Domain.DTO.Requests;
using Domain.DTO.Responses;
using Domain.Enum;
using Infra.Interfaces;
using Service.Interfaces;
using System.Collections.Generic;

namespace Service.Services.Book
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<BookResponseDTO> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public BookResponseDTO GetById(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
                throw new CustomException("Livro não encontrado", System.Net.HttpStatusCode.NotFound, "Service.Services.Book", "GetBySpecification");

            return book;
        }

        public IEnumerable<BookResponseDTO> GetBySpecification(string specification)
        {
            if (string.IsNullOrEmpty(specification))
                throw new CustomException("Especificação não encontrada", System.Net.HttpStatusCode.NotFound, "Service.Services.Book", "GetBySpecification");

            return _bookRepository.GetBySpecification(specification);
        }

        public IEnumerable<BookResponseDTO> GetBySpecifications(BookRequestSpecificationsDTO specifications)
        {
            if (specifications.Illustrator == null &&
                specifications.OriginallyPublished == null &&
                specifications.PageCount == null &&
                specifications.Genres == null &&
                specifications.Author == null)
                throw new CustomException("Especificação não encontrada", System.Net.HttpStatusCode.NotFound, "Service.Services.Book", "GetBySpecifications");

            return _bookRepository.GetBySpecifications(specifications);
        }

        public ResumePriceShippingDTO SetShippingPriceOnBook(BookResponseDTO book, decimal priceShipping)
        {
            if (book == null)
                throw new CustomException("Livro não identificado", System.Net.HttpStatusCode.NotFound, "Service.Services.Book", "GetBySpecifications");

            book.Price += priceShipping;

            return new ResumePriceShippingDTO
            {
                Book = book,
                PriceShipping = priceShipping
            };
        }

        public IEnumerable<BookResponseDTO> SortByPrice(EOrdination ordination)
        {
            if (ordination != EOrdination.DESC && ordination != EOrdination.ASC)
                throw new CustomException("Ordenação incorreta", System.Net.HttpStatusCode.NotFound, "bookstore.api.Controllers", "SortByPrice");

            return _bookRepository.SortByPrice(ordination);
        }
    }
}
