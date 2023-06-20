using Common;
using Domain.DTO.Responses;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Interfaces.Shipping;
using Service.Services.Shipping.Strategy;

namespace bookstore.api.Controllers
{
    [Route("[controller]/[action]")]
    public class ShippingController : ControllerBase
    {
        private readonly IShippingService _shippingService;
        private readonly IBookService _bookService;

        public ShippingController(IShippingService shippingService, IBookService bookService)
        {
            _shippingService = shippingService;
            _bookService = bookService;
        }

        /// <summary>
        /// Calcula o frete normalmente (20%) sobre o valor do livro
        /// <param name="idBook">Id do livro a ser calculado o frete</param>
        /// </summary>
        [HttpGet("{idBook}")]
        public ResumePriceShippingDTO CalculateNormalShipping(int idBook)
        {
            var book = _bookService.GetById(idBook);

            if (book == null)
                throw new CustomException("Livro não encontrado", System.Net.HttpStatusCode.NotFound, "bookstore.api.Controllers", "CalculateNormalShipping");

            var shippingStrategy = new ShippingNormalStrategy();
            var priceShipping = _shippingService.CalculateShipping(book.Price, shippingStrategy);
            var bookUpdated = _bookService.SetShippingPriceOnBook(book, priceShipping);
            return bookUpdated;
        }

        /// <summary>
        /// Calcula o frete para frete rápido (40%) sobre o valor do livro
        /// <param name="idBook">Id do livro a ser calculado o frete</param>
        /// </summary>
        [HttpGet("{idBook}")]
        public ResumePriceShippingDTO CalculateExpressShipping(int idBook)
        {
            var book = _bookService.GetById(idBook);

            if (book == null)
                throw new CustomException("Livro não encontrado", System.Net.HttpStatusCode.NotFound, "bookstore.api.Controllers", "CalculateExpressShipping");

            var shippingStrategy = new ShippingExpressStrategy();
            var priceShipping = _shippingService.CalculateShipping(book.Price, shippingStrategy);
            var bookUpdated = _bookService.SetShippingPriceOnBook(book, priceShipping);
            return bookUpdated;
        }
    }
}
