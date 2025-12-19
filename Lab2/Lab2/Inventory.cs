namespace Lab2;

public class Inventory : IInventory
{
    private List<Item> items;

    public Inventory()
    {
        items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(int id)
    {
        for (int i = 0; i < items.Count; ++i)
        {
            if (items[i].id == id)
            {
                items.RemoveAt(i);
                return;
            }
        }
    }

    public Item FindItem(int id)
    {
        for (int i = 0; i < items.Count; ++i)
        {
            if (items[i].id == id)
            {
                return items[i];
            }
        }
        
        return null;
    }

    public List<Item> GetItems()
    {
        return items;
    }
}