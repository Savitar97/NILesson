using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class BankAccount
    {
        public string CustomerName { get; }

        //private set csak a mi osztályunk változtathatja az értéket
        public int Balance { get;private set; }

        public BankAccount(string customerName, int balance)
        {
            if (string.IsNullOrWhiteSpace(customerName))
            {
                throw new ArgumentException($"'{nameof(customerName)}' cannot be null or whitespace", nameof(customerName));
            }

            CustomerName = customerName;
            if(balance<0)
            { 
                throw new ArgumentOutOfRangeException(nameof(balance));
            }
            Balance = balance;
        }

        public void deposit(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }
            Balance += amount;
        }

        public void withdraw(int amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentOutOfRangeException(nameof(Balance));
            }  
            Balance -= amount;
        }
    }
}
