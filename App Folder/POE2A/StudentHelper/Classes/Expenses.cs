/*
 * Created by: Richard Van Der Merwe.
 * Reworked on: 10 July 2022.
 * Copyright Holder: The Independent Institute of Education (IIE)'s Varsity Collage until: 31 December 2022.
 * Then: Richard van der Merwe on: 1 January 2023.
 * File: Main Class.
 * Do not Replicate, work is for private use Only!
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHelper.Classes
{
    abstract class Expenses
    {
        public abstract double CalculatePurchase(double purchase, double deposit, int interest,int months);
        public abstract double CalculateRent(double rent);
        public abstract double CalculateBalance(double income, double tax, double groceries, double wandl, 
            double trave, double cell, double other);
        public abstract double CalculateBalanceExtra(double income, double tax, double groceries, double wandl,
            double trave, double cell, double other,double uif, double medicalAid, double pension);
        public abstract void CalulateBalanceAfterMonthlyPayment(double monthlyPayment);
    }
}
   /*
    * -------------------------------------------------------------------------------------------------------------------------->
    * End of Class
    * -------------------------------------------------------------------------------------------------------------------------->
    */