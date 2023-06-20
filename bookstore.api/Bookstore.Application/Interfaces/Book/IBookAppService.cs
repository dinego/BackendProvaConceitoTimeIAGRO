﻿using Domain.DTO.Requests;
using Domain.DTO.Responses;
using Domain.Enum;
using System.Collections.Generic;

namespace Bookstore.Application.Interfaces.Book
{
    public interface IBookAppService
    {
        IEnumerable<BookResponseDTO> GetAll();
        BookResponseDTO GetById(int id);
        IEnumerable<BookResponseDTO> GetBySpecification(string specification);
        IEnumerable<BookResponseDTO> GetBySpecifications(BookRequestSpecificationsDTO specifications);
        ResumePriceShippingDTO SetShippingPriceOnBook(BookResponseDTO book, decimal priceShipping);
        IEnumerable<BookResponseDTO> SortByPrice(EOrdination ordination);
    }
}
