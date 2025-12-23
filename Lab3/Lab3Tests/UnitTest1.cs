using Lab3;

public class Lab3Tests
{
    [Fact]
    public void OrderFactory_CreatesUniqueIds()
    {
        OrderFactory factory = new OrderFactory();

        Order o1 = factory.CreateOrder(OrderType.Standart, new Options());
        Order o2 = factory.CreateOrder(OrderType.Standart, new Options());

        Assert.NotEqual(o1.id, o2.id);
        Assert.True(o2.id > o1.id);
    }

    [Fact]
    public void Order_AddItem_SameMenuItem_IncreasesQuantity()
    {
        OrderManager manager = new OrderManager();
        Order order = manager.CreateOrder(OrderType.Standart, new Options());

        // Menu id=1 ("Бургер") есть в InMemoryMenu
        manager.AddItem(order.id, 1, 1);
        manager.AddItem(order.id, 1, 2);

        int foundCount = 0;
        int qty = 0;

        for (int i = 0; i < order.items.Count; i++)
        {
            if (order.items[i].item.id == 1)
            {
                foundCount++;
                qty = order.items[i].quantity;
            }
        }

        Assert.Equal(1, foundCount);
        Assert.Equal(3, qty);
    }

    [Fact]
    public void Order_RemoveItem_ToZero_RemovesPosition()
    {
        OrderManager manager = new OrderManager();
        Order order = manager.CreateOrder(OrderType.Standart, new Options());

        manager.AddItem(order.id, 2, 2);      // "Салат" 50 * 2
        manager.RemoveItem(order.id, 2, 2);   // убрать всё

        bool exists = false;

        for (int i = 0; i < order.items.Count; i++)
        {
            if (order.items[i].item.id == 2)
            {
                exists = true;
                break;
            }
        }

        Assert.False(exists);
    }

    [Fact]
    public void Order_Status_GoesIsNotReady_ToDelivering_ToFinished()
    {
        OrderFactory factory = new OrderFactory();
        Order order = factory.CreateOrder(OrderType.Standart, new Options());

        Assert.Equal(OrderStatus.IsNotReady, order.status);

        order.Status();
        Assert.Equal(OrderStatus.Delivering, order.status);

        order.Status();
        Assert.Equal(OrderStatus.Finished, order.status);
    }

    [Fact]
    public void Tracker_RecordsStatusHistory_WhenOrderChangesStatus()
    {
        OrderFactory factory = new OrderFactory();
        Order order = factory.CreateOrder(OrderType.Standart, new Options());

        Tracker tracker = new Tracker();
        tracker.Subscribe(order);

        Assert.Equal(1, tracker.GetHistory().Count);
        Assert.Equal(OrderStatus.IsNotReady, tracker.GetHistory()[0]);

        order.Status();

        Assert.Equal(2, tracker.GetHistory().Count);
        Assert.Equal(OrderStatus.Delivering, tracker.GetHistory()[1]);

        order.Status();

        Assert.Equal(3, tracker.GetHistory().Count);
        Assert.Equal(OrderStatus.Finished, tracker.GetHistory()[2]);
    }

    [Fact]
    public void Pricing_BaseStrategy_CalculatesSubtotalDiscountDeliveryTotal()
    {
        OrderManager manager = new OrderManager();
        Order order = manager.CreateOrder(OrderType.Standart, new Options(10)); // 10%

        // Бургер: 100 * 2 = 200
        manager.AddItem(order.id, 1, 2);

        PricingMethod price = manager.CalculatePrice(order.id);

        // subtotal = 200
        // discount = 200 * 10 / 100 = 20
        // deliveryFee = 10 (по умолчанию)
        // total = 200 - 20 + 10 = 190
        Assert.Equal(200, price.subtotal);
        Assert.Equal(20, price.discount);
        Assert.Equal(10, price.deliveryFee);
        Assert.Equal(190, price.totalPrice);
    }

    [Fact]
    public void Pricing_Express_AddsExpressFeeToDeliveryAndTotal()
    {
        OrderManager manager = new OrderManager();
        Order order = manager.CreateOrder(OrderType.Express, new Options(0));

        // Салат: 50 * 1 = 50
        manager.AddItem(order.id, 2, 1);

        PricingMethod price = manager.CalculatePrice(order.id);

        // base: subtotal=50, discount=0, delivery=10, total=60
        // express fee = 20 (в PricingStrategyFactory)
        // new delivery = 30, new total = 80
        Assert.Equal(50, price.subtotal);
        Assert.Equal(0, price.discount);
        Assert.Equal(30, price.deliveryFee);
        Assert.Equal(80, price.totalPrice);
    }
}