namespace Lab0;

public class Admin
{
    private Machine machine;
    private const string password = "123";
    public Admin(Machine machine)
    {
        this.machine = machine;
    }

    public bool Login(string input)  => input == password;
    
    public bool NewProducts(int productNumber, int amount, out string response) 
    => machine.NewGoods(productNumber, amount, out response);

    public int GiveMeAllMoney() => machine.CollectRevenue();
}