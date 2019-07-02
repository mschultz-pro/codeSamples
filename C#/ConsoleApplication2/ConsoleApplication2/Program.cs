using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            //prices for each of the four items 
            double item1Price = 239.99;
            double item2Price = 129.75;
            double item3Price = 99.95;
            double item4Price = 350.89;

            //place items array for easy access 
            double[] itemPrice = {item1Price, item2Price, item3Price, item4Price};

            //declare variables 
            int intItem = 0;
            int intQuantity = 0;
            double dblTotalSales = 0;
            double dblItemSales = 0;
            String salesPersonsName;

            //get the sale persons name from the user
            Console.Write("Please enter a salesperson's name: ");
            salesPersonsName = Console.ReadLine();

            //do while loop 
            do
            {
                //get the item number from the users
                Console.Write("Please enter an item number between 1 and 4 or -1 to quit: ");
                intItem = Convert.ToInt32(Console.ReadLine());

                //if the item number is invalid
                if (intItem < 1 || intItem > 4)
                {
                    //tell the user
                    Console.Write("invalid entry\n");
                }
                //other wise(the number is valid)
                else
                {
                    //get the quantity from the user
                    Console.Write("Please enter the quantity sold: ");
                    intQuantity = Convert.ToInt32(Console.ReadLine());
                    //set the dblItemSales to the price times the quantity 
                    dblItemSales = itemPrice[intItem - 1] * intQuantity;

                    //switch based on the item number
                    switch (intItem)
                    {
                        case 1://if item 1
                            {
                                //add dblItemSales to a running total 
                                dblTotalSales += dblItemSales;
                                break;
                            }
                        case 2://if item 2
                            {
                                //add dblItemSales to a running total
                                dblTotalSales += dblItemSales;
                                break;
                            }
                        case 3://if item 3
                            {
                                //add dblItemSales to a running total
                                dblTotalSales += dblItemSales;
                                break;
                            }
                        case 4://if item 4
                            {
                                //add dblItemSales to a running total
                                dblTotalSales += dblItemSales;
                                break;
                            }
                    }
                    //tell the user who what how many and how much
                    Console.Write("Sales person " + salesPersonsName + " sold " + intQuantity + " of item #" + intItem + " at " + dblItemSales.ToString("C") + "\n");
                }
            } while (intItem != -1);//stop do while is sentinel of -1

            //tell user total sales
            Console.Write("Sales person " + salesPersonsName + " sold a total of " + dblTotalSales.ToString("C") + "\n");
            //calculate the sale person's commission
            double commission = 200 + dblTotalSales * .09;
            //display the commission to the users 
            Console.Write("Sales person " + salesPersonsName + " earned a commission of " + commission.ToString("C") + "\n");

            Console.Write("press enter to continue");
            Console.ReadLine();
        }
    }
}
