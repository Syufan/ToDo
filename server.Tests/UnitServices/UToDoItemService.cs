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
}
