namespace Lab2;

public class UseResult
{
    public bool isSuccess;
    public string message;

    public UseResult(bool isSuccess, string message)
    {
        this.isSuccess = isSuccess;
        this.message = message;
    }
}