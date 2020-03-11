using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TDDBank.Tests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void BankAccount_new_account_has_0_as_balance()
        {
            var ba = new BankAccount();

            Assert.AreEqual(0m, ba.Balance);
        }

        [TestMethod]
        public void BankAccount_can_deposit()
        {
            var ba = new BankAccount();

            ba.Deposit(3m);
            Assert.AreEqual(3m, ba.Balance);
            ba.Deposit(4m);
            Assert.AreEqual(7m, ba.Balance);
        }

        [TestMethod]
        public void BankAccount_deposit_negative_value_throws()
        {
            var ba = new BankAccount();

            Assert.ThrowsException<ArgumentException>(() => ba.Deposit(-5m));
            Assert.ThrowsException<ArgumentException>(() => ba.Deposit(0m));
        }

        [TestMethod]
        public void BankAccount_can_withdraw()
        {
            var ba = new BankAccount();

            ba.Deposit(20m);
            Assert.AreEqual(20m, ba.Balance);
            ba.Withdraw(8m);
            Assert.AreEqual(12m, ba.Balance);
            ba.Withdraw(5m);
            Assert.AreEqual(7m, ba.Balance);
        }

        [TestMethod]
        public void BankAccount_withdraw_negative_value_throws()
        {
            var ba = new BankAccount();

            Assert.ThrowsException<ArgumentException>(() => ba.Withdraw(-5m));
            Assert.ThrowsException<ArgumentException>(() => ba.Withdraw(0m));
        }

        [TestMethod]
        public void BankAccount_withdraw_below_balance_throws()
        {
            var ba = new BankAccount();
            ba.Deposit(20m);
            Assert.ThrowsException<InvalidOperationException>(() => ba.Withdraw(30m));
        }

    }
}
