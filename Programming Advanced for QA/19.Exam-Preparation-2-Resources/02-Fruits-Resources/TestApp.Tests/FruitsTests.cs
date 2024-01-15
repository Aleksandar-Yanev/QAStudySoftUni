using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class FruitsTests
{
    [Test]
    public void Test_GetFruitQuantity_FruitExists_ReturnsQuantity()
    {
        // Arrange
        Dictionary <string, int> fruitDictionary = new Dictionary<string, int>()
        { 
         ["apple"] = 5,
         ["orange"] = 15,
         ["banana"] = 2,
         ["kiwi"] = 46        
        };

        string fruitName = "banana";
        int expected = 2;

        //Act
        int result = Fruits.GetFruitQuantity(fruitDictionary, fruitName);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFruitQuantity_FruitDoesNotExist_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> fruitDictionary = new Dictionary<string, int>()
        {
            ["apple"] = 5,
            ["orange"] = 15,
            ["banana"] = 2,
            ["kiwi"] = 46
        };

        string fruitName = "mango";
        int expected = 0;

        //Act
        int result = Fruits.GetFruitQuantity(fruitDictionary, fruitName);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFruitQuantity_EmptyDictionary_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> fruitDictionary = new Dictionary<string, int>();

        string fruitName = "mango";
        int expected = 0;

        //Act
        int result = Fruits.GetFruitQuantity(fruitDictionary, fruitName);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFruitQuantity_NullDictionary_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> fruitDictionary = null;

        string fruitName = "mango";
        int expected = 0;

        //Act
        int result = Fruits.GetFruitQuantity(fruitDictionary, fruitName);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFruitQuantity_NullFruitName_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> fruitDictionary = new Dictionary<string, int>()
        {
            ["apple"] = 5,
            ["orange"] = 15,
            ["banana"] = 2,
            ["kiwi"] = 46
        };

        string fruitName = null;
        int expected = 0;

        //Act
        int result = Fruits.GetFruitQuantity(fruitDictionary, fruitName);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
