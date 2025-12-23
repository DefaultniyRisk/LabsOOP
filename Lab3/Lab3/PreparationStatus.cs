namespace Lab3;

public class PreparationStatus : IOrderStatus
{
    public OrderStatus Status => OrderStatus.IsNotReady;
    public IOrderStatus Next() => new DeliveryStatus();
}