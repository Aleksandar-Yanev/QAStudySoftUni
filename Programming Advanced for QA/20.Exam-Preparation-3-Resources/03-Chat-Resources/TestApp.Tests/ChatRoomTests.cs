using System;

using NUnit.Framework;

using TestApp.Chat;

namespace TestApp.Tests;

[TestFixture]
public class ChatRoomTests
{
    private ChatRoom _chatRoom = null!;
    
    [SetUp]
    public void Setup()
    {
        this._chatRoom = new();
    }
    
    [Test]
    public void Test_SendMessage_MessageSentToChatRoom()
    {
        // Arrange
        string sender = "John";
        string message = "Hello, World!";
        

        // Act
        _chatRoom.SendMessage(sender, message);
        var result = _chatRoom.DisplayChat();

        // Assert
        StringAssert.Contains("Chat Room Messages:", result);
        StringAssert.Contains("John: Hello, World! - Sent at", result);
    }

    [Test]
    public void Test_DisplayChat_NoMessages_ReturnsEmptyString()
    {
        // Arrange & Act
        string result = _chatRoom.DisplayChat();

        // Assert
        Assert.That(result, Is.EqualTo(string.Empty));
    }

    [Test]
    public void Test_DisplayChat_WithMessages_ReturnsFormattedChat()
    {
        // Arrange
        _chatRoom.SendMessage("Alice", "Hi there!");
        _chatRoom.SendMessage("Bob", "Hey, Alice!");

        // Act
        string result = _chatRoom.DisplayChat();

        // Assert
        StringAssert.Contains("Chat Room Messages:", result);
        StringAssert.Contains("Alice: Hi there! - Sent at", result);
        StringAssert.Contains("Bob: Hey, Alice! - Sent at", result);
    }
}
