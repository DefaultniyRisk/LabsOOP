namespace Lab1;

public class OfflineCourse : Courses
{
    public string Location { get; }
    public int MaxCapacity { get; }

    public OfflineCourse(string title, string description, int durationInHours,
        string location, int maxCapacity)
        : base(title, description, durationInHours, "offline")
    {
        Location = location;
        MaxCapacity = maxCapacity;
    }

    public override string ShowAllCourseInfo()
    {
        return GetBaseCourseInfo() +
               $"\nЛокация: {Location}" +
               $"\nМакс. вместимость: {MaxCapacity}";
    }

    public override void AddStudent(Student student)
    {
        if (students.Count >= MaxCapacity)
        {
            return;
        }
        students.Add(student);
    }
}