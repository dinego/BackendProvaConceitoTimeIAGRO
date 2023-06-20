
using Service.Interfaces.Shipping.Strategy;

namespace Service.Services.Shipping.Strategy
{
    public class ShippingNormalStrategy : IShippingStrategy
    {
        public decimal CalculateShipping(decimal price)
        {
            return price * 0.2m;
        }
    }

    public class ShippingExpressStrategy : IShippingStrategy
    {
        public decimal CalculateShipping(decimal price)
        {
            return price * 0.4m;
        }
    }
}
