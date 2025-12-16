namespace Lab1;

public class CoursesManagement
{
    private List<Courses> courses;
    private List<Teacher> teachers;

    public CoursesManagement()
    {
        Teacher teacher = new Teacher("Ivanova", "Maria", "Egorovna"
        , 50, 26);
        Teacher teacher1 = new Teacher("Ivanova", "Marina", "Egorovna"
        , 50, 26);
        Teacher teacher2 = new Teacher("Ivanova", "Dasha", "Egorovna"
        , 50, 26);
        courses = new List<Courses>();
        teachers = new List<Teacher> { teacher, teacher1, teacher2 };
    }

    public void AddStudent(Courses course, Student student)
    {
        course.AddStudent(student);
    }

    public void AddTeacherToCourse(Courses course, Teacher teacher)
    {
        course.AddTeacher(teacher);
        teacher.AddCourse(course);
    }

    public void PrintCourses()
    {
        if (courses.Count == 0)
        {
            Console.WriteLine("Курсов нет");
            return;
        }

        for (int i = 0; i < courses.Count; ++i)
        {
            Console.WriteLine($"{i}: {courses[i].Title}");
        }
    }

    public void Create()
    {
        Console.WriteLine("Выберите тип: 1-offline, 2-online");
        Console.Write(":");
        var type = Console.ReadLine();
        
        Console.Write("Название курса: ");
        var title = Console.ReadLine();
        
        Console.Write("Описание курса:");
        var description = Console.ReadLine();
        
        Console.Write("Часы: ");
        int.TryParse(Console.ReadLine(), out var hours);

        if (type == "1")
        {
            Console.Write("Аудитория: ");
            var location =  Console.ReadLine();
            Console.Write("Вместимость: ");
            int.TryParse(Console.ReadLine(), out var capacity);
            courses.Add(new OfflineCourse(title, description, hours, location, capacity));
        }
        else if (type == "2")
        {
            Console.Write("Ссылка: ");
            var link = Console.ReadLine();
            courses.Add(new OnlineCourse(title, description, hours, link));
        }
        else
        {
            Console.WriteLine("Такого типа нет");
        }
    }

    public void Delete()
    {
        if (courses.Count == 0)
        {
            Console.WriteLine("Курсов нет");
            return;
        }
        PrintCourses();
        Console.Write("Номер курса: ");
        if (!int.TryParse(Console.ReadLine(), out var number) || number < 0 || number >= courses.Count)
        {
            Console.WriteLine("Такого курса не существует");
            return;
        }
        var course = courses[number];
        foreach (var t in course.teachers)
        {
            t.RemoveCourse(course);
        }
        courses.Remove(course);
        Console.WriteLine("Курс удален");
    }

    public void AddStudentHere()
    {
        if (courses.Count == 0)
        {
            Console.WriteLine("Курсов нет");
            return;
        }
        PrintCourses();
        Console.Write("Номер курса: ");
        if (!int.TryParse(Console.ReadLine(), out var number) || number < 0 || number >= courses.Count)
        {
            Console.WriteLine("Такого курса не существует");
            return;
        }
        
        Console.Write("Фамилия: "); var surname = Console.ReadLine();
        Console.Write("Имя: "); var name = Console.ReadLine();
        Console.Write("Отчество: "); var secondName = Console.ReadLine();
        Console.Write("Возраст: "); int.TryParse(Console.ReadLine(), out var age);
        Console.Write("Год: "); int.TryParse(Console.ReadLine(), out var year);
        Console.Write("Факультет: "); var department = Console.ReadLine();
        Console.Write("Группа: "); var group = Console.ReadLine();
        
        AddStudent(courses[number], new Student(surname, name, secondName, age, year, department, group));
        Console.WriteLine("Студент добавлен");
    }

    public void AddTeacherHere()
    {
        if (courses.Count == 0)
        {
            Console.WriteLine("Курсов нет");
            return;
        }
        
        if (teachers.Count == 0)
        {
            Console.WriteLine("Преподавателей нет");
            return;
        }
        
        PrintCourses();
        Console.Write("Номер курса: ");
        if (!int.TryParse(Console.ReadLine(), out var number) || number < 0 || number >= courses.Count)
        {
            Console.WriteLine("Такого курса не существует");
            return;
        }

        for (int i = 0; i < teachers.Count; ++i)
        {
            Console.WriteLine($"{i}: {teachers[i].GetFullName()}");
        }
        
        Console.WriteLine("Индекс преподавателя: ");
        if (!int.TryParse(Console.ReadLine(), out var id) || id < 0 || id >= teachers.Count)
        {
            Console.WriteLine("Такого преподавателя не существует");
            return;
        }
        
        AddTeacherToCourse(courses[number],  teachers[id]);
        Console.WriteLine("Преподаватель добавлен");
    }

    public void PrintStudentsCourses()
    {
        if (courses.Count == 0)
        {
            Console.WriteLine("Курсов нет");
            return;
        }
        PrintCourses();
        Console.Write("Номер курса: ");
        if (!int.TryParse(Console.ReadLine(), out var number) || number < 0 || number >= courses.Count)
        {
            Console.WriteLine("Такого курса не существует");
            return;
        }

        Console.WriteLine($"Студенты, обучающиеся на курсе {courses[number].Title}:");
        courses[number].PrintAllStudents();
    }

    public void PrintTeachersCourses()
    {
        if (teachers.Count == 0)
        {
            Console.WriteLine("Преподавателей нет");
            return;
        }
        
        for (int i = 0; i < teachers.Count; ++i)
        {
            Console.WriteLine($"{i}: {teachers[i].GetFullName()}");
        }
        
        Console.WriteLine("Индекс преподавателя: ");
        if (!int.TryParse(Console.ReadLine(), out var id) || id < 0 || id >= teachers.Count)
        {
            Console.WriteLine("Такого преподавателя не существует");
            return;
        }
        
        var teacher = teachers[id];
        Console.WriteLine($"Курсы преподавателя {teacher.GetFullName()}:");
        foreach (var c in teacher.GetCourses())
        {
            Console.WriteLine(c.Title);
        }
    }

    public void Runner()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\n=== ФУНКЦИИ ===");
            Console.WriteLine("1 - Все курсы");
            Console.WriteLine("2 - Создать курс");
            Console.WriteLine("3 - Удалить курс");
            Console.WriteLine("4 - Назначить преподавателя на курс");
            Console.WriteLine("5 - Добавить студента на курс");
            Console.WriteLine("6 - Показать студентов курса");
            Console.WriteLine("7 - Показать курсы преподавателя");
            Console.WriteLine("0 - Выход");
            Console.Write("Команда: ");  
            
            var input = Console.ReadLine();
            Console.WriteLine();

            if (input == "0")
            {
                isRunning = false;
            }
            else if (input == "1")
            {
                PrintCourses();
            }
            else if (input == "2")
            {
                Create();
            }
            else if (input == "3")
            {
                Delete();
            }
            else if (input == "4")
            {
                AddTeacherHere();
            }
            else if (input == "5")
            {
                AddStudentHere();
            }
            else if (input == "6")
            {
                PrintStudentsCourses();
            }
            else if (input == "7")
            {
                PrintTeachersCourses();
            }
            else
            {
                Console.WriteLine("Команды не существует");
            }
        }
    }
}
