namespace Lab3;

public class Options
{
    public int discount;
    
    public Options(int discount = 0)
    {
        if (discount < 0)
        {
            discount = 0;
        }

        if (discount > 100)
        {
            discount = 100;
        }
        this.discount = discount;
    }
}