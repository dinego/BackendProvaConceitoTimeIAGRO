namespace Service.Interfaces.Shipping.Strategy
{
    public interface IShippingStrategy
    {
        decimal CalculateShipping(decimal price);
    }
}
