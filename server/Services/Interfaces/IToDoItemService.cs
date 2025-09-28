namespace TODO.server.Services.Interfaces;
using TODO.server.Data.Entities;
using System.Collections.Generic;

public interface IToDoItemService
{
    List<ToDoItem> GetToDoItems();
    bool DeleteToDoItem(int id);
    bool AddToDoItem(ToDoItem item);
}
