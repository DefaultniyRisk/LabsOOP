namespace Lab0;

class Program
{
    static void Main(string[] args)
    {
        var machine = new Machine();
        var admin = new Admin(machine);
        var project = new Interface(machine, admin);

        project.Runner();
    }
}