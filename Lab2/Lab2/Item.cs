namespace Lab2;

public abstract class Item
{
    public int id;
    public string name;
    public int cost;
    public Rarity  rarity;

    public Item(int id, string name, int cost, Rarity rarity)
    {
        this.id = id;
        this.name = name;
        this.cost = cost;
        this.rarity = rarity;
    }

    public virtual string GetDescription()
    {
        return $"Название: {name}\nСтоимость: {cost}\nРедкость: {rarity}";
    }

    public bool TryToUp()
    {
        if (rarity == Rarity.Legendary)
        {
            return false;
        }

        rarity = (Rarity)((int)rarity + 1);
        return true;
    }
}