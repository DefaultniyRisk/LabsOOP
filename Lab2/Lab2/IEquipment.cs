namespace Lab2;

public interface IEquipment
{
    int GetId(EquipSlot slot);
    UseResult Equip(EquipSlot slot, int id, out int replacedId);
    UseResult Unequip(EquipSlot slot, out int removedId);
}