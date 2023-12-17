using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class NumberFrequencyTests
{
    [Test]
    public void Test_CountDigits_ZeroNumber_ReturnsEmptyDictionary()
    {
        // Arrange
        int input = 0;

        //Act
        Dictionary <int,int> expected = new Dictionary<int,int>();
        Dictionary <int, int> result = NumberFrequency.CountDigits(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CountDigits_SingleDigitNumber_ReturnsDictionaryWithSingleEntry()
    {
        // Arrange
        int input = 3;

        //Act
        Dictionary<int, int> expected = new Dictionary<int, int>()
        {
            [3] = 1
        };
        Dictionary<int, int> result = NumberFrequency.CountDigits(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CountDigits_MultipleDigitNumber_ReturnsDictionaryWithDigitFrequencies()
    {
        // Arrange
        int input = 380852528;

        //Act
        Dictionary<int, int> expected = new Dictionary<int, int>()
        {
            [3] = 1,
            [8] = 3,
            [0] = 1,
            [5] = 2,
            [2] = 2
        };
        Dictionary<int, int> result = NumberFrequency.CountDigits(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CountDigits_NegativeNumber_ReturnsDictionaryWithDigitFrequencies()
    {
        // Arrange
        int input = -380852528;

        //Act
        Dictionary<int, int> expected = new Dictionary<int, int>()
        {
            [3] = 1,
            [8] = 3,
            [0] = 1,
            [5] = 2,
            [2] = 2
        };
        Dictionary<int, int> result = NumberFrequency.CountDigits(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
