namespace Lab3;

public interface IOrderStatus
{
    OrderStatus Status { get; }
    IOrderStatus Next();
}