//Nhu Truong
//TINFO 200
//L1mpg Mileage program
//Change History
//Date        Developer        Description
//1/9/2020      Charles Costarella            File creation and initia l implementation of the app


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mileage
{
    // description of what the program does- what is its purpose
    //this is an auto road trip calculator desgined to determine
    // fuel efficiency for the typical family auto
    //it can be used to better plan your vacations and business
    // expenses
    class Program
    {
        static void Main(string[] args)
        {
            //user interface
            //1- sell the use to the software to the user
            // tell the user what this ptog will do for them
            //answer "why would I use this?"
            //2- INSTRUCTIONS(BASIC) ON HOW TO USE THe software
            Console.WriteLine(@"
***************************************************
***** Welcome to the Auto Road Trip Calculator*****
***************************************************
This program will calculate mileage for a typical auto 
road trip. You will be asked for the number of miles 
traveled and the amount of fuel used and then the
app will calculate your fuel efficiency for the trip.
You will be better able to plan and budget your fuel 
needs and plan other trips use this tool

Please watch the printed warnings about input types
carefully so that you don't crash the program


");
            // INPUT section - get data for the program from the user


            //prompt the user for his/her name
            Console.Write("Please enter your name: ");
            name = Console.ReadLine();


            
            //prompt the user for the miles val
            Console.Write("Enter miles driven as a whole number(example: 309, 425, etc.): ");
            //capture the input, convert to an int and store it locally
            int numberOfMilesDriven = int.Parse(Console.ReadLine());

            //prompt the user for the fuel val
            Console.Write("Enter amount of fuel as a real number(example: 9.97, 10.1, etc.): ");
            //capture the input, convert to a double and store it locally
            double amountOfFuel = double.Parse(Console.ReadLine());

            // PROCESSING SECTION - calculate the results from the data input by the user

            double milesPerGallon = numberOfMilesDriven / amountOfFuel;

            

            // OUTPUT SECTION
            //the old fashioned way = legacy
            Console.Write("The fuel efficiency for this auto road trip was: ");
            Console.WriteLine(milesPerGallon);

            //string interpolation - the preferred C# style
            Console.WriteLine($"The fuel efficiency for this auto road trip was: {milesPerGallon}");


            //old c-style
            Console.Write("The fuel efficiency for this auto road trip was: {0}", milesPerGallon);


            //java concatenation style
            Console.Write("The fuel efficiency for this auto road trip was: " + milesPerGallon);

            //salutation
            Console.WriteLine("Thanks for using the Auto Roan Trip Calculatior. \nFeel free to repeat the program");


        }
    }
}
