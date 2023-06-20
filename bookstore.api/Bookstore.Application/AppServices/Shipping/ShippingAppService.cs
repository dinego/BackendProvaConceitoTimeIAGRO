using Bookstore.Application.Interfaces.Shipping;
using Service.Interfaces.Shipping;
using Service.Interfaces.Shipping.Strategy;

namespace Bookstore.Application.AppServices
{
    public class ShippingAppService : IShippingAppService
    {
        private readonly IShippingService _shippingService;

        public ShippingAppService(IShippingService shippingService)
        {
            _shippingService = shippingService;
        }

        public decimal CalculateShipping(decimal price, IShippingStrategy shippingStrategy)
        {
            return _shippingService.CalculateShipping(price, shippingStrategy);
        }
    }
}
