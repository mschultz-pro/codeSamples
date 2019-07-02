using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRAMMING_ASSIGNMENT_7
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueLoop = true;// bool for checking if user wants to keep creating accounts
            int aNumber = 1;// int to number accounts
            var accountDictionary = new Dictionary<string, Account>();// dictionary to store accounts created

            do// do while loop
            {
                try//test for errors 
                {
                    switch (menu().ToLower())//print menu, switch based on user choice convert to lower case for ease of use
                    {
                        case "c"://if user wants checking
                            {
                                Console.Write("Enter a name for the account: ");//get user input for name 
                                string name = Console.ReadLine(); Ln();

                                Console.Write("Enter an initial balance for the account: ");//get user input for initial balance
                                double iBalance = Convert.ToDouble(Console.ReadLine()); Ln();

                                Console.Write("Enter a fee to be changed per transaction: ");//get user input for fee
                                double fee = Convert.ToDouble(Console.ReadLine()); Ln();

                                accountDictionary.Add(name + aNumber, new CheckingAccount(iBalance, name, aNumber, fee));//create account and store in accountDictionary
                                aNumber = aNumber + 1;//increment aNumber, i didn't ask the user for aNumber because the user doesn't need to worry about that 

                                break;
                            }
                        case "s"://if user wants savings 
                            {
                                Console.Write("Enter a name for the account: ");//get user input for name 
                                string name = Console.ReadLine(); Ln();

                                Console.Write("Enter an initial balance for the account: ");//get user input for initial balance
                                double iBalance = Convert.ToDouble(Console.ReadLine()); Ln();

                                Console.Write("Enter an interest rate for the account: ");//get user input for interest rate
                                double rate = Convert.ToDouble(Console.ReadLine()); Ln();

                                accountDictionary.Add(name + aNumber, new SavingsAccount(iBalance, name, aNumber, rate));//create account and store in accountDictionary
                                aNumber = aNumber + 1;//increment aNumber, i didn't ask the user for aNumber because the user doesn't need to worry about that 

                                break;
                            }
                        case "q"://if user wants to quit 
                            {
                                continueLoop = false;//change bool to allow loop to end 
                                break;
                            }
                        default://if no valid choice is given 
                            {
                                Console.WriteLine("Please enter a valid account choice"); Ln();//ask for valid choice 
                                break; 
                            }
                    }
                }
                catch (FormatException formatException)//used for potential invalid input IE letters in doubles or ints 
                {//this is a system method 
                    Ln(); br(); Ln();
                    Console.WriteLine(formatException.Message);
                    Console.WriteLine("Please use a valid input type.");//ask for valid input 
                    Ln(); br(); Ln();
                }
                catch (NegativeNumberException negativeNumberException)//if negative number error is given 
                {//this is a custom method 
                    Ln(); br(); Ln();
                    Console.WriteLine(negativeNumberException.Message);
                    Console.WriteLine("Please enter a non-negative value.");//ask for a positive number 
                    Ln(); br(); Ln();
                }
            } while (continueLoop);//test if loop should continue 

            if (accountDictionary.Count() > 0)//if the accountDictionary contains any items 
            {
                foreach (var account in accountDictionary)//loop through accountDictionary
                {
                    Account Thing = (Account)account.Value;//cast as account
                    Thing.printAccount(); Ln(); br(); Ln();//print account 
                }
            }
            else Console.WriteLine("No accounts created");//if accountDictionary is empty

            Console.Write("press enter to continue");//tell user 
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
        public static string menu()
        {
            br();
            Console.WriteLine("Create checking account \"C\"");//print choices 
            Console.WriteLine("Create savings account \"S\"");
            Console.WriteLine("Quit the application \"Q\"");
            br(); Ln();
            Console.Write("Please enter a choice: ");//ask for user input 
            string choice = Console.ReadLine(); Ln(); br(); Ln();
            return choice;
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
                throw new NegativeNumberException("Invalid Entry – Negative numbers are not permitted.");
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
                throw new NegativeNumberException("Invalid Entry – Negative numbers are not permitted.");
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
            Console.WriteLine("Account type: Savings");
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
                throw new NegativeNumberException("Invalid Entry – Negative numbers are not permitted.");
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
            Console.WriteLine("Account type: Checking");
            base.printAccount();
            Console.WriteLine("fee charged: " + getFeeCharged());
        }
    }

    class NegativeNumberException : Exception
    {
        //constructor method
        public NegativeNumberException(string error) : base(error)
        {
        }
    }
}