namespace Lab3;

public class PricingMethod
{
    public int subtotal;
    public int discount;
    public int deliveryFee;
    public int totalPrice;

    public PricingMethod(int subtotal, int discount, int deliveryFee, int totalPrice)
    {
        this.subtotal = subtotal;
        this.discount = discount;
        this.deliveryFee = deliveryFee;
        this.totalPrice = totalPrice;
    }
}