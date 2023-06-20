using Domain.DTO.Request;
using Domain.DTO.Requests;
using Domain.DTO.Responses;
using Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Collections.Generic;

namespace bookstore.api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Buscar todos os livros cadastrados
        /// </summary>
        [HttpGet]
        public IEnumerable<BookResponseDTO> GetAllBooks()
        {
            return _bookService.GetAll();
        }

        /// <summary>
        /// Buscar um livro em específico pelo Id
        /// <param name="id">Id do Livro</param>
        /// </summary>
        [HttpGet("{id}")]
        public BookResponseDTO GetById([FromQuery] int id)
        {
            return _bookService.GetById(id);
        }

        /// <summary>
        /// Ordena a lista de Livros baseado em no DTO passado
        /// <param name="request">ASC ou DESC</param>
        /// </summary>
        [HttpGet("{request}")]
        public IEnumerable<BookResponseDTO> SortByPrice([FromQuery] EOrdination request)
        {
            return _bookService.SortByPrice(request);
        }

        /// <summary>
        /// Busca uma lista de livros baseado nas especificações passadas pela request
        /// <param name="request">Propriedades da especificação para busca</param>
        /// </summary>
        [HttpGet]
        public IEnumerable<BookResponseDTO> GetBySpecifications([FromQuery] BookRequestSpecificationsDTO request)
        {
            return _bookService.GetBySpecifications(request);
        }

        /// <summary>
        /// Busca uma lista de livros baseado na única específicação genérica passada pela request
        /// <param name="request">Única especificação genérica</param>
        /// </summary>
        [HttpGet("{request}")]
        public IEnumerable<BookResponseDTO> GetBySpecification(string request)
        {
            return _bookService.GetBySpecification(request);
        }
    }
}
