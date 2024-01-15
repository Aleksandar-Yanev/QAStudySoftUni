using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class TextFilterTests
{
    // TODO: finish the test
    [Test]
    public void Test_Filter_WhenNoBannedWords_ShouldReturnOriginalText()
    {
        // Arrange
        string[] bannedWords = new string [] {"abrakadabra" };
        string text = "The quick brown fox jumps over the lazy dog";
        string expected = "The quick brown fox jumps over the lazy dog";

        // Act
        string result = TextFilter.Filter(bannedWords, text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Filter_WhenBannedWordExists_ShouldReplaceBannedWordWithAsterisks()
    {
        // Arrange
        string[] bannedWords = new string[] { "quick" };
        string text = "The quick brown fox jumps over the lazy dog";
        string expected = "The ***** brown fox jumps over the lazy dog";

        // Act
        string result = TextFilter.Filter(bannedWords, text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Filter_WhenBannedWordsAreEmpty_ShouldReturnOriginalText()
    {
        string[] bannedWords = Array.Empty<string>();
        string text = "The quick brown fox jumps over the lazy dog";
        string expected = "The quick brown fox jumps over the lazy dog";

        // Act
        string result = TextFilter.Filter(bannedWords, text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Filter_WhenBannedWordsContainWhitespace_ShouldReplaceBannedWord()
    {
        string[] bannedWords = new string[] { "brown fox", "lazy" };
        string text = "The quick brown fox jumps over the lazy dog";
        string expected = "The quick ********* jumps over the **** dog";

        // Act
        string result = TextFilter.Filter(bannedWords, text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
