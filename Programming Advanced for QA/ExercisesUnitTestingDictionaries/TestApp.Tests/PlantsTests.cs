using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class PlantsTests
{
    [Test]
    public void Test_GetFastestGrowing_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        string[] plants = new string[0];

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.Empty);
    }


    [Test]
    public void Test_GetFastestGrowing_WithSinglePlant_ShouldReturnPlant()
    {
        // Arrange
        string[] plants = new string[]
            {
                "roses"
            };

        string expected = $"Plants with 5 letters:{Environment.NewLine}roses";

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMultiplePlants_ShouldReturnGroupedPlants()
    {
        // Arrange
        string[] plants = new string[]
            {
                "roses",
                "a",
                "marga",
                "asd",
                "wer"
            };

        string expected = $"Plants with 1 letters:{Environment.NewLine}a{Environment.NewLine}Plants with 3 letters:{Environment.NewLine}asd{Environment.NewLine}wer{Environment.NewLine}Plants with 5 letters:{Environment.NewLine}roses{Environment.NewLine}marga";

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMixedCasePlants_ShouldBeCaseInsensitive()
    {
        // Arrange
        string[] plants = new string[]
            {
                "rOses",
                "a",
                "MARGA",
                "Asd",
                "wer",
                "roses"
            };

        string expected = $"Plants with 1 letters:{Environment.NewLine}a{Environment.NewLine}Plants with 3 letters:{Environment.NewLine}Asd{Environment.NewLine}wer{Environment.NewLine}Plants with 5 letters:{Environment.NewLine}rOses{Environment.NewLine}MARGA{Environment.NewLine}roses";

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
