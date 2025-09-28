namespace TODO.server.Tests.UnitServices;

using FluentAssertions;
using TODO.server.Services.Implementations;
using Xunit;

public class UToDoItemService
{
    [Fact]
    public void List_Empty_Return()
    {
        var service = new ToDoItemService();
        var items = service.GetToDoItems();

        items.Should().BeEmpty();
    }

    [Fact]
    public void List_One_Return()
    {
        var service = new ToDoItemService();
        service.AddToDoItem("Buy milk");
        var items = service.GetToDoItems();
        items.Should().ContainSingle(i => i.Title == "Buy milk");
    }
}
