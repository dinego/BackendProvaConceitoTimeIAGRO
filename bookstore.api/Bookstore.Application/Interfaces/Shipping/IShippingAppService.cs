using Service.Interfaces.Shipping.Strategy;

namespace Bookstore.Application.Interfaces.Shipping
{
    public interface IShippingAppService
    {
        decimal CalculateShipping(decimal price, IShippingStrategy shippingStrategy);
    }
}
