namespace Lab3;

public class OrderMenu
{
    public Menu item;
    public int quantity;
    
    public int totalPrice => item.price * quantity;

    public OrderMenu(Menu item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }

    public void Add(int quantity)
    {
        if (quantity <= 0)
        {
            return;
        }
        this.quantity += quantity;
    }

    public void Remove(int quantity)
    {
        if (quantity <= 0)
        {
            return;
        }
        this.quantity -= quantity;
    }
}