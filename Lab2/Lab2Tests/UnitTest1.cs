using Lab2;

namespace Lab2Tests;

public class InventoryTests
{
    private InventoryManager CreateManager(out Inventory inventory, out Equipment equipment)
    {
        inventory = new Inventory();
        equipment = new Equipment();
        return new InventoryManager(inventory, equipment);
    }
    
    [Fact]
    public void Weapon_Equip_PutsIdToWeaponSlot()
    {
        InventoryManager manager = CreateManager(out Inventory inventory, out Equipment equipment);
        
        Weapon weapon = new Weapon(Rarity.Common, 1, "Gun", 10, 100);
        manager.PickUp(weapon);

        UseResult result = manager.Equip(EquipSlot.Weapon, 1);

        Assert.True(result.isSuccess);
        Assert.Equal(1, equipment.GetId(EquipSlot.Weapon));
    }

    [Fact]
    public void Armor_Equip_PutsIdToArmorSlot()
    {
        InventoryManager manager = CreateManager(out Inventory inventory, out Equipment equipment);
        
        Armor armor = new Armor(Rarity.Rare, 2, "Armor", 5, 200);
        manager.PickUp(armor);

        UseResult result = manager.Equip(EquipSlot.Armor, 2);

        Assert.True(result.isSuccess);
        Assert.Equal(2, equipment.GetId(EquipSlot.Armor));
    }

    [Fact]
    public void Potion_Use_RemovesFromInventory()
    {
        InventoryManager manager = CreateManager(out Inventory inventory, out Equipment equipment);
        
        Potion potion = new Potion(Rarity.Epic, 3, "Potion", 15, 50, "+200 health");
        manager.PickUp(potion);

        UseResult result = manager.Use(3);

        Assert.True(result.isSuccess);
        Assert.Null(inventory.FindItem(3)); 
    }

    [Fact]
    public void QuestItem_Use_MarksCompleted_AndStaysInInventory()
    {
        InventoryManager manager = CreateManager(out Inventory inventory, out Equipment equipment);
        
        QuestItem quest = new QuestItem(Rarity.Common, 4, "Letter", 1, "Quest", false);
        manager.PickUp(quest);

        UseResult result = manager.Use(4);

        Assert.True(result.isSuccess);
        Assert.True(quest.isCompleted);
        Assert.NotNull(inventory.FindItem(4));
    }
}