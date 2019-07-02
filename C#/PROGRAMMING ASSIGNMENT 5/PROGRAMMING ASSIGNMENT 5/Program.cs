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
            SavingsAccount acount1 = new SavingsAccount(1000, "Schultz-Saving-1", 1, .04);
            SavingsAccount acount2 = new SavingsAccount(2000, "Schultz-Saving-2", 2, .05);
            CheckingAccount acount3 = new CheckingAccount(3000, "Schultz-Checking-1", 3, 3);
            CheckingAccount acount4 = new CheckingAccount(4000, "Schultz-Checking-2", 4, 4);

            Account[] arrays = {acount1, acount2, acount3, acount4};

            foreach (Account thing in arrays)
            {
                if (thing.GetType().Name == "SavingsAccount")
                {
                    SavingsAccount savingsThing = (SavingsAccount)thing;

                    Ln();
                    br();
                    br();
                    Ln();

                    Console.WriteLine("Initial Information for: " + savingsThing.getAccountName());
                    savingsThing.printAccount();

                    Ln();
                    br();
                    Ln();

                    Console.WriteLine("specify an amount of money to withdraw from " + savingsThing.getAccountName());
                    savingsThing.debit(Convert.ToInt32(Console.ReadLine()));
                    Console.WriteLine("Information after withdraw for: " + savingsThing.getAccountName());
                    savingsThing.printAccount();

                    Ln();
                    br();
                    Ln();

                    Console.WriteLine("specify an amount of money to deposit in " + savingsThing.getAccountName());
                    savingsThing.credit(Convert.ToInt32(Console.ReadLine()));
                    Console.WriteLine("Information after deposit for: " + savingsThing.getAccountName());
                    savingsThing.printAccount();

                    Ln();
                    br();
                    Ln();

                    savingsThing.CalculateInterest();
                    Console.WriteLine("Information after interest calculation for: " + savingsThing.getAccountName());
                    savingsThing.printAccount();
                }
                else if (thing.GetType().Name == "CheckingAccount")
                {
                    CheckingAccount checkingThing = (CheckingAccount)thing;

                    Ln();
                    br();
                    br();
                    Ln();

                    Console.WriteLine("Initial Information for: " + checkingThing.getAccountName());
                    checkingThing.printAccount();

                    Ln();
                    br();
                    Ln();

                    Console.WriteLine("specify an amount of money to withdraw from " + checkingThing.getAccountName());
                    checkingThing.debit(Convert.ToInt32(Console.ReadLine()));
                    Console.WriteLine("Information after withdraw for: " + checkingThing.getAccountName());
                    checkingThing.printAccount();

                    Ln();
                    br();
                    Ln();

                    Console.WriteLine("specify an amount of money to deposit in " + checkingThing.getAccountName());
                    checkingThing.credit(Convert.ToInt32(Console.ReadLine()));
                    Console.WriteLine("Information after deposit for: " + checkingThing.getAccountName());
                    checkingThing.printAccount();
                }
                Ln();
            }
            /*
            Console.WriteLine("Created checking account with $1,000 balance.");
            CheckingAccount CheckingAccount1 = new CheckingAccount(1000, "SchultzChecking", 1, 3);//step 1
            //Console.WriteLine("Created checking account: " + CheckingAccount1.getAccountName() + " with $" + CheckingAccount1.getBalance() + " balance.");
            Console.WriteLine();

            Console.WriteLine("Created savings account with $2,000 balance.");
            SavingsAccount SavingsAccount1 = new SavingsAccount(2000, "SchultzSaving", 2, .05);//step 2
            //Console.WriteLine("Created checking account: " + SavingsAccount1.getAccountName() + " with $" + SavingsAccount1.getBalance() + " balance.");
            Console.WriteLine();

            CheckingAccount1.printAccount();//step 3
            Console.WriteLine();
            SavingsAccount1.printAccount();//step 4
            Console.WriteLine();

            Console.WriteLine("Deposit $100 into checking.");
            CheckingAccount1.credit(100);//step 5
            CheckingAccount1.printAccount();//step 6
            Console.WriteLine();

            Console.WriteLine("Withdraw $50 from checking.");
            CheckingAccount1.debit(50);//step 7
            CheckingAccount1.printAccount();//step 8
            Console.WriteLine();

            Console.WriteLine("Withdraw $6,000 from checking.");
            CheckingAccount1.debit(6000);//step 9
            CheckingAccount1.printAccount();//step 10
            Console.WriteLine();

            Console.WriteLine("Deposit $3,000 into savings.");
            SavingsAccount1.credit(3000);//step 11
            SavingsAccount1.printAccount();//step 12
            Console.WriteLine();

            Console.WriteLine("Withdraw $200 from savings.");
            SavingsAccount1.debit(200);//setp 13
            SavingsAccount1.printAccount();//step 14
            Console.WriteLine();

            Console.WriteLine("Calculate Interest on savings.");
            SavingsAccount1.CalculateInterest();//setp 15
            SavingsAccount1.printAccount();//step 16
            Console.WriteLine();

            Console.WriteLine("Withdraw $10,000 from savings.");
            SavingsAccount1.debit(10000);//setp 17
            SavingsAccount1.printAccount();//step 18
            Console.WriteLine();
            */

            Console.Write("press enter to continue");
            Console.ReadLine();

        }

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
        public void credit(double amount)
        {
            setBalance(amount + getBalance());// set the balance to the amount plus the existing balance 
        }
        public bool debit(double amount)
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
        public void printAccount()
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
        public void printAccount()
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
        public void credit(double amount)
        {
            base.credit(amount - getFeeCharged());//use the base credit method with the amount plus the fee
        }
        public bool debit(double amount)
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
        public void printAccount()
        {
            base.printAccount();
            Console.WriteLine("fee charged: " + getFeeCharged());
        }
    }
}
