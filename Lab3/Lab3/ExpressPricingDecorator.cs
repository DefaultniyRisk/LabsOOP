namespace Lab3;

public class ExpressPricingDecorator : IPricing
{
    private IPricing inner;
    private int expressFee;

    public ExpressPricingDecorator(IPricing inner, int expressFee)
    {
        this.inner = inner;
        this.expressFee = expressFee;
    }

    public PricingMethod Calculate(Order order)
    {
        PricingMethod basePrice = inner.Calculate(order);

        int newDeliveryFee = basePrice.deliveryFee + expressFee;
        int newTotalPrice = basePrice.totalPrice + expressFee;

        return new PricingMethod(
            basePrice.subtotal,
            basePrice.discount,
            newDeliveryFee,
            newTotalPrice
        );
    }
}