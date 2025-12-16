namespace Lab1;

public abstract class Courses : Commands
{
    public List<Teacher> teachers = new();
    public List<Student> students = new();
    public string Title;
    public string Description;
    public int DurationInHours;
    public string TypeOfEducation;

    protected Courses(string title, string description, int durationInHours, string typeOfEducation)
    {
        this.Title = title;
        this.Description = description;
        this.DurationInHours = durationInHours;
        this.TypeOfEducation = typeOfEducation;
    }

    public List<Teacher> GetTeachers()
    {
        return teachers;
    }

    public void AddTeacher(Teacher teacher)
    {
        teachers.Add(teacher);
    }

    public void RemoveTeacher(Teacher teacher)
    {
        teachers.Remove(teacher);
    }

    public virtual void AddStudent(Student student)
    {
        students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        students.Remove(student);
    }

    public void PrintAllTeachers()
    {
        foreach (Teacher teacher in teachers)
        {
            Console.WriteLine(teacher.GetFullName());
        }
    }

    public void PrintAllStudents()
    {
        foreach (Student student in students)
        {
            Console.WriteLine(student.GetFullName());
        }
            
    }
    
    protected string GetBaseCourseInfo()
    {
        return $"Курс: {Title}" +
               $"\nОписание: {Description}" +
               $"\nДлительность: {DurationInHours} ч." +
               $"\nФормат: {TypeOfEducation}";
    }

    public List<Student> GetStudents()
    {
        return students;
    }

    public abstract string ShowAllCourseInfo();
}
