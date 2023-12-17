using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class GradesTests
{
    [Test]
    public void Test_GetBestStudents_ReturnsBestThreeStudents()
    {
        // Arrange
        Dictionary<string, int> students = new Dictionary<string, int>();
        students["Boris"] = 6;
        students["Alex"] = 3;
        students["Mira"] = 4;
        students["Dimo"] = 5;

        string expected = $"Boris with average grade 6.00{ Environment.NewLine}" +
            $"Dimo with average grade 5.00{Environment.NewLine}" +
            $"Mira with average grade 4.00";

        //Act
        string result = Grades.GetBestStudents(students);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetBestStudents_EmptyGrades_ReturnsEmptyString()
    {
        // Arrange
        Dictionary<string, int> students = new Dictionary<string, int>();

        string expected = string.Empty;

        //Act
        string result = Grades.GetBestStudents(students);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetBestStudents_LessThanThreeStudents_ReturnsAllStudents()
    {
        // Arrange
        Dictionary<string, int> students = new Dictionary<string, int>();
        students["Boris"] = 6;
        students["Alex"] = 3;
        
        string expected = $"Boris with average grade 6.00{Environment.NewLine}" +
            $"Alex with average grade 3.00";

        //Act
        string result = Grades.GetBestStudents(students);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetBestStudents_SameGrade_ReturnsInAlphabeticalOrder()
    {
        // Arrange
        Dictionary<string, int> students = new Dictionary<string, int>();
        students["Boris"] = 6;
        students["Alex"] = 6;
        students["Mira"] = 6;
        students["Dimo"] = 6;

        string expected = $"Alex with average grade 6.00{Environment.NewLine}" +
            $"Boris with average grade 6.00{Environment.NewLine}" +
            $"Dimo with average grade 6.00";
            

        //Act
        string result = Grades.GetBestStudents(students);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
