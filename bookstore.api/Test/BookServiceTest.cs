using Moq;
using Common;
using Domain.DTO.Responses;
using Infra.Interfaces;
using Service.Services.Book;
using Domain.DTO.Requests;
using Domain.Enum;

namespace bookstore.api.Tests
{
    public class BookServiceTests
    {
        [Fact]
        public void GetAll_Returns_AllBooks()
        {
            // Arrange
            var expectedBooks = new List<BookResponseDTO>
            {
                new BookResponseDTO { 
                    Id = 1, Name = "Book 1", Price = 10m, Specifications = 
                    new Domain.Entities.Specifications {
                        Author = "Teste",
                        Genres = "Genero",
                        Illustrator = "Ilustrador",
                        OriginallyPublished = "1",
                        PageCount = 99
                    } 
                },
                new BookResponseDTO {
                    Id = 2, Name = "Book 2", Price = 12m, Specifications = 
                    new Domain.Entities.Specifications {
                        Author = "Teste 2",
                        Genres = "Genero 2",
                        Illustrator = "Ilustrador 2",
                        OriginallyPublished = "2",
                        PageCount = 100
                    },
                }
                
            };

            var bookRepositoryMock = new Mock<IBookRepository>();
            bookRepositoryMock.Setup(x => x.GetAll()).Returns(expectedBooks);

            var bookService = new BookService(bookRepositoryMock.Object);

            // Act
            var result = bookService.GetAll();

            // Assert
            Assert.Equal(expectedBooks, result);
        }

        [Fact]
        public void GetById_Returns_BookWithMatchingId()
        {
            // Arrange
            int bookId = 1;
            var expectedBook = new BookResponseDTO
            {
                Id = bookId,
                Name = "Book 1",
                Price = 10m,
                Specifications =
                    new Domain.Entities.Specifications
                    {
                        Author = "Teste",
                        Genres = "Genero",
                        Illustrator = "Ilustrador",
                        OriginallyPublished = "1",
                        PageCount = 99
                    }
            };

            var bookRepositoryMock = new Mock<IBookRepository>();
            bookRepositoryMock.Setup(x => x.GetById(bookId)).Returns(expectedBook);

            var bookService = new BookService(bookRepositoryMock.Object);

            // Act
            var result = bookService.GetById(bookId);

            // Assert
            Assert.Equal(expectedBook, result);
        }

        [Fact]
        public void GetBySpecification_ThrowsCustomException_WhenSpecificationIsNullOrEmpty()
        {
            // Arrange
            var bookService = new BookService(Mock.Of<IBookRepository>());

            // Act & Assert
            Assert.Throws<CustomException>(() => bookService.GetBySpecification(null));
            Assert.Throws<CustomException>(() => bookService.GetBySpecification(string.Empty));
        }

        [Fact]
        public void GetBySpecifications_ThrowsCustomException_WhenSpecificationsAreNull()
        {
            // Arrange
            var specifications = new BookRequestSpecificationsDTO();
            var bookService = new BookService(Mock.Of<IBookRepository>());

            // Act & Assert
            Assert.Throws<CustomException>(() => bookService.GetBySpecifications(specifications));
        }

        [Fact]
        public void SetShippingPriceOnBook_ThrowsCustomException_WhenBookIsNull()
        {
            // Arrange
            var book = (BookResponseDTO)null;
            var priceShipping = 10.0m;
            var bookService = new BookService(Mock.Of<IBookRepository>());

            // Act & Assert
            Assert.Throws<CustomException>(() => bookService.SetShippingPriceOnBook(book, priceShipping));
        }

        [Fact]
        public void SortByPrice_ThrowsCustomException_WhenOrdinationIsIncorrect()
        {
            // Arrange
            var ordination = 3;
            var bookService = new BookService(Mock.Of<IBookRepository>());

            // Act & Assert
            Assert.Throws<CustomException>(() => bookService.SortByPrice((EOrdination)ordination));
        }
    }
}