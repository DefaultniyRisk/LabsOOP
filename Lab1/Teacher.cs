namespace Lab1;

public class Teacher : Human
{
    private List<Courses> courses;
    private int yearsOfPractice;

    public Teacher(string surname, string name, string secondName, int age, int yearsOfPractice)
        : base(surname, name, secondName, age)
    {
        this.yearsOfPractice = yearsOfPractice;
        this.courses = new List<Courses>();
    }
    
    public List<Courses> GetCourses()
    {
        return courses;
    }

    public void AddCourse(Courses course)
    {
        courses.Add(course);
    }

    public void RemoveCourse(Courses course)
    {
        courses.Remove(course);
    }

    public override string GetAllInformation()
    {
        return $"Преподаватель {GetFullName()}:" +
               $"\nВозраст - {GetAge()}" +
               $"\nСтаж - {yearsOfPractice}" +
               $"\nКурсов - {courses.Count}";
    }
}