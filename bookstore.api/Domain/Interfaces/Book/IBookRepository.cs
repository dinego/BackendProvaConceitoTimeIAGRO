using Domain.DTO.Request;
using Domain.DTO.Requests;
using Domain.DTO.Responses;
using Domain.Enum;
using System.Collections.Generic;

namespace Infra.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<BookResponseDTO> GetAll();
        BookResponseDTO GetById(int id);
        IEnumerable<BookResponseDTO> GetBySpecifications(BookRequestSpecificationsDTO request);
        IEnumerable<BookResponseDTO> GetBySpecification(string request);
        IEnumerable<BookResponseDTO> SortByPrice(EOrdination request);
    }
}
