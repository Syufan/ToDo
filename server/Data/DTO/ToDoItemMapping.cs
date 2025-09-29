using TODO.server.Data.DTO;
using TODO.server.Data.Entities;

namespace TODO.server.Data.DTO;

public static class ToDoItemMapping
{
    public static DTOToDoItem ToDto(this ToDoItem enitiy)
    {
        return new DTOToDoItem { Id = enitiy.Id, Title = enitiy.Title };
    }
}
