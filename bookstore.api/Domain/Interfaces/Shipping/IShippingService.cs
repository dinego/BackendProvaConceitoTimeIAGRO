using Service.Interfaces.Shipping.Strategy;
namespace Service.Interfaces.Shipping
{
    public interface IShippingService
    {
        decimal CalculateShipping(decimal price, IShippingStrategy shippingStrategy);
    }
}
