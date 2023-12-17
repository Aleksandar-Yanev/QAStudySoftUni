using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class StringRotatorTests
{
    [Test]
    public void Test_RotateRight_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        string input = string.Empty;
        int positions = 1;
        string expected = string.Empty;

        //Act
        string result = StringRotator.RotateRight(input, positions);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RotateRight_RotateByZeroPositions_ReturnsOriginalString()
    {
        // Arrange
        string input = "string";
        int positions = 0;
        string expected = "string";

        //Act
        string result = StringRotator.RotateRight(input, positions);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RotateRight_RotateByPositivePositions_ReturnsRotatedString()
    {
        // Arrange
        string input = "string";
        int positions = 2;
        string expected = "ngstri";

        //Act
        string result = StringRotator.RotateRight(input, positions);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RotateRight_RotateByNegativePositions_ReturnsRotatedString()
    {
        // Arrange
        string input = "string";
        int positions = -2;
        string expected = "ngstri";

        //Act
        string result = StringRotator.RotateRight(input, positions);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RotateRight_RotateByMorePositionsThanStringLength_ReturnsRotatedString()
    {
        // Arrange
        string input = "string";
        int positions = 7;
        string expected = "gstrin";

        //Act
        string result = StringRotator.RotateRight(input, positions);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
