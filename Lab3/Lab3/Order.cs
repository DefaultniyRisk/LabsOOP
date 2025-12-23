namespace Lab3;

public class Order
{
    public List<OrderMenu> items = new();
    public int id;
    public OrderType type;

    public int discount;

    internal IOrderStatus state;
    public OrderStatus status => state.Status;

    public event Action<OrderStatus>? StatusChanged;

    internal Order(int id, OrderType type, IOrderStatus initial, int discount)
    {
        this.id = id;
        this.type = type;

        state = initial;

        items = new List<OrderMenu>();
        
        SetDiscount(discount);
    }

    public void SetDiscount(int percent)
    {
        if (percent > 100)
        {
            percent = 100;
        }

        if (percent < 0)
        {
            percent = 0;
        }
        this.discount = percent;
    }

    public void AddItem(Menu orderItem, int quantity)
    {
        for (int i = 0; i < items.Count; ++i)
        {
            if (items[i].item.id == orderItem.id)
            {
                items[i].Add(quantity);
                return;
            }
        }
        
        items.Add(new OrderMenu(orderItem, quantity));
    }

    public void RemoveItem(int menuItemId, int quantity = 1)
    {
        for (int i = 0; i < items.Count; ++i)
        {
            if (items[i].item.id == menuItemId)
            {
                items[i].Remove(quantity);
                
                if (items[i].quantity == 0)
                {
                    items.RemoveAt(i);
                }
                return;
            }
        }
    }

    public void Status()
    {
        state = state.Next();
        StatusChanged?.Invoke(status);
    }
}