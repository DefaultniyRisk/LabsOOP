namespace Lab1;

public abstract class Human
{
    protected string Surname;
    protected string Name;
    protected string SecondName;
    protected int Age;

    protected Human(string surname, string name, string secondName, int age)
    {
        Surname = surname;
        Name = name;
        SecondName = secondName;
        Age = age;
    }

    public string GetFullName()
    {
        return $"{Surname} {Name} {SecondName}";
    }

    public int GetAge()
    {
        return Age;
    }

    public abstract string GetAllInformation();
}