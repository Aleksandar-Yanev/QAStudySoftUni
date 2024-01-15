using System;

using NUnit.Framework;

using TestApp.Todo;

namespace TestApp.Tests;

[TestFixture]
public class ToDoListTests
{
    private ToDoList _toDoList = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._toDoList = new();
    }
    
    [Test]
    public void Test_AddTask_TaskAddedToToDoList()
    {
        // Arrange
        string title = "Go to shop";
        DateTime date = DateTime.Today;

        //Act
        _toDoList.AddTask(title, date);
        string result = _toDoList.DisplayTasks ();

        //Assert
        Assert.That(result, Does.Contain ("To-Do List:"));  
        Assert.That(result, Does.Contain ("[ ] Go to shop - Due: "));  
    }

    [Test]
    public void Test_CompleteTask_TaskMarkedAsCompleted()
    {
        // Arrange
        string title = "Go to shop";
        DateTime date = DateTime.Today;

        //Act
        _toDoList.AddTask(title, date);
        _toDoList.CompleteTask(title);
        string result = _toDoList.DisplayTasks();

        //Assert
        Assert.That(result, Does.Contain("To-Do List:"));
        Assert.That(result, Does.Contain("[✓] Go to shop - Due: "));
    }

    [Test]
    public void Test_CompleteTask_TaskNotFound_ThrowsArgumentException()
    {
        //Arrange
        string title = "Hello";

        //Act & Assert
        Assert.That(() => _toDoList.CompleteTask(title), Throws.ArgumentException.With.Message.EqualTo("Task with given title does not exist."));
    }

    [Test]
    public void Test_DisplayTasks_NoTasks_ReturnsEmptyString()
    {
        //Arrange

        //Act
        string result = _toDoList.DisplayTasks ();

        //Assert
        Assert.That(result, Is.EqualTo("To-Do List:"));
    }

    [Test]
    public void Test_DisplayTasks_WithTasks_ReturnsFormattedToDoList()
    {
        // Arrange
        string title = "Go to shop";
        DateTime date = DateTime.Today;
        string title1 = "Buy a beer";
        DateTime date1 = DateTime.Today;
        string title2 = "Return to home";
        DateTime date2 = DateTime.Today;

        //Act
        _toDoList.AddTask(title, date);
        _toDoList.AddTask(title1, date1);
        _toDoList.AddTask(title2, date2);

        _toDoList.CompleteTask(title1);
        string result = _toDoList.DisplayTasks();

        //Assert
        Assert.That(result, Does.Contain("To-Do List:"));
        Assert.That(result, Does.Contain("[ ] Go to shop - Due: "));
        Assert.That(result, Does.Contain("[✓] Buy a beer - Due: "));
        Assert.That(result, Does.Contain("[ ] Return to home - Due: "));
    }
}
