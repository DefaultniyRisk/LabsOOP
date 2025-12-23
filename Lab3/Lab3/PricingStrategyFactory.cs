namespace Lab3;

public class PricingStrategyFactory
{
    public IPricing CreateFor(OrderType orderType)
    {
        IPricing strategy = new BasePricingStrategy();

        if (orderType == OrderType.Express)
        {
            strategy = new ExpressPricingDecorator(strategy, 20);
        }
        
        return strategy;
    }
}