using Bookstore.Application.Interfaces.Book;
using Domain.DTO.Requests;
using Domain.DTO.Responses;
using Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace bookstore.api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    public class BookController : ControllerBase
    {
        private readonly IBookAppService _bookAppService;
        public BookController(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        /// <summary>
        /// Buscar todos os livros cadastrados
        /// </summary>
        [HttpGet]
        public IEnumerable<BookResponseDTO> GetAllBooks()
        {
            return _bookAppService.GetAll();
        }

        /// <summary>
        /// Buscar um livro em específico pelo Id
        /// <param name="id">Id do Livro</param>
        /// </summary>
        [HttpGet("{id}")]
        public BookResponseDTO GetById(int id)
        {
            return _bookAppService.GetById(id);
        }

        /// <summary>
        /// Ordena a lista de Livros baseado em no DTO passado
        /// <param name="ordination">ASC = 1 ou DESC = 2</param>
        /// </summary>
        [HttpGet]
        public IEnumerable<BookResponseDTO> SortByPrice(EOrdination ordination)
        {
            return _bookAppService.SortByPrice(ordination);
        }

        /// <summary>
        /// Busca uma lista de livros baseado nas especificações passadas pela request
        /// <param name="specifications">Propriedades da especificação para busca</param>
        /// </summary>
        [HttpGet]
        public IEnumerable<BookResponseDTO> GetBySpecifications([FromQuery] BookRequestSpecificationsDTO specifications)
        {
            return _bookAppService.GetBySpecifications(specifications);
        }

        /// <summary>
        /// Busca uma lista de livros baseado na única específicação genérica passada pela request
        /// <param name="genericSpecification">Única especificação genérica</param>
        /// </summary>
        [HttpGet]
        public IEnumerable<BookResponseDTO> GetBySpecification(string genericSpecification)
        {
            return _bookAppService.GetBySpecification(genericSpecification);
        }
    }
}
