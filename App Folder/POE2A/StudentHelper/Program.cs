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
using StudentHelper.Classes.Interfaces;
using StudentHelper.Classes;

namespace StudentHelper
{
    class Program
    {
   /*
    * -------------------------------------------------------------------------------------------------------------------------->
    * Declaration of Variables:
    * ------------------------->
    */
        private static string input = string.Empty;
        private static PrintClass printClass = new PrintClass();
        private static StringBuilder toConsole = new StringBuilder();
   /*
    * -------------------------------------------------------------------------------------------------------------------------->
    */
        /// <summary>
        /// This is the main void that starts the application that only calls the Init() function
        /// once and thats it.
        /// </summary>
        static void Main()
        {
            Init(0);
        }
   /*
    * -------------------------------------------------------------------------------------------------------------------------->
    */
        /// <summary>
        /// This method is called as many times as needed as it allows the app to stay active and
        /// geive the user some useful data needed to run the app.
        /// </summary>
        /// <param name="selector">This is what is used to determine which side to switch too</param>
        private static void Init(int selector)
        {
            switch (selector)
            {
                case 0:
                    toConsole.Append("Welcome to the Student Helper " +
                        "\n\rTo get started use /salary <a> <b> <c> <d> <e> <f> <g> " +
                        "\n\ra)Gross Income before Tax " +
                        "\n\rb)Estimated Tax Deductions " +
                        "\n\rc)Estimated Monthly Grocery Amount " +
                        "\n\rd)Estimated Water and Electricity Costs " +
                        "\n\re)Estimated Travel Costs " +
                        "\n\rf)Estimated Cellphone and Telephone Costs " +
                        "\n\rg)Any other Expenses you have " +
                        "\n\rfor example: /salary 15000 1341 1000 0 500 150 1500 " +
                        "\n\r\n\rOr you can use /salaryadv <a> <b> <c> <d> <e> <f> <g> <h> <i> <j>" +
                        " to have a more realistic feel " +
                        "\n\ra)Gross Income before Tax " +
                        "\n\rb)Estimated Tax Deductions " +
                        "\n\rc)Estimated Monthly Grocery Amount " +
                        "\n\rd)Estimated Water and Electricity Costs " +
                        "\n\re)Estimated Travel Costs " +
                        "\n\rf)Estimated Cellphone and Telephone Costs " +
                        "\n\rg)Any other Expenses you have " +
                        "\n\rh)Estimated UIF" +
                        "\n\ri)Estimated Medical Aid" +
                        "\n\rj)Estimated Pension Fund " +
                        "\n\rfor example: /salaryadv 15000 1341 1000 0 500 150 1500 500 500 500 " +
                        "\n\r\n\rOR type /help or /helpstart or check readme for more info");
                    printClass.PrintGeneral(toConsole.ToString());
                    break;
                case 1:
                    //Print Nothing as we dont need to print anything yet
                    break;
            }
            Input();
        }
   /*
    * -------------------------------------------------------------------------------------------------------------------------->
    */
        private static void Input()
        {
            input = Console.ReadLine();
            input.ToLower();
            if (input.Length == 0)
            {
                printClass.PrintGeneral("Error not enough input");
            }
            else if (input.Length >= 1)
            {
                /* 
                 * perfect amount if data also we are not checking for data validation here
                 * as we will do it else where and the program requires letters and numbers to work.
                 */
                Command command = new Command();
                command.CommandExecute(input);
            }
            Init(1);
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
