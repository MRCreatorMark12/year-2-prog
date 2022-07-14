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
using StudentHelper.Properties;
using StudentHelper.Classes.Systems;

namespace StudentHelper.Classes
{
    class Purchase
    {   
   /*
    * -------------------------------------------------------------------------------------------------------------------------->
    * Declaration of Variables:
    * ------------------------->
    */
        private PrintClass printClass = new PrintClass();
   /*
    * -------------------------------------------------------------------------------------------------------------------------->
    */
        /// <summary>
        /// This method Once called will take the parsed data consisting of Price, Deposit, Interest and Months
        /// And the set it into the correct settings data.
        /// </summary>
        /// <param name="price">The full price of the property</param>
        /// <param name="deposit">The deposit that the user is planning on inserting</param>
        /// <param name="interest">The interest per month on the price</param>
        /// <param name="months">The amount of months, has to be between 240 and 360</param>
        /// <returns>Returns weither or not it was successful and where it failed</returns>
        public void SetDataHouse(double price, double deposit,double interest, int months)
        {
            StringBuilder result = new StringBuilder();
            try
            {
                if (months >= 240 && months <= 360)
                { 
                    Server.Default.PurchasePrice_House = price;
                    Server.Default.Deposit_House = deposit;
                    Server.Default.Interest_House = interest;
                    Server.Default.NumberOfMonths_House = months;
                    result.Append("Successfuly set the purchase data");
                    printClass.PrintGeneral(result.ToString());
                }
                else if (months < 240 && months > 360)
                {
                    result.Append("UnSuccessful : Reason Incorrect months to payback must be between" +
                        "240 months and 360 months");
                    printClass.PrintGeneral(result.ToString());
                    return;
                }
            }
            catch (Exception ex)
            {
                printClass.PrintGeneral("Error please view Logs");
                LogSystem logs = new LogSystem();
                logs.LogTheError(ex.ToString());
            }
        }
   /*
    * -------------------------------------------------------------------------------------------------------------------------->
    */
    }
}
   /*
    * -------------------------------------------------------------------------------------------------------------------------->
    * End of Class
    * -------------------------------------------------------------------------------------------------------------------------->
    */
