namespace TODO.server.Services.Implementations;
using TODO.server.Data.Entities;
using TODO.server.Services.Interfaces;

public class ToDoItemService : IToDoItemService
{
    private Dictionary<int, ToDoItem> dicToDoItems = new Dictionary<int, ToDoItem>();
    private int _id = 1;

    public List<ToDoItem> GetToDoItems()
    {
        return dicToDoItems.Values.OrderBy(item => item.Id).ToList();
    }

    public bool DeleteToDoItem(int id)
    {
        return false;
    }

    public bool AddToDoItem(ToDoItem item)
    {
        return false;
    }
}
