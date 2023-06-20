using Moq;
using Service.Interfaces.Shipping.Strategy;
using Service.Services.Shipping;

namespace bookstore.api.Tests
{
    public class ShippingServiceTests
    {
        [Fact]
        public void CalculateShipping_Returns_CorrectNormalShippingPrice()
        {
            // Arrange
            var price = 100.0m;
            var strategyMock = new Mock<IShippingStrategy>();
            strategyMock.Setup(x => x.CalculateShipping(price)).Returns(20.0m);
            var shippingService = new ShippingService();

            // Act
            var result = shippingService.CalculateShipping(price, strategyMock.Object);

            // Assert
            Assert.Equal(20.0m, result);
        }

        [Fact]
        public void CalculateShipping_Returns_CorrectExpressShippingPrice()
        {
            // Arrange
            var price = 100.0m;
            var strategyMock = new Mock<IShippingStrategy>();
            strategyMock.Setup(x => x.CalculateShipping(price)).Returns(40.0m);
            var shippingService = new ShippingService();

            // Act
            var result = shippingService.CalculateShipping(price, strategyMock.Object);

            // Assert
            Assert.Equal(40.0m, result);
        }

        [Fact]
        public void CalculateShipping_InvokesCalculateShippingMethod_OfShippingStrategy()
        {
            // Arrange
            var price = 100.0m;
            var strategyMock = new Mock<IShippingStrategy>();
            var shippingService = new ShippingService();

            // Act
            shippingService.CalculateShipping(price, strategyMock.Object);

            // Assert
            strategyMock.Verify(x => x.CalculateShipping(price), Times.Once);
        }

        [Fact]
        public void CalculateShipping_Returns_ZeroShippingPrice_ForZeroPrice()
        {
            // Arrange
            var price = 0.0m;
            var strategyMock = new Mock<IShippingStrategy>();
            strategyMock.Setup(x => x.CalculateShipping(price)).Returns(0.0m);
            var shippingService = new ShippingService();

            // Act
            var result = shippingService.CalculateShipping(price, strategyMock.Object);

            // Assert
            Assert.Equal(0.0m, result);
        }
    }
}