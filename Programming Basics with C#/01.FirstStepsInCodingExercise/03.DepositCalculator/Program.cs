using System;

namespace _03.DepositCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            decimal amountDeposited = decimal.Parse(Console.ReadLine());
            int termForDeposit = int.Parse(Console.ReadLine());
            decimal annualInterestRate = decimal.Parse(Console.ReadLine());
            annualInterestRate = annualInterestRate / 100;
            decimal totalSum = amountDeposited + termForDeposit *
                                ((amountDeposited * annualInterestRate) / 12);
            Console.WriteLine(totalSum);
        }
    }
}
