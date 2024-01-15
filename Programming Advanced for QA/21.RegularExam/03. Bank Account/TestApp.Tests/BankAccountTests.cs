using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class BankAccountTests
{
    [Test]
    public void Test_Constructor_InitialBalanceIsSet()
    {
        // Arrange
        double initialBalanse = 20.5;

        //Act
        BankAccount bankAccount = new BankAccount(initialBalanse);
        double balance = bankAccount.Balance;

        //Assert
        Assert.That(balance, Is.EqualTo(initialBalanse));
    }

    [Test]
    public void Test_Deposit_PositiveAmount_IncreasesBalance()
    {
        // Arrange
        double initialBalanse = 0;
        double amount = 5.0;
        double expected = initialBalanse + amount;

        //Act
        BankAccount bankAccount = new BankAccount(initialBalanse);
        bankAccount.Deposit(amount);
        double balance = bankAccount.Balance;

        //Assert
        Assert.That(balance, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Deposit_NegativeAmount_ThrowsArgumentException()
    {
        // Arrange
        double initialBalanse = 20.5;
        double amount = -5.0;       

        BankAccount bankAccount = new BankAccount(initialBalanse);

        //Act & Assert
        Assert.That(() => bankAccount.Deposit(amount), Throws.ArgumentException.With.Message.Contains("Deposit amount must be greater than zero."));
    }

    [Test]
    public void Test_Withdraw_ValidAmount_DecreasesBalance()
    {
        // Arrange
        double initialBalanse = 20.5;
        double amount = 5.0;
        double expected = initialBalanse - amount;

        //Act
        BankAccount bankAccount = new BankAccount(initialBalanse);
        bankAccount.Withdraw(amount);
        double balance = bankAccount.Balance;

        //Assert
        Assert.That(balance, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Withdraw_NegativeAmount_ThrowsArgumentException()
    {
        // Arrange
        double initialBalanse = 20.5;
        double amount = -5.0;
        BankAccount bankAccount = new BankAccount(initialBalanse);

        //Act & Assert
        Assert.That(() => bankAccount.Withdraw(amount), Throws.ArgumentException.With.Message.Contains("Invalid withdrawal amount."));
    }

    [Test]
    public void Test_Withdraw_AmountGreaterThanBalance_ThrowsArgumentException()
    {
        // Arrange
        double initialBalanse = 18.30;
        double amount = 25.0;
        BankAccount bankAccount = new BankAccount(initialBalanse);

        //Act & Assert
        Assert.That(() => bankAccount.Withdraw(amount), Throws.ArgumentException.With.Message.Contains("Invalid withdrawal amount."));
    }
}
