using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROGRAMMING_ASSIGNMENT_8
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new timeKeepingLogin());

        }
    }
    class Clients
    {
        static string[] clientNames = { "BritishMobile", "FranceMobile", "IBC", "MTM", "BritainTele" };

        public static void setClients(string[] names)
        {
            clientNames = names;
        }
        public static string[] getClients()
        {
            return clientNames;
        }
        public static string getClient(int client)
        {
            return clientNames[client];
        }
        public static void addClient(string name)
        {
            string[] temp = new string[clientNames.Count() + 1];
            for (int i = 0; i <= clientNames.Count(); i++)
            {
                if (i < clientNames.Count())
                {
                    temp[i] = clientNames[i];
                }
                temp[i] = name;
            }
            setClients(temp);
        }
    }
    class Weekdays
    {
        static string[] weekdays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        public static void setDays(string[] days)
        {
            weekdays = days;
        }
        public static string[] getDays()
        {
            return weekdays;
        }
        public static string getDay(int day)
        {
            return weekdays[day];
        }
    }
    class Employee
    {
        //instance variables 
        private string name;
        private string supervisorName;
        private double payRate;
        private int levelID;

        //mutator methods 
        public void setName(string name)
        {
            if (name == null || name == "")
                throw new StringValidationException("Please enter a employee name");
            else
                this.name = name;
        }
        public void setSupervisorName(string supervisorName)
        {
            if (supervisorName == null || name == "")
                throw new StringValidationException("Please enter a supervisor name");
            else
                this.supervisorName = supervisorName;
        }
        public void setPayRate(double payRate)
        {
            if (this.payRate >= 0)
            {
                this.payRate = payRate;
            }
            else throw new NegativeNumberException("Invalid Entry – Negative numbers are not permitted.");
        }
        public void setLevelID(int levelID)
        {
            if (this.payRate >= 0)
            {
                this.levelID = levelID;
            }
            else throw new NegativeNumberException("Invalid Entry – Negative numbers are not permitted.");
        }

        //accessor methods
        public string getName()
        {
            return name;
        }
        public string getSupervisorName()
        {
            return supervisorName;
        }
        public double getPayRate()
        {
            return payRate;
        }
        public int getLevelID()
        {
            return levelID;
        }

        //constructor methods
        public Employee(string name, string supervisorName)
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 3);

            setName(name);
            setSupervisorName(supervisorName);
            setPayRate(15);
            setLevelID(randomNumber);
        }
        public Employee(string name, string supervisorName, int levelID)
        {
            setName(name);
            setSupervisorName(supervisorName);
            setPayRate(15);
            setLevelID(levelID);
        }
        public Employee(string name, string supervisorName, double payRate, int levelID)
        {
            setName(name);
            setSupervisorName(supervisorName);
            setPayRate(payRate);
            setLevelID(levelID);
        }
    }
    class NegativeNumberException : Exception
    {
        //constructor method
        public NegativeNumberException(string error) : base(error)
        {
        }
    }
    class NumberValidationException : Exception
    {
        //constructor method
        public NumberValidationException(string error) : base(error)
        {
        }
    }
    class StringValidationException : Exception
    {
        //constructor method
        public StringValidationException(string error) : base(error)
        {
        }
    }
    static class NumberValidation
    {
        public static int hoursInDay(int hours)
        {
            int HOURSINONEDAY = 24;
            if (hours <= HOURSINONEDAY)
            {
                if (hours >= 0)
                {
                    return hours;
                }else
                    throw new NegativeNumberException("There cannot be less than 0 hours in one day");
            }else
                throw new NumberValidationException("There cannot be more than "+HOURSINONEDAY+" hours in one day");
        }
        public static double hoursInDay(double hours)
        {
            double HOURSINONEDAY = 24;
            if (hours <= HOURSINONEDAY)
            {
                if (hours >= 0)
                {
                    return hours;
                }else
                throw new NegativeNumberException("There cannot be less than 0 hours in one day");
            }else
                throw new NumberValidationException("There cannot be more than " + HOURSINONEDAY + " hours in one day");
        }
        public static int validtime(int hours)
        {
            if (hours >= 0)
                return hours;
            throw new NegativeNumberException("hours must be positive");
        }
        public static double validtime(double hours)
        {
            if (hours >= 0)
                return hours;
            throw new NegativeNumberException("hours must be positive");
        }
        public static int weeksInYear(int weeks)
        {
            int WEEKSINYEAR = 52;
            if (weeks <= WEEKSINYEAR)
            {
                if (weeks >= 0)
                {
                    return weeks;
                }
                throw new NegativeNumberException("There cannot be less than 0 weeks in a year");
            }
            else
            {
                throw new NumberValidationException("There cannot be more than " + WEEKSINYEAR + " weeks in a year");
            }
        }
    }
}
