namespace Lab3;

public interface IMenuRepo
{
    List<Menu> GetAll();
    Menu? GetById(int id);
}