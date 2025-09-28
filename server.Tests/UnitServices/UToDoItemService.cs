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

    [Fact]
    public void List_Two_Return()
    {
        var service = new ToDoItemService();
        service.AddToDoItem("Buy milk");
        service.AddToDoItem("Buy paper");
        var items = service.GetToDoItems();
        items.Should().HaveCount(2);
        items.Should().Contain(i => i.Title == "Buy milk");
        items.Should().Contain(i => i.Title == "Buy paper");
    }

    [Fact]
    public void Add_EmptySpaceItem()
    {
        var service = new ToDoItemService();
        service.AddToDoItem("   ");
        var items = service.GetToDoItems();
        items.Should().ContainSingle(i => i.Title == "");
    }

    [Fact]
    public void Add_EmptyItem()
    {
        var service = new ToDoItemService();
        service.AddToDoItem("");
        var items = service.GetToDoItems();
        items.Should().ContainSingle(i => i.Title == "");
    }

    [Fact]
    public void Delete_Empty()
    {
        var service = new ToDoItemService();
        service.DeleteToDoItem(0);
        var items = service.GetToDoItems();
        var result = service.DeleteToDoItem(0);
        result.Should().BeFalse();
        items.Should().HaveCount(0);
    }

    [Fact]
    public void Delete_One()
    {
        var service = new ToDoItemService();
        var item1 = service.AddToDoItem("Buy milk");
        var result = service.DeleteToDoItem(item1.Id);
        var items = service.GetToDoItems();
        items.Should().HaveCount(0);
        result.Should().BeTrue();
    }

    [Fact]
    public void Delete_Two()
    {
        var service = new ToDoItemService();
        var item1 = service.AddToDoItem("Buy milk");
        var item2 = service.AddToDoItem("Buy paper");
        var result1 = service.DeleteToDoItem(item1.Id);
        var result2 = service.DeleteToDoItem(item2.Id);
        var items = service.GetToDoItems();
        items.Should().HaveCount(0);
        result1.Should().BeTrue();
        result2.Should().BeTrue();
    }
}
