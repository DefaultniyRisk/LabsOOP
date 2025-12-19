namespace Lab2;

public interface IInventory
{
    void AddItem(Item item);
    void RemoveItem(int id);
    Item FindItem(int id);
    List<Item> GetItems();
}