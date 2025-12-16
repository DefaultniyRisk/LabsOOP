namespace Lab0;

public class Product
{
    public int Number { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }     
    public int Quantity { get; set; } 
    
    public Product(int number, string name, int price, int quantity)
    {
        Number = number;
        Name = name;
        Price = price;
        Quantity = quantity;
        
    }

    public override string ToString()
    {
        return $"{Number}. {Name}: {Price} руб. (осталось {Quantity})";
    }
}