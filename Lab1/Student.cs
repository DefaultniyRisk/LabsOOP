namespace Lab1;

public class Student : Human
{
    private int year;
    private string department;
    private string group;

    public Student(string surname, string name, string secondName, int age, int year, string department, string group)
    : base(surname, name, secondName, age)
    {
        this.year = year;
        this.department = department;
        this.group = group;
    }

    public override string GetAllInformation()
    {
        return
            "Студент: " + GetFullName() +
            "\nВозраст: " + GetAge() +
            "\nКурс: " + year +
            "\nФакультет: " + department +
            "\nГруппа: " + group;
    }
}