namespace Lab2;

class Program
{
    static void Main()
    {
        IInventory inventory = new Inventory();
        IEquipment equipment = new Equipment();
        InventoryManager captain = new InventoryManager(inventory, equipment);
        
        Weapon weapon = new Weapon(Rarity.Common, 1, "Gun", 100, 10);
        Armor armor = new Armor(Rarity.Rare, 2, "Armor",  200, 5);
        Potion potion = new Potion(Rarity.Epic, 3, "Potion", 100, 15, "+200 health");
        
        captain.PickUp(weapon);
        captain.PickUp(armor);
        captain.PickUp(potion);
        
        UseResult first = captain.Equip(EquipSlot.Weapon, 1);
        if (!first.isSuccess)
        {
            throw new Exception($"Экипировка не удалась: {first.message}");
        }
        
        UseResult second = captain.Use(3);
        if (!second.isSuccess)
        {
            throw new Exception($"Использование зелья не удалось: {second.message}");
        }
        
        UseResult third = captain.Upgrade(1, 2);
        
        Console.WriteLine(first.message);
        Console.WriteLine(second.message);
        Console.WriteLine(third.message);
    }
}