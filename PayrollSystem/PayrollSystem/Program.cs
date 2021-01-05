using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Fig. 12.9: PayrollSystemTest.cs
// Employee hierarchy test app.
namespace PayrollSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // create derived-class objects
            var salariedEmployee = new SalariedEmployee("John", "Smith",
                "111-11-1111", 800.00M);
            var hourlyEmployee = new HourlyEmployee("Karen", "Price",
               "222-22-2222", 16.75M, 40.0M);
            var commissionEmployee = new CommissionEmployee("Sue", "Jones",
               "333-33-3333", 10000.00M, .06M);
            var basePlusCommissionEmployee =
               new BasePlusCommissionEmployee("Bob", "Lewis",
               "444-44-4444", 5000.00M, .04M, 300.00M);
            // /////////////////////////////////////////////////////
            // adding a new type of employee where pay is calculated by 
            // the inherited behavior of commissions and the included info for hourly
            // Richard Sherman has been hired as a pro football commentator.
            // The network will pay him $3500 per hour for a 1 hour show daily. 
            // He also earns .04 commissions on half a million dollars
            // from the sales of his personally ON-AIR worn bow-ties.
            var hourlyPlusCommissionEmployee =
               new HourlyPlusCommissionEmployee("Richard", "Sherman", 
               "555-55-5555", 500_000.00M, .04M, 7.00M, 3500.00M);

            Console.WriteLine("Employees processed individually:\n");

            Console.WriteLine($"{salariedEmployee}\nearned: " +
                $"{salariedEmployee.Earnings():C}\n");
            Console.WriteLine(
               $"{hourlyEmployee}\nearned: {hourlyEmployee.Earnings():C}\n");
            Console.WriteLine($"{commissionEmployee}\nearned: " +
                $"{commissionEmployee.Earnings():C}\n");
            Console.WriteLine($"{basePlusCommissionEmployee}\nearned: " +
                $"{basePlusCommissionEmployee.Earnings():C}\n");
            Console.WriteLine($"{hourlyPlusCommissionEmployee}\nearned: " +
                $"{hourlyPlusCommissionEmployee.Earnings():C}\n");

            // create List<Employee> and initialize with employee objects
            var employees = new List<Employee>() {salariedEmployee,
                hourlyEmployee, commissionEmployee, basePlusCommissionEmployee, hourlyPlusCommissionEmployee};

            Console.WriteLine("Employees processed polymorphically:\n");

            // generically process each element in employees
            foreach (var currentEmployee in employees)
            {
                Console.WriteLine(currentEmployee); // invokes ToString

                // determine whether element is a BasePlusCommissionEmployee
                if (currentEmployee is BasePlusCommissionEmployee)
                {
                    // downcast Employee reference to 
                    // BasePlusCommissionEmployee reference
                    var employee = (BasePlusCommissionEmployee)currentEmployee;

                    employee.BaseSalary *= 1.10M;
                    Console.WriteLine("new base salary with 10% increase is: " +
                        $"{employee.BaseSalary:C}");
                }
                else if (currentEmployee is HourlyPlusCommissionEmployee)
                {
                    // downcast Employee reference to 
                    // HourlyPlusCommissionEmployee reference
                    var employee = (HourlyPlusCommissionEmployee)currentEmployee;

                    employee.HourlyRate *= 1.10M;
                    Console.WriteLine("new hourly rate with 10% increase is: " +
                        $"{employee.HourlyRate:C}");
                }

                Console.WriteLine($"earned: {currentEmployee.Earnings():C}\n");
            }

            // get type name of each object in employees 
            for (int j = 0; j < employees.Count; j++)
            {
                Console.WriteLine($"Employee {j+1} is a {employees[j].GetType()}");
            }

        }
    }
}
