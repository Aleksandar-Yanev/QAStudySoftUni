using NUnit.Framework;
using System;
using TestApp.Product;

namespace TestApp.Tests;

[TestFixture]
public class ProductInventoryTests
{
    private ProductInventory _inventory = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._inventory = new();
    }
    
    [Test]
    public void Test_AddProduct_ProductAddedToInventory()
    {
        //Arrange
        string name = "Cofee";
        double price = 1.25;
        int quantity = 20;
        string expected = $"Product Inventory:{Environment.NewLine}{name} - Price: ${price:f2} - Quantity: {quantity}";

        //Act
        _inventory.AddProduct(name, price, quantity);
        string result = _inventory.DisplayInventory();

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DisplayInventory_NoProducts_ReturnsEmptyString()
    {
        //Arrange
        
        string expected = "Product Inventory:";

        //Act
        
        string result = _inventory.DisplayInventory();

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DisplayInventory_WithProducts_ReturnsFormattedInventory()
    {
        //Arrange
        string name = "Cofee";
        double price = 1.25;
        int quantity = 20;
        string name1 = "Milk";
        double price1 = 0.5;
        int quantity1 = 7;
        string expected = $"Product Inventory:{Environment.NewLine}{name} - Price: ${price:f2} - Quantity: {quantity}" +
            $"{Environment.NewLine}{name1} - Price: ${price1:f2} - Quantity: {quantity1}";

        //Act
        _inventory.AddProduct(name, price, quantity);
        _inventory.AddProduct(name1, price1, quantity1);
        string result = _inventory.DisplayInventory();

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CalculateTotalValue_NoProducts_ReturnsZero()
    {
        //Arrange

        //Act
        double totalValue = _inventory.CalculateTotalValue();

        //Assert
        Assert.That(totalValue, Is.Zero);
    }

    [Test]
    public void Test_CalculateTotalValue_WithProducts_ReturnsTotalValue()
    {
        //Arrange
        string name = "Cofee";
        double price = 1.25;
        int quantity = 20;
        string name1 = "Milk";
        double price1 = 0.5;
        int quantity1 = 7;
        double expected = 28.5;

        //Act
        _inventory.AddProduct(name, price, quantity);
        _inventory.AddProduct(name1, price1, quantity1);
        double totalValue = _inventory.CalculateTotalValue();

        //Assert
        Assert.That(totalValue, Is.EqualTo(expected));
    }
}
