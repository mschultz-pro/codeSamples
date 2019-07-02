using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRAMMING_ASSIGNMENT_4
{
    class SavingsAccountTest
    {
        static void Main(string[] args)
        {
            //initialize objects 
            SavingsAccount saver1 = new SavingsAccount("Saver_One", 2000);
            SavingsAccount saver2 = new SavingsAccount("Saver_Two", 3000);
            SavingsAccount saver3 = new SavingsAccount();

            //set interest rate
            SavingsAccount.setAnnualInterestRate(.04);

            //assign saves 3 with a name and balance 
            saver3.setSavingsAccountName("Saver_Three");
            saver3.setSavingsBalance(50000);

            //print out accounts 
            Console.WriteLine("initial savings account balances:");
            saver1.PrintSavingsAccount();
            saver2.PrintSavingsAccount();
            saver3.PrintSavingsAccount();
            Console.WriteLine();

            //calculate interest 
            saver1.CalculateMonthlyInterest();
            saver2.CalculateMonthlyInterest();
            saver3.CalculateMonthlyInterest();

            //print out accounts 
            Console.WriteLine("Savings account balance after calculating monthly interest at " + SavingsAccount.getAnnualInterestRate()*100 + "%:");
            saver1.PrintSavingsAccount();
            saver2.PrintSavingsAccount();
            saver3.PrintSavingsAccount();
            Console.WriteLine();

            //change interest rate
            SavingsAccount.setAnnualInterestRate(.05);

            //print out accounts 
            Console.WriteLine("directions are unclear here, are the accounts with interest rate changed to " + SavingsAccount.getAnnualInterestRate() * 100 + "% but not calculated"); 
            Console.WriteLine("Savings account balance after calculating monthly interest at " + SavingsAccount.getAnnualInterestRate() * 100 + "%:");
            saver1.PrintSavingsAccount();
            saver2.PrintSavingsAccount();
            saver3.PrintSavingsAccount();
            Console.WriteLine();

            //calculate interest 
            saver1.CalculateMonthlyInterest();
            saver2.CalculateMonthlyInterest();
            saver3.CalculateMonthlyInterest();

            //print out accounts 
            Console.WriteLine("directions are unclear, here are the accounts with a second month of interest calculated at " + SavingsAccount.getAnnualInterestRate() * 100 + "%");
            Console.WriteLine("Savings account balance after calculating monthly interest at " + SavingsAccount.getAnnualInterestRate() * 100 + "%:");
            saver1.PrintSavingsAccount();
            saver2.PrintSavingsAccount();
            saver3.PrintSavingsAccount();
            Console.WriteLine();

            Console.Write("press enter to continue");
            Console.ReadLine();
        }
    }
    
    class SavingsAccount
    {
        //class and instance variables 
        static double annualInterestRate;
        private double savingsBalance;
        private string savingsAccountName;

        //mutator methods 
        public void setSavingsAccountName(string name)
        {
            savingsAccountName = name;
        }
        public void setSavingsBalance(double balance)
        {
            savingsBalance = balance;
        }
        public static void setAnnualInterestRate(double rate)
        {
            annualInterestRate = rate;
        }

        //accessor methods
        public string getSavingsAccountName()
        {
            return savingsAccountName;
        }
        public double getSavingsBalance()
        {
            return savingsBalance;
        }
        public static double getAnnualInterestRate()
        {
            return annualInterestRate;
        }

        //constructor methods
        public SavingsAccount()
        {
            setSavingsBalance(0);
            setSavingsAccountName("");
        }
        public SavingsAccount(string name, double balance)
        {
            setSavingsBalance(balance);
            setSavingsAccountName(name);
        }

        public void CalculateMonthlyInterest()
        {
            double MonthlyInterest = getAnnualInterestRate() * getSavingsBalance() / 12;
            setSavingsBalance(MonthlyInterest + getSavingsBalance());
            //setSavingsBalance(getSavingsBalance() + getAnnualInterestRate() * getSavingsBalance() / 12);
        }

        public void PrintSavingsAccount()
        {
            string tab = "   ";
            Console.WriteLine(getSavingsAccountName() + tab + getSavingsBalance() + tab + getAnnualInterestRate());
        }
    }
}
