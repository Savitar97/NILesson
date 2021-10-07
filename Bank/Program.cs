using System;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello World!");
                var account = new BankAccount("Mr. Teszt", 20);
                account.deposit(20);
                Console.WriteLine($"Actual balance:{account.Balance}");
                account.withdraw(10);
                Console.WriteLine($"Actual balance:{account.Balance}");
            }
            catch (Exception ex)
            {

            }
        }
    }
}
