namespace Lab2;

public class InventoryManager
{
    private IInventory inventory;
    private IEquipment equipment;
    
    public InventoryManager(IInventory inventory, IEquipment equipment)
    {
        this.inventory = inventory;
        this.equipment = equipment;
    }

    public int PickUp(Item item)
    {
        inventory.AddItem(item);
        return item.id;
    }

    public UseResult Drop(int id)
    {
        if (id <= 0)
        {
            return new UseResult(false, "Такого предмета нет");
        }

        Item item = inventory.FindItem(id);
        if (item == null)
        {
            return new UseResult(false, "Предмета нет в инвентаре");
        }

        RemoveIfEquipped(id);
        inventory.RemoveItem(id);
        
        return new UseResult(true, "Предмет удален");
    }

    public UseResult Use(int id)
    {
        if (id <= 0)
        {
            return new UseResult(false, "Предмета нет в инвентаре");
        }

        Item item = inventory.FindItem(id);
        if (item == null)
        {
            return new UseResult(false, "Предмета нет в инвентаре");
        }

        if (!(item is IUsable))
        {
            return new UseResult(false, "Этот предмет невозможно использовать");
        }

        IUsable usable = (IUsable)item;
        UseResult result = usable.Use();

        if (result.isSuccess && usable.IsUsable())
        {
            RemoveIfEquipped(id);
            inventory.RemoveItem(id);
        }
        return result;
    }

    public UseResult Equip(EquipSlot slot, int id)
    {
        if (id <= 0)
        {
            return new UseResult(false, "Такого предмета нет");
        }

        Item item = inventory.FindItem(id);
        if (item == null)
        {
            return new UseResult(false, "Предмета нет в инвентаре");
        }
        
        int replacedId;
        UseResult result = equipment.Equip(slot, id, out replacedId);

        return result;
    }

    public UseResult UnEquip(EquipSlot slot)
    {
        int removedId;
        UseResult result = equipment.Unequip(slot, out removedId);
        return result;
    }

    public UseResult Upgrade(int id1, int id2)
    {
        if (id1 <= 0 || id2 <= 0)
        {
            return new UseResult(false, "Таких предметов нет");
        }

        if (id1 == id2)
        {
            return new UseResult(false, "Нельзя улучшить предмет самим собой");
        }

        Item first = inventory.FindItem(id1);
        Item second = inventory.FindItem(id2);
        
        if (first == null || second == null)
        {
            return new UseResult(false, "Предмета(ов) нет в инвентаре");
        }

        if (first.GetType() != second.GetType())
        {
            return new UseResult(false, "Предметы должны быть одного типа");
        }
        
        if (first.rarity != second.rarity)
        {
            return new UseResult(false, "Предметы должны быть одной редкости");
        }

        bool isUpgraded = first.TryToUp();
        if (!isUpgraded)
        {
            return new UseResult(false, "Уже максимальная редкость");
        }

        RemoveIfEquipped(id2);
        inventory.RemoveItem(id2);
        
        return new UseResult(true, "Предмет был улучшен");
    }

    public void RemoveIfEquipped(int id)
    {
        int removed;

        if (equipment.GetId(EquipSlot.Weapon) == id)
        {
            equipment.Unequip(EquipSlot.Weapon, out removed);
        }

        if (equipment.GetId(EquipSlot.Armor) == id)
        {
            equipment.Unequip(EquipSlot.Armor, out removed);
        }
    }

    public string GetInventoryStats()
    {
        List<Item> list = inventory.GetItems();

        if (list.Count == 0)
        {
            return "Инвентарь пустой";
        }

        string result = "Инвентарь: \n";

        for (int i = 0; i < list.Count; ++i)
        {
            Item item = list[i];
            result += "-----\n";
            result += $"Номер предмета: {item.id}\n";
            result += $"{item.GetDescription()}\n";
        }
        return result;
    }

    public string GetEquipmentStats()
    {
        string result = "Экипировка: \n";
        int weaponId = equipment.GetId(EquipSlot.Weapon);
        if (weaponId == 0)
        {
            result += "Оружие: нет\n";
        }
        else
        {
            result += $"Оружие: номер - {weaponId}\n";
        }
        
        int armorId = equipment.GetId(EquipSlot.Armor);
        if (weaponId == 0)
        {
            result += "Броня: нет\n";
        }
        else
        {
            result += $"Броня: номер - {weaponId}\n";
        }
        return result;
    }
}
