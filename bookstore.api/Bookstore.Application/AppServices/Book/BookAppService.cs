using Bookstore.Application.Interfaces.Book;
using Domain.DTO.Requests;
using Domain.DTO.Responses;
using Domain.Enum;
using Service.Interfaces;
using System.Collections.Generic;

namespace Bookstore.Application.AppServices.Book
{
    public class BookAppService : IBookAppService
    {

        private readonly IBookService _bookService;

        public BookAppService(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IEnumerable<BookResponseDTO> GetAll()
        {
            return _bookService.GetAll();
        }

        public BookResponseDTO GetById(int id)
        {
            return _bookService.GetById(id);
        }

        public IEnumerable<BookResponseDTO> GetBySpecification(string specification)
        {
            return _bookService.GetBySpecification(specification);
        }

        public IEnumerable<BookResponseDTO> GetBySpecifications(BookRequestSpecificationsDTO specifications)
        {
            return _bookService.GetBySpecifications(specifications);
        }

        public ResumePriceShippingDTO SetShippingPriceOnBook(BookResponseDTO book, decimal priceShipping)
        {
            return _bookService.SetShippingPriceOnBook(book, priceShipping);
        }

        public IEnumerable<BookResponseDTO> SortByPrice(EOrdination ordination)
        {
            return _bookService.SortByPrice(ordination);
        }
    }
}
