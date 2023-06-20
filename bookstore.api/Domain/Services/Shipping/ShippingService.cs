using Service.Interfaces.Shipping;
using Service.Interfaces.Shipping.Strategy;

namespace Service.Services.Shipping
{
    public class ShippingService : IShippingService
    {
        public decimal CalculateShipping(decimal price, IShippingStrategy freteStrategy)
        {
            return freteStrategy.CalculateShipping(price);
        }
    }
}
