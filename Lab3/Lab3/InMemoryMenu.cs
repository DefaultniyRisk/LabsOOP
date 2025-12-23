namespace Lab3;

public class InMemoryMenu : IMenuRepo
{
    private List<Menu> items;

    public InMemoryMenu(List<Menu>? seed = null)
    {
        if (seed != null)
        {
            items = seed;
            return;
        }

        items = new List<Menu>
        {
            new Menu(1, "Бургер", 100),
            new Menu(2, "Салат", 50),
            new Menu(3, "Газировка", 25),
        };
    }

    public List<Menu> GetAll()
    {
        return new List<Menu>(items);
    }
    
    public Menu? GetById(int id)
    {
        for (int i = 0; i < items.Count; ++i)
        {
            if (items[i].id == id)
            {
                return items[i];
            }
        }
        return null;
    }
}