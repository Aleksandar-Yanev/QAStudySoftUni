using NUnit.Framework;

using System;
using System.Text;

namespace TestApp.Tests;

public class CountRealNumbersTests
{
    // TODO: finish test
    [Test]
    public void Test_Count_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        int[] input = { };

        // Act
        string result = CountRealNumbers.Count(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Count_WithSingleNumber_ShouldReturnCountString()
    {
        // Arrange
        int[] input = { 2 };

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("2 -> 1");
        
        string expected = sb.ToString().Trim();

        // Act
        string result = CountRealNumbers.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithMultipleNumbers_ShouldReturnCountString()
    {
        // Arrange
        int[] input = { 55, 2, 4, 43, 55, 4 };
        
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("2 -> 1");
        sb.AppendLine("4 -> 2");
        sb.AppendLine("43 -> 1");       
        sb.AppendLine("55 -> 2");
        string expected = sb.ToString().Trim();

        // Act
        string result = CountRealNumbers.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithNegativeNumbers_ShouldReturnCountString()
    {
        // Arrange
        int[] input = { 55, 2, 4, - 43, 55, - 4 };

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("-43 -> 1");
        sb.AppendLine("-4 -> 1");
        sb.AppendLine("2 -> 1");
        sb.AppendLine("4 -> 1");
        sb.AppendLine("55 -> 2");
        string expected = sb.ToString().Trim();

        // Act
        string result = CountRealNumbers.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithZero_ShouldReturnCountString()
    {
        // Arrange
        int[] input = { 55, 2, 4, -43, 55, -4, 0 };

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("-43 -> 1");
        sb.AppendLine("-4 -> 1");
        sb.AppendLine("0 -> 1");
        sb.AppendLine("2 -> 1");
        sb.AppendLine("4 -> 1");
        sb.AppendLine("55 -> 2");
        string expected = sb.ToString().Trim();

        // Act
        string result = CountRealNumbers.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
