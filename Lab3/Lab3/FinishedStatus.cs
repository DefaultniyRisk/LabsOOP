namespace Lab3;

public class FinishedStatus : IOrderStatus
{
    public OrderStatus Status => OrderStatus.Finished;
    public IOrderStatus Next() => this;
}