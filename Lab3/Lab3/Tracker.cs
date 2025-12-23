namespace Lab3;

public class Tracker
{
    private List<OrderStatus> history;

    public Tracker()
    {
        history = new List<OrderStatus>();
    }
    
    public List<OrderStatus> GetHistory()
    {
        return history;
    }

    public void Subscribe(Order order)
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order));
        }
        history.Add(order.status);

        order.StatusChanged += StatusChange;
    }

    public void Unsubscribe(Order order)
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order));
        }
        
        order.StatusChanged -= StatusChange;
    }
    
    private void StatusChange(OrderStatus status)
    {
        history.Add(status);
    }
}