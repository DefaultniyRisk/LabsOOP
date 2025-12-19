namespace Lab2;

public class Equipment : IEquipment
{
    private Dictionary<EquipSlot, int> slots;

    public Equipment()
    {
        slots = new Dictionary<EquipSlot, int>();
    }

    public int GetId(EquipSlot slot)
    {
        if (slots.ContainsKey(slot))
        {
            return slots[slot];
        }

        return 0;
    }

    public UseResult Equip(EquipSlot slot, int id, out int replasedId)
    {
        replasedId = 0;

        if (id <= replasedId)
        {
            return new UseResult(false, "Такого предмета нет");
        }

        if (slots.ContainsKey(slot))
        {
            replasedId = slots[slot];
            slots[slot] = id;
            return new UseResult(true, "Предмет экипирован");
        }
        
        slots.Add(slot, id);
        return new UseResult(true, "Предмет экипирован");
    }

    public UseResult Unequip(EquipSlot slot, out int removedId)
    {
        removedId = 0;

        if (!slots.ContainsKey(slot))
        {
            return new UseResult(false, "Слот пуст");
        }
        
        removedId = slots[slot];
        slots.Remove(slot);
        return new UseResult(true, "Предмет убран");
    }
}