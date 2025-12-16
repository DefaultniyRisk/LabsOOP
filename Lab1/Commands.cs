namespace Lab1;

public interface Commands
{
    public void AddStudent(Student student);
    public void RemoveStudent(Student student);
    List<Student> GetStudents();
}