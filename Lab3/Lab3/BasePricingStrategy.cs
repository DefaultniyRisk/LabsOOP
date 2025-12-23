namespace Lab3;

public class BasePricingStrategy : IPricing
{
    private int deliveryFee;

    public BasePricingStrategy(int deliveryFee = 10)
    {
        this.deliveryFee = deliveryFee;
    }

    public PricingMethod Calculate(Order order)
    {
        int subtotal = 0;

        for (int i = 0; i < order.items.Count; ++i)
        {
            subtotal += order.items[i].totalPrice;
        }

        int discount = subtotal * order.discount / 100;
        int deliveryFee = this.deliveryFee;
        int totalPrice = subtotal - discount + deliveryFee;
        
        return new PricingMethod(subtotal, discount, deliveryFee, totalPrice);
    }
}