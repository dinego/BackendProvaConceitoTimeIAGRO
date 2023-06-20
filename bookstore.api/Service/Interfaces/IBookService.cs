using Domain.DTO.Request;
using Domain.DTO.Requests;
using Domain.DTO.Responses;
using Domain.Enum;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookResponseDTO> GetAll();
        BookResponseDTO GetById(int id);
        IEnumerable<BookResponseDTO> GetBySpecification(string request);
        IEnumerable<BookResponseDTO> GetBySpecifications(BookRequestSpecificationsDTO request);
        IEnumerable<BookResponseDTO> SortByPrice(EOrdination request);
    }
}
