using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace TestApp.Tests;

[TestFixture]
public class CsvParserTests
{
    [Test]
    public void Test_ParseCsv_EmptyInput_ReturnsEmptyArray()
    {
        //Arrange
        string input = "";
        string[] expected = { };

        //Act
        string[] result = CsvParser.ParseCsv(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ParseCsv_SingleField_ReturnsArrayWithOneElement()
    {
        //Arrange
        string input = "single";
        string[] expected = { "single" };

        //Act
        string[] result = CsvParser.ParseCsv(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ParseCsv_MultipleFields_ReturnsArrayWithMultipleElements()
    {
        //Arrange
        string input = "single,maybe,dog";
        string[] expected = { "single", "maybe", "dog" };

        //Act
        string[] result = CsvParser.ParseCsv(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ParseCsv_TrimsWhiteSpace_ReturnsCleanArray()
    {
        //Arrange
        string input = "   single, maybe   ,    dog    ";
        string[] expected = { "single", "maybe", "dog" };

        //Act
        string[] result = CsvParser.ParseCsv(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
