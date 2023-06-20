using Domain.DTO.Request;
using Domain.DTO.Requests;
using Domain.DTO.Responses;
using Domain.Enum;
using Infra.Interfaces;
using Service.Interfaces;
using System.Collections.Generic;

namespace Service.Services
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
            return _bookRepository.GetById(id);
        }

        public IEnumerable<BookResponseDTO> GetBySpecification(string request)
        {
            return _bookRepository.GetBySpecification(request);
        }

        public IEnumerable<BookResponseDTO> GetBySpecifications(BookRequestSpecificationsDTO request)
        {
            return _bookRepository.GetBySpecifications(request);
        }

        public IEnumerable<BookResponseDTO> SortByPrice(EOrdination request)
        {
            return _bookRepository.SortByPrice(request);
        }
    }
}
