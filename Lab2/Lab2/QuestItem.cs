namespace Lab2;

public class QuestItem : Item, IUsable
{
    public string questName;
    public bool isCompleted;

    public QuestItem(Rarity rarity, int id, string name, int cost, string questName, bool isCompleted)
        : base(id, name, cost, rarity)
    {
        this.questName = questName;
        this.isCompleted = isCompleted;
    }

    public bool IsUsable()
    {
        return false;
    }

    public UseResult Use()
    {
        if (isCompleted)
        {
            return new UseResult(false, "Квест уже выполнен");
        }
        
        isCompleted = true;
        return new UseResult(true, $"Квестовый предмет использован: {name}");
    }

    public override string GetDescription()
    {
        string status;
        if (isCompleted)
        {
            status = "Выполнен";
        }
        else
        {
            status = "Не выполнен";
        }
        
        return $"{base.GetDescription()}\nКвест: {questName}\nСтатус: {status}";
    }
}