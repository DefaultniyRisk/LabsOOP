namespace Lab0;

public class Machine
{
    private readonly List<Product> products = new();
    
    int[] TheChoiceOfCoins = { 1, 2, 5, 10 };

    public int Inserted { get; set; }

    public int Collected { get; set; }

    public Machine()
    {
        products.Add(new Product(3,"Вода", 20, 5));
        products.Add(new Product(2,"Газировка", 30, 4));
        products.Add(new Product(1,"Чипсы", 45, 3));
    }

    public bool Insert(int money, out string response)
    {

        bool validityIndicator = false;

        for (int i = 0; i < TheChoiceOfCoins.Length; ++i)
        {
            if (TheChoiceOfCoins[i] == money)
            {
                validityIndicator = true;
                break;
            }
        }

        if (!validityIndicator)
        {
            response = "Неправильный номинал.";
            return false;
        }
        
        Inserted +=  money;
        response = $"Поступило {money} р. Баланс: {Inserted} р.";
        return true;
    }

    public bool Buying(int id, out string response)
    {
        if (id > products.Count || id <= 0)
        {
            response = "Товара не существует.";
            return false;
        }

        var product = products[id - 1];

        if (Inserted < product.Price)
        {
            response = "Пополните баланс и попробуйте снова.";
            return false;
        }

        if (product.Quantity <= 0)
        {
            response = "Извините, данного товара нет в наличии.";
            return false;
        }

        --product.Quantity;
        Inserted -= product.Price;
        Collected += product.Price;

        response = "Спасибо за покупку!";
        return true;
    }

    public int ReturnChange()
    {
        int change = Inserted;
        Inserted = 0;
        return change;
    }

    public bool NewGoods(int id, int amount, out string response)
    {
        if (id > products.Count || id <= 0)
        {
            response = "Товара не существует.";
            return false;
        }

        if (amount <= 0)
        {
            response = "Введите положительное значение.";
            return false;
        }

        products[id - 1].Quantity += amount;
        response = "Товар успешно доставлен";
        return true;
    }

    public int CollectRevenue()
    {
        int revenue = Collected;
        Collected = 0;
        return revenue;
    }
}