using System.Collections;
using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class DictionaryIntersectionTests
{
    [Test]
    public void Test_Intersect_TwoEmptyDictionaries_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dictionaryOne = new Dictionary<string, int>();
        Dictionary<string, int> dictionaryTwo = new Dictionary<string, int>();

        //Act
       Dictionary<string, int> result = DictionaryIntersection.Intersect(dictionaryOne, dictionaryTwo);

        //Assert
        Assert.That(result, Has.Count.EqualTo(0));
    }

    [Test]
    public void Test_Intersect_OneEmptyDictionaryAndOneNonEmptyDictionary_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dictionaryOne = new Dictionary<string, int>
        {
            ["asdf"] = 1,
            ["qazxx"] = 3,
            ["poiu"] = 54,
            ["try"] = 12
        };

        

        Dictionary<string, int> dictionaryTwo = new Dictionary<string, int>();

        //Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dictionaryOne, dictionaryTwo);

        //Assert
        CollectionAssert.IsEmpty(result);

    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithNoCommonKeys_ReturnsEmptyDictionary()
    {
        Dictionary<string, int> dictionaryOne = new Dictionary<string, int>
        {
            ["asdf"] = 1,
            ["qazxx"] = 3,
            ["poiu"] = 54,
            ["try"] = 12
        };

        Dictionary<string, int> dictionaryTwo = new Dictionary<string, int>
        {
            ["koi"] = 0,
            ["pmol"] = -3,
        };

        //Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dictionaryOne, dictionaryTwo);

        //Assert
        CollectionAssert.IsEmpty(result);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndValues_ReturnsIntersectionDictionary()
    {
        Dictionary<string, int> dictionaryOne = new Dictionary<string, int>
        {
            ["asdf"] = 1,
            ["qazxx"] = 3,
            ["poiu"] = 54,
            ["try"] = 12
        };

        Dictionary<string, int> dictionaryTwo = new Dictionary<string, int>
        {
            ["koi"] = 0,
            ["poiu"] = 54,
            ["pmol"] = -3,
            ["qazxx"] = 3,
        };

        Dictionary<string, int> expected = new Dictionary<string, int>
        {
            ["qazxx"] = 3,
            ["poiu"] = 54,
        };

        //Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dictionaryOne, dictionaryTwo);

        //Assert
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndDifferentValues_ReturnsEmptyDictionary()
    {
        Dictionary<string, int> dictionaryOne = new Dictionary<string, int>
        {
            ["asdf"] = 1,
            ["qazxx"] = 13,
            ["poiu"] = 4,
            ["try"] = 12
        };

        Dictionary<string, int> dictionaryTwo = new Dictionary<string, int>
        {
            ["koi"] = 0,
            ["poiu"] = 54,
            ["pmol"] = -3,
            ["qazxx"] = 3,
        };

        //Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dictionaryOne, dictionaryTwo);

        //Assert
        CollectionAssert.IsEmpty(result);
    }
}
