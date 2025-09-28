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
        if (dicToDoItems.ContainsKey(id))
        {
            dicToDoItems.Remove(id);
            return true;
        }
        return false;
    }

    public ToDoItem AddToDoItem(string title)
    {
        var id = Interlocked.Increment(ref _id);
        var item = new ToDoItem { Id = id, Title = title?.Trim() };
        dicToDoItems.Add(id, item);
        return item;
    }
}
