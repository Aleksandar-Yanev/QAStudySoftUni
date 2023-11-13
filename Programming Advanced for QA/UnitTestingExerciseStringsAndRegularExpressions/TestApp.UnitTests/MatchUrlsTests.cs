using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class MatchUrlsTests
{
    // TODO: finish the test
    [Test]
    public void Test_ExtractUrls_EmptyText_ReturnsEmptyList()
    {
        // Arrange
        string text = "";
        List <string> expected = new List<string> ();

        // Act
        List <string> result = MatchUrls.ExtractUrls(text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // TODO: finish the test
    [Test]
    public void Test_ExtractUrls_NoUrlsInText_ReturnsEmptyList()
    {
        // Arrange
        string text = "alabala, www.kom.@com";
        //List<string> expected = new List<string> { "" };

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        //Assert.That(result, Is.EqualTo(expected));
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_ExtractUrls_SingleUrlInText_ReturnsSingleUrl()
    {
        // Arrange
        string text = "https://judge.softuni.org/ some text here, and more text.";
        List<string> expected = new List<string> { "https://judge.softuni.org" };

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ExtractUrls_MultipleUrlsInText_ReturnsAllUrls()
    {
        // Arrange
        string text = "https://judge.softuni.org/ some text here, and more text. http://www.bikepost.ru/my/Moto_Katrina/";
        List<string> expected = new List<string> { "https://judge.softuni.org", "http://www.bikepost.ru" };

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ExtractUrls_UrlsInQuotationMarks_ReturnsUrlsInQuotationMarks()
    {
        // Arrange
        string text = "\"https://judge.softuni.org/forus\" some text here, and more text.";
        List<string> expected = new List<string> { "https://judge.softuni.org" };

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
