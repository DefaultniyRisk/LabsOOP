namespace Lab3;

public class OrderManager
{
    private IMenuRepo menu;
    private OrderFactory orderFactory;
    private PricingStrategyFactory pricingFactory;
    
    private Dictionary<int, Order> orders;

    public OrderManager()
    {
        menu = new InMemoryMenu();
        orderFactory = new OrderFactory();
        pricingFactory = new PricingStrategyFactory();
        orders = new Dictionary<int, Order>();
    }

    public List<Menu> GetMenu()
    {
        return menu.GetAll();
    }

    public Order CreateOrder(OrderType type, Options options)
    {
        Order order = orderFactory.CreateOrder(type, options);
        orders[order.id] =  order;
        return order;
    }
    
    public Order GetOrder(int id)
    {
        if (!orders.ContainsKey(id))
        {
            throw new KeyNotFoundException("Заказ не найден");
        }
        return orders[id];
    }

    public void AddItem(int orderId, int itemId, int quantity)
    {
        Order order = GetOrder(orderId);

        Menu? menuItem = menu.GetById(itemId);

        if (menuItem == null)
        {
            throw new KeyNotFoundException("Товар не найден");
        }

        order.AddItem(menuItem, quantity);
    }
    
    public void RemoveItem(int orderId, int itemId, int quantity)
    {
        Order order = GetOrder(orderId);
        order.RemoveItem(itemId, quantity);
    }
    
    public void UpdateDiscount(int orderId, int discount)
    {
        Order order = GetOrder(orderId);
        order.SetDiscount(discount);
    }

    public void AdvanceStatus(int orderId)
    {
        Order order = GetOrder(orderId);
        order.Status();
    }

    public PricingMethod CalculatePrice(int orderId)
    {
        Order order = GetOrder(orderId);

        IPricing strategy = pricingFactory.CreateFor(order.type);
        PricingMethod result = strategy.Calculate(order);
        
        return result;
    }
}