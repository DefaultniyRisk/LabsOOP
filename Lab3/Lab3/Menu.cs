namespace Lab3;

public class Menu
{
    public int id;
    public string name;
    public int price;
    
    public Menu(int id, string name, int price) {
        this.id = id;
        this.name = name;
        this.price = price;
    }

    public override string ToString()
    {
        return $"{id}) - {name} - {price}";
    }
}