using Lab1;

namespace Tests.Lab1;

public class Lab1Tests
{
    [Fact]
    public void GetFullName_ReturnsSurnameNameSecondName()
    {
        var student = new Student("Ivanov", "Egor", "Egorovich", 18, 1, "IS", "m3140");
        Assert.Equal("Ivanov Egor Egorovich", student.GetFullName());
    }

    [Fact]
    public void OnlineCourse_AddStudent_StudentIsInCourseList()
    {
        var course = new OnlineCourse("C# Base", "Basics", 10, "Link");
        var student = new Student("Ivanov", "Egor", "Egorovich", 18, 1, "IS", "m3140");

        course.AddStudent(student);

        Assert.Contains(student, course.GetStudents());
    }

    [Fact]
    public void OfflineCourse_DoesNotAddStudentsOverCapacity()
    {
        var course = new OfflineCourse("OOP", "Practice", 10, "aud 5", 1);

        var s1 = new Student("A", "A", "A", 18, 1, "IS", "m1");
        var s2 = new Student("B", "B", "B", 18, 1, "IS", "m1");

        course.AddStudent(s1);
        course.AddStudent(s2);

        Assert.Single(course.GetStudents());
        Assert.Contains(s1, course.GetStudents());
        Assert.DoesNotContain(s2, course.GetStudents());
    }
}