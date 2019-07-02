using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRAMMING_ASSIGNMENT_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //declare the accounts
            SavingsAccount acount1 = new SavingsAccount(1000, "Schultz-Saving-1", 1, .04);
            SavingsAccount acount2 = new SavingsAccount(2000, "Schultz-Saving-2", 2, .05);
            CheckingAccount acount3 = new CheckingAccount(3000, "Schultz-Checking-1", 3, 3);
            CheckingAccount acount4 = new CheckingAccount(4000, "Schultz-Checking-2", 4, 4);

            Account[] arrays = { acount1, acount2, acount3, acount4 };//put accounts in array

            foreach (Account thing in arrays)//loop for each account
            {
                Ln(); br(); br(); Ln();//line separator 

                Console.WriteLine("Initial Information for: " + thing.getAccountName());
                thing.printAccount();//print account

                Ln(); br(); Ln();//line separator 

                Console.WriteLine("specify an amount of money to withdraw from " + thing.getAccountName());
                thing.debit(Convert.ToInt32(Console.ReadLine()));//with draw money from account
                Console.WriteLine("Information after withdraw for: " + thing.getAccountName());
                thing.printAccount();//print account

                Ln(); br(); Ln();//line separator 

                Console.WriteLine("specify an amount of money to deposit in " + thing.getAccountName());
                thing.credit(Convert.ToInt32(Console.ReadLine()));//deposit money in account 
                Console.WriteLine("Information after deposit for: " + thing.getAccountName());
                thing.printAccount();//print account

                if (thing.GetType().Name == SavingsAccount.GetType())//if savings account   originally i had (thing.GetType().Name == "SavingsAccount") i didn't like this so i made a method in SavingsAccount to return its type. is there a better way to do this?
                {
                    Ln(); br(); Ln();//line separator 

                    SavingsAccount savingsThing = (SavingsAccount)thing;//cast account as savings account 

                    savingsThing.CalculateInterest();//calculate interest 
                    Console.WriteLine("Information after interest calculation for: " + savingsThing.getAccountName());
                    savingsThing.printAccount();//print account
                }
                Ln();
            }

            Console.Write("press enter to continue");
            Console.ReadLine();
        }

        //simple printing methods 
        public static void br()
        {
            Console.WriteLine("**************************************************************");
        }
        public static void Ln()
        {
            Console.WriteLine();
        }

    }

    class Account
    {
        //instance variables 
        private double balance;
        private string accountName;
        private int accountNumber;

        //mutator methods 
        public void setBalance(double balance)
        {
            if (balance >= 0)//if balance is positive
            {
                this.balance = balance;//assign balance 
            }
            else//other wise 
            {
                this.balance = 0;//assign zero
            }
        }
        public void setAccountName(string accountName)
        {
            this.accountName = accountName;
        }
        public void setAccountNumber(int accountNumber)
        {
            this.accountNumber = accountNumber;
        }

        //accessor methods
        public double getBalance()
        {
            return balance;
        }
        public string getAccountName()
        {
            return accountName;
        }
        public int getAccountNumber()
        {
            return accountNumber;
        }

        //constructor methods
        public Account(double balance, string accountName, int accountNumber)
        {
            setBalance(balance);
            setAccountName(accountName);
            setAccountNumber(accountNumber);
        }

        //class methods 
        virtual public void credit(double amount)
        {
            setBalance(amount + getBalance());// set the balance to the amount plus the existing balance 
        }
        virtual public bool debit(double amount)
        {
            if (amount <= getBalance())//if the amount is less than or equal to the balance 
            {
                setBalance(getBalance() - amount);//set the balance to current balance minus the amount 
                return true;//also return true
            }
            else//other wise
            {
                Console.WriteLine("Insufficient Funds");//print Insufficient Funds
                return false;//and return false 
            }
        }
        virtual public void printAccount()
        {
            Console.WriteLine("account name: " + getAccountName() + "\naccount number: " + getAccountNumber() + "\nbalance: " + getBalance());
        }

    }

    class SavingsAccount : Account
    {
        //instance variables 
        private double interestRate;

        //mutator methods
        public void setInterestRate(double interestRate)
        {
            if (interestRate > 0)//if the interest rate is above zero 
            {
                this.interestRate = interestRate;//assign it
            }
            else//other wise
            {
                this.interestRate = 0;//assign it to zero
            }
        }

        //accessor methods
        public static string GetType()
        {
            return "SavingsAccount"; 
        }
        /*public static Type GetType()
        {
            return SavingsAccount;//this says that a type isn't valid here, it is possible to make this method return the type SavingsAccount so that i don't need to make the .Name conversion in the main program? 
        }*/
        public double getInterestRate()
        {
            return interestRate;
        }

        //constructor methods
        public SavingsAccount(double balance, string accountName, int accountNumber, double interestRate) : base(balance, accountName, accountNumber)
        {
            setInterestRate(interestRate);
        }

        //class methods
        public void CalculateInterest()
        {
            credit(getBalance() * getInterestRate());//credit the account with the balance time the interest rate 
        }
        override public void printAccount()
        {
            base.printAccount();
            Console.WriteLine("interest rate: " + getInterestRate());
        }
    }

    class CheckingAccount : Account
    {
        //instance variables
        private double feeCharged;

        //mutator methods
        public void setFeeCharged(double feeCharged)
        {
            if (feeCharged < 0)//if the fee is negative 
            {
                this.feeCharged = 0;//assign it to zero
            }
            else//other wise
            {
                this.feeCharged = feeCharged;//assign the fee
            }
        }

        //accessor methods
        public double getFeeCharged()
        {
            return feeCharged;
        }

        //constructor methods
        public CheckingAccount(double balance, string accountName, int accountNumber, double feeCharged) : base(balance, accountName, accountNumber)
        {
            setFeeCharged(feeCharged);
        }

        //class methods 
        override public void credit(double amount)
        {
            base.credit(amount - getFeeCharged());//use the base credit method with the amount plus the fee
        }
        override public bool debit(double amount)
        {
            if (base.debit(amount + getFeeCharged()) == true)//use the base method to determine if the transaction is possible (this also runs the transaction)
            {
                return true;//if the funds are available return true
            }
            else//other wise
            {
                return false;//return false 
            }
        }
        override public void printAccount()
        {
            base.printAccount();
            Console.WriteLine("fee charged: " + getFeeCharged());
        }
    }
}