using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class OrdersTests
{
    [Test]
    public void Test_Order_WithEmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string[] input = new string[0];

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_Order_WithMultipleOrders_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = new string[] 
        { 
            "apple 1.99 1",
            "banana 3.75 1", 
            "orange 1.99 1", 
            "orange 0.99 1",
            "apple 1.99 2"
        };

        string expected = $"apple -> 5.97{Environment.NewLine}banana -> 3.75{Environment.NewLine}orange -> 1.98";

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Order_WithRoundedPrices_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = new string[]
        {
            "apple 5.970000000001 1",
            "banana 3.75 1",
            "orange 1.2 1",
            "orange 0.9899999999 1"
        };

        string expected = $"apple -> 5.97{Environment.NewLine}banana -> 3.75{Environment.NewLine}orange -> 1.98";

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected)); 
    }

    [Test]
    public void Test_Order_WithDecimalQuantities_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = new string[]
       {
            "apple 5.97 1",
            "banana 3.00 1.5",
            "orange 1.99 0.5",
            "orange 0.99 0.5"
       };

        string expected = $"apple -> 5.97{Environment.NewLine}banana -> 4.50{Environment.NewLine}orange -> 0.99";

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
