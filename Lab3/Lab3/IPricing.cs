namespace Lab3;

public interface IPricing
{
    PricingMethod Calculate(Order order);
}