namespace Lab3;

public class OrderFactory
{
    private int nextId = 0;

    public OrderFactory()
    {
        nextId = 0;
    }

    public Order CreateOrder(OrderType type, Options options)
    {
        if (options == null)
        {
            options = new Options();
        }
        
        ++nextId;
        int id = nextId;

        IOrderStatus initial = new PreparationStatus();
        
        return new Order(id, type, initial, options.discount);
    }
}