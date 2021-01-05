//Nhu Truong
//3/17/2020
//Final Exam Code
//Code editor: Nhu Truong History Change: 3/17/20   Instructor: Chuck
//This class will provided function of calculating the hourly plus comission employee hourly pay

using System;

namespace PayrollSystem
{
    public class HourlyPlusCommissionEmployee: CommissionEmployee
    {
        private decimal hourlyRate; //hours worked for the week
        private decimal wage; //  wage per hour


        // six-parameter constructor for the HourlyPlusComissionEmployee class that being called in the main program
        public HourlyPlusCommissionEmployee(string firstName, string lastName,
          string socialSecurityNumber, decimal grossSales,
          decimal commissionRate, decimal hourlyRate, decimal hourlyWage)
          : base(firstName, lastName, socialSecurityNumber,
               grossSales, commissionRate)
        {
            HourlyRate = hourlyRate; // validates hourly rate
            wage = hourlyWage;
            
        }
        // property that gets and sets hourly employee's wage hour
        public decimal Wage
        {
            get
            {
                return wage;
            }
            set
            {
                if (value < 0) // validation
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                       value, $"{nameof(wage)} must be >= 0");
                }
                wage = value;
            }
        }


        // property that gets and sets 
        // HourlyPlusComissionEmployee's hourly rate
        public decimal HourlyRate
        {
            get
            {
                return hourlyRate;
            }
            set
            {
                if (value < 0 || value > 168) // validation
                {
                    throw new System.ArgumentOutOfRangeException(nameof(value),
                       value, $"{nameof(HourlyRate)} must be >= 0 and <= 168");
                }

                HourlyRate = value;
            }

        }
        // calculate earnings with hour rate
        public override decimal Earnings()
        {
            if (HourlyRate <= 40) // no overtime                          
            {
                return Wage * HourlyRate;
            }
            else
            {
                return (40 * Wage) + ((HourlyRate - 40) * Wage * 1.5M);
            }
        }

        // return string representation of HourlyPlusComissionEmployee
        public override string ToString() =>
           $"hourly rate salary {base.ToString()}\nhourly rate salary: {HourlyRate:C}";





    }
}