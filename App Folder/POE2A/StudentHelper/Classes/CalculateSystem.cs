using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentHelper.Classes.Interfaces;
using StudentHelper.Properties;

namespace StudentHelper.Classes
{
    class CalculateSystem : Expenses
    {
        public override double CalculateBalance(double income, double tax, double groceries,
            double wandl, double trave, double cell, double other)
        {
            double result = 0;
            result = income - tax - (groceries + wandl + trave + cell + other);
            return result;
        }

        public override double CalculatePurchase(double purchase, double deposit, int interest, int months)
        {
            double p = purchase;
            double d = deposit;
            //Percentage
            double i = interest;
            int n = months;
            double filteredResult = 0;
            double monthlyPayment = 0;

            filteredResult = (p - d) * (1 + i * n);
            monthlyPayment = filteredResult / n;
            Server.Default.MonthlyPayment_House = monthlyPayment;
            CalulateBalanceAfterMonthlyPayment(monthlyPayment);
            return monthlyPayment;
        }

        public override void CalulateBalanceAfterMonthlyPayment(double monthlyPayment)
        {
            double availableBalance = Server.Default.AvailableBal;
            double result = availableBalance - monthlyPayment;
            Server.Default.AvailbleBalanceAfterMontlyPayment_House = result;
        }

        public override double CalculateRent(double rent)
        {
            double result = 0;
            result = Server.Default.AvailableBal - rent;
            return result;
        }

        public override double CalculateBalanceExtra(double income, double tax, double groceries, 
            double wandl, double trave, double cell, double other, double uif, double medicalAid, double pension)
        {
            double result = 0;
            result = income - tax - (groceries + wandl + trave + cell + other) - (uif + medicalAid + pension);
            return result;
        }
    }
}
