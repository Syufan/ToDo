namespace TODO.server.Controllers;
using TODO.server.Services.Interfaces;
using TODO.server.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using TODO.server.Data.Entities;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private IToDoItemService _toDoItemService;

    public TodoController(IToDoItemService toDoItemService)
    {
        _toDoItemService = toDoItemService;
    }

    [HttpGet]
    public ActionResult<List<DTOToDoItem>> GetTodoList()
    {
        var toDoList = _toDoItemService.GetToDoItems();
        if (toDoList.Count() == 0)
        {
            return NoContent();
        }

        var dToList = new List<DTOToDoItem>();
        foreach (ToDoItem item in toDoList)
        {
            dToList.Add(item.ToDto());
        }
        return Ok(dToList);
    }

    [HttpPost]
    public ActionResult<DTOToDoItem> AddTodo(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return BadRequest("Title cannot be empty.");
        }
        var item = _toDoItemService.AddToDoItem(title);
        var dtoItem = new DTOToDoItem();
        dtoItem = item.ToDto();
        return Ok(dtoItem);
    }

    [HttpDelete]
    public ActionResult Deletetodo(int id)
    {
        var state = _toDoItemService.DeleteToDoItem(id);
        if (state)
        {
            return NoContent();
        }
        return NotFound();
    }
}
