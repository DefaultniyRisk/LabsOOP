namespace Lab2;

public class Armor : Item
{
    public int defense;

    public Armor(Rarity rarity, int id, string name, int defense, int cost) : base(id, name, cost, rarity)
    {
        this.defense = defense;
        
    }

    public override string GetDescription()
    {
        return base.GetDescription() + $"\nБроня: {defense}";
    }
}