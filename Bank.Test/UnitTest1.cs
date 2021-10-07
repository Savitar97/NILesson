using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Bank.Test
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Deposit_WithValidAmount_ExceptedBalance()
        {
            //Arrange
            var account = new BankAccount("Teszt",20);

            //Act
            account.deposit(10);
            //Assert
            Assert.AreEqual(30,account.Balance,"Different than the excepted value.");
        }

        [TestMethod]
        public void Deposit_WithInvalidAmount_ArgumentOutOfRangeException()
        {
            //Arrange
            var account = new BankAccount("Teszt", 20);
            //Act + Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.deposit(-10));
            //()=> új fv kesz paraméter nélkül ami meghív egy actiont
        }

     
        [DataRow(10,10)]
        [DataRow(5,15)]
        [DataTestMethod]
        public void Withdraw_WithValidAmount_ExceptedBalance(int exceptedBalance,int amount)
        {
            //Arrange
            var account = new BankAccount("Teszt", 20);

            //Act
            account.withdraw(amount);
            //Act + Assert
            Assert.AreEqual(exceptedBalance, account.Balance, "Different than the excepted value.");
        }

        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        [DataTestMethod]
        public void Ctor_InvalidArguments_ArgumentException(string customerName)
        {
            //Arrange
            //Act
            //Assert
            Assert.ThrowsException<ArgumentException>(() => new BankAccount(customerName,20));
        }
    }
}
