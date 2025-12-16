namespace Lab1;

public class OnlineCourse : Courses
{
    public string PlatformOrLink;

    public OnlineCourse(string title, string description, int durationInHours, string platformOrLink)
        : base(title, description, durationInHours, "online")
    {
        PlatformOrLink = platformOrLink;
    }

    public override string ShowAllCourseInfo()
    {
        return GetBaseCourseInfo() + $"\nПлатформа/ссылка: {PlatformOrLink}";
    }
}