using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class CamelCaseConverterTests
{
    [Test]
    public void Test_ConvertToCamelCase_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        string input = string.Empty;
        string expected = string.Empty;

        //Act
        string result = CamelCaseConverter.ConvertToCamelCase(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ConvertToCamelCase_SingleWord_ReturnsLowercaseWord()
    {
        // Arrange
        string input = "SomEStrinG";
        string expected = "somestring";

        //Act
        string result = CamelCaseConverter.ConvertToCamelCase(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ConvertToCamelCase_MultipleWords_ReturnsCamelCase()
    {
        // Arrange
        string input = "more some string";
        string expected = "moreSomeString";

        //Act
        string result = CamelCaseConverter.ConvertToCamelCase(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ConvertToCamelCase_MultipleWordsWithMixedCase_ReturnsCamelCase()
    {
        // Arrange
        string input = "More soMe strING";
        string expected = "moreSomeString";

        //Act
        string result = CamelCaseConverter.ConvertToCamelCase(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
