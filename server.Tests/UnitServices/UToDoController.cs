namespace TODO.server.Tests.UnitServices;

using FluentAssertions;
using TODO.server.Controllers;
using TODO.server.Services.Implementations;
using TODO.server.Data.DTO;
using System.Collections.Generic;
using Xunit;
using Microsoft.AspNetCore.Mvc;

public class UToDoController
{
    [Fact]
    public void List_Empty_GetTodoList()
    {
        var server = new ToDoItemService();
        var controller = new TodoController(server);
        var result = controller.GetTodoList();
        result.Result.Should().BeOfType<NoContentResult>();
    }

    [Fact]
    public void List_Two_GetTodoList()
    {
        var server = new ToDoItemService();
        var controller = new TodoController(server);
        controller.AddTodo("Buy milk");
        controller.AddTodo("Buy paper");
        var result = controller.GetTodoList();

        result.Result.Should().BeOfType<CreatedResult>();
        var createdResult = result.Result.As<CreatedResult>();
        createdResult.Value.Should().BeAssignableTo<List<DTOToDoItem>>();
        var todos = createdResult.Value.As<List<DTOToDoItem>>();

        todos.Should().HaveCount(2);
        todos.Should().Contain(i => i.Title == "Buy milk");
        todos.Should().Contain(i => i.Title == "Buy paper");
    }

    [Fact]
    public void Add_Empty_AddTodo()
    {
        var server = new ToDoItemService();
        var controller = new TodoController(server);
        var result = controller.AddTodo(" ");

        result.Result.Should().BeOfType<BadRequestObjectResult>();
        var badRequest = result.Result.As<BadRequestObjectResult>();
        badRequest.Value.Should().Be("Title cannot be empty.");
    }

    [Fact]
    public void Add_One_AddTodo()
    {
        var server = new ToDoItemService();
        var controller = new TodoController(server);
        var result = controller.AddTodo("Buy milk");

        result.Result.Should().BeOfType<CreatedResult>();
        var createdResult = result.Result.As<CreatedResult>();
        createdResult.Value.Should().BeAssignableTo<DTOToDoItem>();
        var todos = createdResult.Value.As<DTOToDoItem>();
        todos.Title.Should().Be("Buy milk");
        todos.Id.Should().BeGreaterThan(0);
    }

    [Fact]
    public void Delete_Noexist_Deletetodo()
    {
        var server = new ToDoItemService();
        var controller = new TodoController(server);
        var result = controller.Deletetodo(3);
        result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public void Delete_One_Deletetodo()
    {
        var server = new ToDoItemService();
        var controller = new TodoController(server);
        var item = controller.AddTodo("Buy milk");
        var createdResult = item.Result.As<CreatedResult>();
        var dto = createdResult.Value.As<DTOToDoItem>();
        var result = controller.Deletetodo(dto.Id);
        result.Should().BeOfType<NoContentResult>();
    }
}
