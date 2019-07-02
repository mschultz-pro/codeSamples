using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //collect input numbers from user, assign then to variables 
            Console.Write("Please enter the first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter the second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            //calculate and assign answers to new variables 
            int sum = num1 + num2;
            int difernece = num1 - num2;
            int product = num1 * num2;
            int quotient = num1 / num2;
            int remainder = num1 % num2;

            //display answers to user
            Console.WriteLine("The two numbers you entered are: "+num1+" and "+num2);
            Console.WriteLine("The sum of the two number is : " + sum);
            Console.WriteLine("The difference of the two number is : " + difernece);
            Console.WriteLine("The product of the two number is : " + product);
            Console.WriteLine("The quotient of the two number is : " + quotient);
            Console.WriteLine("The remainder of the two number is : " + remainder);
            Console.WriteLine();

            //determine which number is larger
            if (num1 - num2 == 0)//if the difference is zero 
            {
                Console.WriteLine("The two numbers are equal");//the numbers are equal 
            }
            else//if the difference is not zero 
            {
                if (num1 - num2 > 0)//check if the difference is more than zero
                {
                    Console.WriteLine("The larger of the two numbers is: " + num1);//if it is first variable is larger
                }else
                {
                    Console.WriteLine("The larger of the two numbers is: " + num2);//if not the second variable is larger 
                }
            }
            Console.WriteLine("Press the [Enter] key to continue");
            Console.ReadLine();
        }
    }
}
