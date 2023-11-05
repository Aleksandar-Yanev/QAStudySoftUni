using NUnit.Framework;
using System;

namespace TestApp.Tests;

public class CharacterRangeTests
{
    [Test]
    public void Test_GetRange_WithAAndBInOrder_ReturnsEmptyString()
    {
        char input1 = 'A';
        char input2 = 'B';
        string exspected = "";

        string output = CharacterRange.GetRange(input1, input2);

        Assert.That(output, Is.EqualTo(exspected));
    }

    [Test]
    public void Test_GetRange_WithBAndAInOrder_ReturnsEmptyString()
    {
        char input1 = 'B';
        char input2 = 'A';
        string exspected = "";

        string output = CharacterRange.GetRange(input1, input2);

        Assert.That(output, Is.EqualTo(exspected));
    }

    [Test]
    public void Test_GetRange_WithAAndCInOrder_ReturnsB()
    {
        char input1 = 'A';
        char input2 = 'C';
        string exspected = "B";

        string output = CharacterRange.GetRange(input1, input2);

        Assert.That(output, Is.EqualTo(exspected));
    }

    [Test]
    public void Test_GetRange_WithDAndGInOrder_Returns_E_F()
    {
        char input1 = 'a';
        char input2 = 'g';
        string exspected = "b c d e f";

        string output = CharacterRange.GetRange(input1, input2);

        Assert.That(output, Is.EqualTo(exspected));
    }

    [Test]
    public void Test_GetRange_WithXAndZInOrder_Returns_Y()
    {
        char input1 = 'A';
        char input2 = 'Z';
        string exspected = "B C D E F G H I J K L M N O P Q R S T U V W X Y";

        string output = CharacterRange.GetRange(input1, input2);

        Assert.That(output, Is.EqualTo(exspected));
    }

    [Test]
    public void Test_GetRange_WithXAndZInOrder_Returns_Y1()
    {
        char input1 = 'A';
        char input2 = 'z';
        string exspected = "B C D E F G H I J K L M N O P Q R S T U V W X Y Z [ \\ ] ^ _ ` a b c d e f g h i j k l m n o p q r s t u v w x y";

        string output = CharacterRange.GetRange(input1, input2);

        Assert.That(output, Is.EqualTo(exspected));
    }

    [Test]
    public void Test_GetRange_WithXAndZInOrder_Returns_Y2()
    {
        char input1 = 'a';
        char input2 = 'Z';
        string exspected = "[ \\ ] ^ _ `";

        string output = CharacterRange.GetRange(input1, input2);

        Assert.That(output, Is.EqualTo(exspected));
    }

    [Test]
    public void Test_GetRange_WithXAndZInOrder_Returns_Y3()
    {
        char input1 = '#';
        char input2 = ':';
        string exspected = "$ % & ' ( ) * + , - . / 0 1 2 3 4 5 6 7 8 9";

        string output = CharacterRange.GetRange(input1, input2);

        Assert.That(output, Is.EqualTo(exspected));
    }

    [Test]
    public void Test_GetRange_WithXAndZInOrder_Returns_Y4()
    {
        char input1 = 'C';
        char input2 = '#';
        string exspected = "$ % & ' ( ) * + , - . / 0 1 2 3 4 5 6 7 8 9 : ; < = > ? @ A B";

        string output = CharacterRange.GetRange(input1, input2);

        Assert.That(output, Is.EqualTo(exspected));
    }
}
