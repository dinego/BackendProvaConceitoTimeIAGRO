using Service.Services.Shipping.Strategy;

namespace bookstore.api.Tests
{
    public class ShippingStrategyTests
    {
        [Fact]
        public void CalculateShipping_Returns_CorrectNormalShippingPrice()
        {
            // Arrange
            var strategy = new ShippingNormalStrategy();
            decimal price = 100.0m;
            decimal expectedShippingPrice = 20.0m;

            // Act
            var result = strategy.CalculateShipping(price);

            // Assert
            Assert.Equal(expectedShippingPrice, result);
        }

        [Fact]
        public void CalculateShipping_Returns_CorrectExpressShippingPrice()
        {
            // Arrange
            var strategy = new ShippingExpressStrategy();
            decimal price = 100.0m;
            decimal expectedShippingPrice = 40.0m;

            // Act
            var result = strategy.CalculateShipping(price);

            // Assert
            Assert.Equal(expectedShippingPrice, result);
        }

        [Fact]
        public void CalculateShipping_Returns_ZeroShippingPrice_ForZeroPrice()
        {
            // Arrange
            var strategy = new ShippingNormalStrategy();
            decimal price = 0.0m;
            decimal expectedShippingPrice = 0.0m;

            // Act
            var result = strategy.CalculateShipping(price);

            // Assert
            Assert.Equal(expectedShippingPrice, result);
        }

        [Fact]
        public void CalculateShipping_Returns_NegativeShippingPrice_ForNegativePrice()
        {
            // Arrange
            var strategy = new ShippingExpressStrategy();
            decimal price = -100.0m;
            decimal expectedShippingPrice = -40.0m;

            // Act
            var result = strategy.CalculateShipping(price);

            // Assert
            Assert.Equal(expectedShippingPrice, result);
        }
    }
}