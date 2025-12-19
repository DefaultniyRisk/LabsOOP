namespace Lab2;

public class Weapon : Item
{
    public int damage;

    public Weapon(Rarity rarity, int id, string name, int damage, int cost) : base(id, name, cost, rarity)
    {
        this.damage = damage;  
    }
    
    public override string GetDescription()
    {
        return base.GetDescription() + $"\nDamage: {this.damage}";
    }
}