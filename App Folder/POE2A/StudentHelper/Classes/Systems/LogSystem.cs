/*
 * Created by: Richard Van Der Merwe
 * Reworked on: 10 July 2022
 * Copyright Holder: Varsity Collage until: 31 December 2022 / Then: Richard van der Merwe on: 1 January 2023
 * File: Main Class
 * Do not Replicate, work is for private use Only!
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHelper.Classes.Systems
{
    class LogSystem
    {
   /*
    * -------------------------------------------------------------------------------------------------------------------------->
    * Declaration of Variables:
    * ------------------------->
    */
        readonly private string FormatUsed = String.Empty;
        readonly private string TimeOfError = String.Empty;
   /*
    * -------------------------------------------------------------------------------------------------------------------------->
    */
        /// <summary>
        /// Basic Constructor that is used to set the Format of the Error Log and Time of Error Log.
        /// </summary>
        public LogSystem()
        {
            FormatUsed = String.Format("{0} {1} C->", DateTime.Now.ToShortDateString().ToString(), 
                                                      DateTime.Now.ToLongTimeString().ToString());
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();
            TimeOfError = String.Format("{0} {1} {2}", year, month, day);
        }
   /*
    * -------------------------------------------------------------------------------------------------------------------------->
    */
        /// <summary>
        /// Log The Error Method will Create and store the error message to that txt file for later viewing.
        /// </summary>
        /// <param name="errorMessage">This is the Exception ex.Message by default that is parsed from the other classes</param>
        public void LogTheError(string errorMessage)
        {
            string[] paths = { AppContext.BaseDirectory};
            string fullPath = Path.Combine(paths);
            StreamWriter streamwriter = new StreamWriter(String.Format("{0} {1} ErrorLogs.txt", fullPath, TimeOfError), true);
            streamwriter.WriteLine(FormatUsed + errorMessage);
            streamwriter.Flush();
            streamwriter.Close();
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

