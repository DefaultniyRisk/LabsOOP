namespace Lab3;

public class DeliveryStatus : IOrderStatus
{
    public OrderStatus Status => OrderStatus.Delivering;
    public IOrderStatus Next() => new FinishedStatus();
}