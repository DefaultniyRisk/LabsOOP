namespace Lab2;

public class Potion : Item,  IUsable
{
    public string effect;
    public int duration;

    public Potion(Rarity rarity, int id, string name, int duration, int cost, string effect) : base(id, name, cost, rarity)
    {
        this.effect = effect;
        this.duration = duration;
    }

    public bool IsUsable()
    {
        return true;
    }

    public UseResult Use()
    {
        return new UseResult(true, $"{effect} действует, длительность: {duration}.");
    }

    public override string GetDescription()
    {
        return $"{base.GetDescription()}\nЭффект: {effect}\nДлительность: {duration}";
    }
}