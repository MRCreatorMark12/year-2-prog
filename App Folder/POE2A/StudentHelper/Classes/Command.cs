/*
 * Created by: Richard Van Der Merwe.
 * Reworked on: 10 July 2022.
 * Copyright Holder: The Independent Institute of Education (IIE)'s Varsity Collage until: 31 December 2022.
 * Then: Richard van der Merwe on: 1 January 2023.
 * File: Command Class.
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
    class Command
    {
        /*
         * -------------------------------------------------------------------------------------------------------------------------->
         * Declaration of Variables:
         * ------------------------->
         */
        /*
         * Although the Poe Doc requires us to use a Array for task
         * 1 and a List for task 2, I will use neither as for thsi build its not needed.
         * but i will have the declared variables here
         * private string[] expenses;
         * private List<string> expenses;
         */
        private List<StringBuilder> argsList = new List<StringBuilder>();
        private List<StringBuilder> items = new List<StringBuilder>();
        private char[] spaces = new char[] { '/', ' ', '.' };
        private string [] storedCommands = {"bal, buy","clear", "clearrec", "getvalue", "help", "rent", "salary", "salaryadv", "setclear", "setexpenses", "setpurchase", "setunclear", "setvalue" };
        //private StringBuilder commands = new StringBuilder(""); 
        private PrintClass printClass = new PrintClass();
        private Purchase purchase = new Purchase();
        private StringBuilder[] argArray;
        /*
         * -------------------------------------------------------------------------------------------------------------------------->
         * Getters and Setters
         * ------------------------->
         */
        /// <summary>
        /// This array is used to store strings that will make up the arguments needed for all 
        /// the commands of this system.
        /// </summary>
        public StringBuilder[] ArgArray { get => argArray; set => argArray = value; }
        /// <summary>
        /// T
        /// </summary>
        public List<StringBuilder> ArgsList { get => argsList; set => argsList = value; }
        public List<StringBuilder> Items { get => items; set => items = value; }
        public char[] Spaces { get => spaces; set => spaces = value; }
   /*
    * -------------------------------------------------------------------------------------------------------------------------->
    */
        /// <summary>
        /// This method is called to get the command and instantiate the command system.
        /// </summary>
        /// <param name="input">
        /// This is the input from the user that is parsed to this class, is can be letter 
        /// or number as each function will use different variables.
        /// </param>
        public void CommandExecute(string input)
        {
            /*
             * We will use GetLabel(string input) to return true or false if the first character 
             * of the input string is a '/' if so we can continue with the command part, else we ignore
             * it.This is a useful function especialy if you want to make a chat / command system like
             * minecraft as they use a more advanced feautre of this system and if there is no '/'
             * then its just a normal chat and that would then be parsed into the chat() 
             * method, but since we are working on commands it will only use the command part.
             */
            if (GetLabel(input))
            {
                try
                {
                   string command = GetCommand(input);
                    //StringBuilder cmd1 = new StringBuilder();
                    //cmd1.Append(storedCommands[0]);
                    //StringBuilder cmd2 = new StringBuilder();
                    //cmd1.Append(storedCommands[1]);
                    //StringBuilder cmd3 = new StringBuilder();
                    //cmd1.Append(storedCommands[2]);
                    //StringBuilder cmd4 = new StringBuilder();
                    //cmd1.Append(storedCommands[3]);
                    //StringBuilder cmd5 = new StringBuilder();
                    //cmd1.Append(storedCommands[4]);
                    //StringBuilder cmd6 = new StringBuilder();
                    //cmd1.Append(storedCommands[5]);
                    //StringBuilder cmd7 = new StringBuilder();
                    //cmd1.Append(storedCommands[6]);
                    switch (command)
                    {
                        case "bal":
                            GetBalance();
                            break;
                        case "buy":
                            Buy();
                            break;
                        case "clear":
                            ClearConsole(1);
                            break;
                        case "clearrec":
                            ClearRecords();
                            break;
                        case "getvalue":
                            GetValue();
                            break;
                        case "help":
                            HelpSystem();
                            break;
                        case "rent":
                            Rent();
                            break;
                        case "salary":
                            SetBasic();
                            break;
                        case "salaryadv":
                            SetExtra();
                            break;
                        case "setclear":
                            SetClear();
                            break;
                        case "setexpenses":
                            SetExpenses();
                            break;
                        case "setpurchase":
                            SetPurchase();
                            break;
                        case "setunclear":
                            SetUnClear();
                            break;
                        case "setvalue":
                            SetValue();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    printClass.PrintGeneral("Error please view Logs");
                    LogSystem logs = new LogSystem();
                    logs.LogTheError(ex.ToString());
                }
            }
            else if (!GetLabel(input))
            {
                printClass.PrintGeneral("To use a command you need to use the '/' before the command");
            }
        }
   /*
    * -------------------------------------------------------------------------------------------------------------------------->
    */
        /// <summary>
        /// This method will be called using /bal and will first display the available balance and then depending on the mode, 
        /// it will either show the balance after rent or the balance after purchase.
        /// </summary>
        private void GetBalance()
        {
            try
            {
                CalculateSystem calc = new CalculateSystem();
                //Print the current balance
                double availableBalance = 0;
                if (Server.Default.bHasExtra)
                {
                    availableBalance = Server.Default.AvailableBalExtra;
                    printClass.PrintBalance(0, availableBalance);
                }
                else if (!Server.Default.bHasExtra)
                {
                    availableBalance = Server.Default.AvailableBal;
                    printClass.PrintBalance(0, availableBalance);
                }
                double resultBal = 0;
                if (Server.Default.bIsBuying)
                {
                    // double result = calc.CalculatePurchase();
                }
                else if (!Server.Default.bIsBuying)
                {
                    double rent = Server.Default.Rent;
                    Console.WriteLine("Your balance after Rent is R{0}", rent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error please view Logs");
                LogSystem logs = new LogSystem();
                logs.LogTheError(ex.ToString());
            }
        }
   /*
    * -------------------------------------------------------------------------------------------------------------------------->
    */
        /// <summary>
        /// This method will set the mode to buy mode.
        /// </summary>
        private void Buy()
        {
            Server.Default.bIsBuying = true;
            printClass.PrintGeneral("You are now in buy mode " +
                "\n\r You can now use /setpurchase <a> <b> <b> <c> <d> " +
                "\n\r a) full price of property " +
                "\n\r b) the amount you are going to deposit " +
                "\n\r c) interest rate percentage(%) " +
                "\n\r d) amount of months to repay (between 240 and 360 months )");
        }
   /*
    * -------------------------------------------------------------------------------------------------------------------------->
    */
        /// <summary>
        /// This method is used to clear the console.
        /// </summary>
        /// <param name="selector">
        /// (0) this determines if its the system clearing the console.
        /// or
        /// (1) this determines the player overrides the clear console command.
        /// </param>
        private void ClearConsole(int selector)
        {
            if (selector == 0)
            {
                if (Server.Default.bIsClear)
                {
                    Console.Clear();
                }
            }
            else if (selector == 1)
            {
                Console.Clear();
            }
        }


        private void SetClear()
        {
            printClass.PrintGeneral("Clear mode = Clear: Console will now clear itself after each command ");
            Server.Default.bIsClear = true;
        }
        private void SetUnClear()
        {
            printClass.PrintGeneral("Clear mode = UnClear: Console wont clear itself after each command ");
            Server.Default.bIsClear = false;
        }
        private void SetExtra()
        {
            try
            {
                GetArgs();
                if (argArray.Length < 3)
                {
                    printClass.PrintGeneral("Error, Too few Arguments use /setextra " +
                        "<UIF> " +
                        "<Medical Aid> " +
                        "<Pension> ");
                }
                else if (argArray.Length == 3)
                {
                    double gmi = double.Parse(argArray[0].ToString());
                    double td = double.Parse(argArray[1].ToString());
                    double gr = double.Parse(argArray[2].ToString());
                    double we = double.Parse(argArray[3].ToString());
                    double tc = double.Parse(argArray[4].ToString());
                    double ctp = double.Parse(argArray[5].ToString());
                    double oe = double.Parse(argArray[6].ToString());
                    double uif = double.Parse(argArray[0].ToString());
                    double medi = double.Parse(argArray[1].ToString());
                    double penssion = double.Parse(argArray[2].ToString());
                    Server.Default.UIF = uif;
                    Server.Default.MedicalAid = medi;
                    Server.Default.Pension = penssion;
                    Server.Default.bHasExtra = true;
                    UpdateBalance(1);
                }
                else if (argArray.Length > 3)
                {
                    printClass.PrintGeneral("Error, Too many Arguments use /setextra " +
                         "<UIF> " +
                         "<Medical Aid> " +
                         "<Pension> ");
                }
            }
            catch (Exception ex)
            {
                // PrintGeneral("Error please view Logs");
                LogSystem logs = new LogSystem();
                logs.LogTheError(ex.ToString());
            }
        }

        /*
    * -------------------------------------------------------------------------------------------------------------------------->
*/
        /// <summary>
        /// This method will get all the input data from the user relating to the Purchase of the 
        /// house and set it into the settings file.
        /// </summary>
        private void SetPurchase()
        {
            try
            {
                GetArgs();
                if (argArray.Length < 4)
                {
                    printClass.PrintGeneral("Error, Too few Arguments use /setpurchase " +
                        "<price> " +
                        "<deposit> " +
                        "<interest> " +
                        "<months to repay>");
                }
                else if (argArray.Length == 4)
                {
                    double p = double.Parse(argArray[0].ToString());
                    double d = double.Parse(argArray[1].ToString());
                    double i = double.Parse(argArray[2].ToString());
                    int n = int.Parse(argArray[3].ToString());
                    purchase.SetDataHouse(p, d,i, n);
                }
                else if (argArray.Length > 4)
                {
                    printClass.PrintGeneral("Error, Too many Arguments use /setpurchase " +
                       "<price> " +
                       "<deposit> " +
                       "<interest> " +
                       "<months to repay>");
                }
            }
            catch (Exception ex)
            {
                printClass.PrintGeneral("Error please view Logs " +
                   "\n\rThis error is commonly associated with incorrect input: please make sure " +
                   "to only use numbers when inputting your data");
                LogSystem logs = new LogSystem();
                logs.LogTheError(ex.ToString());
            }
        }
   /*
    * -------------------------------------------------------------------------------------------------------------------------->
    */
        /// <summary>
        /// This method will set the mode to rent mode.
        /// </summary>
        private void Rent()
        {
            Server.Default.bIsBuying = false;
            printClass.PrintGeneral("You are now in Rent mode");
        }
  
        /// <summary>
        /// This method is called to manually override set the current expenses 
        /// </summary>
        private void SetExpenses()
        {
            try
            {
                GetArgs();
                if (argArray.Length == 0)
                {
                  
                }
                else if (argArray.Length < 7)
                {
                    
                }
                else if (argArray.Length == 7)
                {
                  
                   // UpdateBasic(Double.Parse(argArray[0]), Double.Parse(argArray[1]), Double.Parse(argArray[2]), Double.Parse(argArray[3]), Double.Parse(argArray[4]), Double.Parse(argArray[5]), Double.Parse(argArray[6]));
                }
            }
            catch (Exception ex)
            {
                // PrintGeneral("Error please view Logs");
                LogSystem logs = new LogSystem();
                logs.LogTheError(ex.ToString());
            }
        }
   /*
    * -------------------------------------------------------------------------------------------------------------------------->
    */
        /// <summary>
        /// This method is used to print all the commands that the user can use and how they can use it.
        /// </summary>
        private void HelpSystem()
        {
            printClass.PrintHelp();
        }

   /*
    * -------------------------------------------------------------------------------------------------------------------------->
    */
       
   /*
    * -------------------------------------------------------------------------------------------------------------------------->
    */
        /// <summary>
        /// This method is called to set the starting data that is required to calculate the available balance.
        /// </summary>
        private void SetBasic()
        {
            try
            {
                GetArgs();
                if (argArray.Length < 7)
                {
                    printClass.PrintGeneral("Error, Too few Arguments use /salary " +
                        "<gross income before tax deductions> " +
                        "<estimated tax deductions> " +
                        "<groceries> " +
                        "<water and elect> " +
                        "<travel costs> " +
                        "<cellphone and telephone costs > " +
                        "<other expenses> ");
                }
                else if (argArray.Length == 7)
                {
                    double gmi = double.Parse(argArray[0].ToString());
                    double td = double.Parse(argArray[1].ToString());
                    double gr = double.Parse(argArray[2].ToString());
                    double we = double.Parse(argArray[3].ToString());
                    double tc = double.Parse(argArray[4].ToString());
                    double ctp = double.Parse(argArray[5].ToString());
                    double oe = double.Parse(argArray[6].ToString());

                    Server.Default.GMI = gmi;
                    Server.Default.TD = td;
                    Server.Default.GR = gr;
                    Server.Default.WNDL = we;
                    Server.Default.TC = tc;
                    Server.Default.CT = ctp;
                    Server.Default.OE = oe;
                    
                    UpdateBalance(0);
                    printClass.PrintGeneral("Now you can use /rent to select rent mode or /buy to select" +
                        "buy mode: The mode is rent by default");
                }
                else if (argArray.Length > 7)
                {
                    printClass.PrintGeneral("Error, Too few Arguments use /salary " +
                       "<gross income before tax deductions> " +
                        "<estimated tax deductions> " +
                        "<groceries> " +
                        "<water and elect> " +
                        "<travel costs> " +
                        "<cellphone and telephone costs > " +
                        "<other expenses> ");
                }
            }
            catch (Exception ex)
            {
                if (Server.Default.bIsClear)
                {
                    ClearConsole(0);
                }

                printClass.PrintGeneral("Error please view Logs " +
                    "\n\rThis error is commonly associated with incorrect input: please make sure " +
                    "to only use numbers when inputting your data");
                LogSystem logs = new LogSystem();
                logs.LogTheError(ex.ToString());
            }
        }
        private void UpdateBalance(int selector)
        {
            ClearConsole(0);
            try
            {
                double i = Server.Default.GMI;
                double t = Server.Default.TD;
                double g = Server.Default.GR;
                double w = Server.Default.WNDL;
                double tr = Server.Default.TC;
                double c = Server.Default.CT;
                double oe = Server.Default.OE;
                double uif = Server.Default.UIF;
                double med = Server.Default.MedicalAid;
                double pen = Server.Default.Pension;
                CalculateSystem calc = new CalculateSystem();
                switch (selector)
                {
                    case 0:
                        Server.Default.AvailableBal = calc.CalculateBalance(i, t, g, w,
                            tr, c, oe);
                        double bal = Server.Default.AvailableBal;
                        string message = string.Empty;
                        message = string.Format("Your available balance is R{0}", bal);
                        printClass.PrintGeneral(message);
                        break;
                    case 1:
                        calc = new CalculateSystem();
                        Server.Default.AvailableBalExtra = calc.CalculateBalanceExtra(i, t, g, 
                            w, tr, c, oe,uif,med,pen);
                        string balExtra = Server.Default.AvailableBal.ToString();
                        //string renBal = Server.Default.AvailableBalAfterRent.ToString();
                        string messageExtra = string.Empty;
                        messageExtra = string.Format("Your available balance with extra Deductuins is R{0}",
                            balExtra);
                        printClass.PrintGeneral(messageExtra);
                        break;
                }
            }
            catch (Exception ex)
            {
               
            }
            
        }
        private void ClearRecords()
        {
            Server.Default.GMI = 0;
            Server.Default.TD = 0;
            Server.Default.GR = 0;
            Server.Default.WNDL = 0;
            Server.Default.TC = 0;
            Server.Default.CT = 0;
            Server.Default.OE = 0;
            Server.Default.Rent = 0;
            Server.Default.bIsBuying = false;
            Server.Default.bHasExtra = false;
            Server.Default.AvailableBal = 0;
        }
        private void GetValue()
        {
            try
            {
                GetArgs();
                if (argArray.Length == 0)
                {
                    //The Args are empty do nothing
                }
                else if (argArray.Length == 1)
                {
                    /*
                     * if the args is equal to 1 then it will be "/getvalue <arg0>" this is enough fo this command
                     */
                    GetValue(argArray[0].ToString());
                }
            }
            catch (Exception ex)
            {

            }
        }

        /*
         * -------------------------------------------------------------------------------------------------------------------------->
         */
        /// <summary>
        /// Here were trying to set any variable using this command "/command (arg0) (arg1) (arg2) (arg3)" but
        /// int this case were using "/setvalue Groceries 50"
        /// </summary>
        private void SetValue()
        {
            try
            {
                GetArgs();
                if (argArray.Length == 0)
                {
                    //The Args are empty do nothing
                }
                else if (argArray.Length == 1)
                {
                    /*
                     * if the args is more than or equal to 1 then it will be "/setvalue <arg0>" this is still not enough for this
                     * command so we need atleast 2 args
                     */
                }
                else if(argArray.Length == 2)
                {
                    //Here we have the correct amount of arguments now we can proceed with the command as its now "/setvalue <arg0> <arg1>"
                    UpdateVariable(argArray[0].ToString(), Double.Parse(argArray[1].ToString()));
                }
            }
            catch (Exception ex)
            {

            }
            
        }
        /*
         * -------------------------------------------------------------------------------------------------------------------------->
         */
        /// <summary>
        /// This method will use a switch statement to adjust the correct vaiables stored in the project settings.
        /// </summary>
        private void UpdateVariable(string valueToUpdate, double value)
        {
            switch (valueToUpdate)
            {
                case "sal":
                    Server.Default.GMI = value;
                    Print("set","Salary", value.ToString(), valueToUpdate);
                    break;
                case "tax":
                    Server.Default.TD = value;
                    Print("set", "Taxes", value.ToString(), valueToUpdate);
                    break;
                case "groc":
                    Server.Default.GR = value;
                    Print("set", "Groceries", value.ToString(), valueToUpdate);
                    break;
                case "watelec":
                    Server.Default.WNDL = value;
                    Print("set", "Water and Lights", value.ToString(), valueToUpdate);
                    break;
                case "trav":
                    Server.Default.TC = value;
                    Print("set", "Travel Costs", value.ToString(), valueToUpdate);
                    break;
                case "cell":
                    Server.Default.CT = value;
                    Print("set", "Cellphone and Telephone", value.ToString(), valueToUpdate);
                    break;
                case "other":
                    Server.Default.OE = value;
                    Print("set", "Other Expenses", value.ToString(), valueToUpdate);
                    break;
                case "rent":
                    Server.Default.Rent = value;
                    Print("set", "Rent", value.ToString(), valueToUpdate);
                    break;
                case "purc":
                    //Server.Default.OE = value;
                    break;
                case "deposit":
                    //Server.Default.OE = value;
                    break;
                case "inter":
                    //Server.Default.OE = value;
                    break;
                case "months":
                    //Server.Default.OE = value;
                    break;
            }
        }
        private static void Print(string typeOfPrint, string department, string value, string commandName)
        {
            switch (typeOfPrint)
            {
                case "set":
                    Console.WriteLine("{0} set R{1} \nNow you can use /getvalue {2}", department, value, commandName);
                    break;
                case "get":
                    Console.WriteLine("The value you have set for {0} is: R{1}",department, value);
                    break;
                case "help":
                    Console.WriteLine("Here are some commands you can use: " +
                        "\n\r/setvalue <department to set> <value> :: this command will allow you to set a single value of any department" +
                        "\n\r/getvalue <department to get> :: this command will allow you to get any department amount" +
                        "\n\r/setbasic <income before deductions> <estimated tax> <total estimated groceries for the month> <>", department, value);
                    break;
                case "bal":
                    Console.WriteLine("your available balance is: R{0}", value);
                    break;
            }
        }

        private void Help() {
            try
            {
                GetArgs();
                if (argArray.Length == 0)
                {
                    //The Args are empty do nothing
                    Console.WriteLine("Not enough Arguments for the Help Command " +
                        "\n\rThe following help command are allowed" +
                        "\n\r/help" +
                        "\n\r/help setvalue" +
                        "\n\r/help getvalue");
                }
                else if (argArray.Length == 1)
                {
                    /*
                     * if the args is more than or equal to 1 then it will be "/setvalue <arg0>" this is still not enough for this
                     * command so we need atleast 2 args
                     */
                }
                else if (argArray.Length == 2)
                {
                    //Here we have the correct amount of arguments now we can proceed with the command as its now "/setvalue <arg0> <arg1>"
                    UpdateVariable(argArray[0].ToString(), Double.Parse(argArray[1].ToString()));
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void GetHelp(string helpToGet)
        {
            string value = string.Empty;
            switch (helpToGet)
            {
                case "sal":
                   // value = Server.Default.GMI.ToString();
                    Print("help", "Salary", value.ToString(), helpToGet);
                    break;
            }
        }

        private void GetValue(string valueToGet)
        {
            string value = string.Empty;
            switch (valueToGet)
            {
                case "sal":
                    value = Server.Default.GMI.ToString();
                    Print("get", "Salary", value.ToString(), valueToGet);
                    break;
                case "tax":
                    value = Server.Default.TD.ToString();
                    Print("get", "Tax", value.ToString(), valueToGet);
                    break;
                case "groc":
                    value = Server.Default.GR.ToString();
                    Print("get", "Groceries", value.ToString(), valueToGet);
                    break;
                case "watelec":
                    value = Server.Default.WNDL.ToString();
                    Print("get", "Water and Electricity", value.ToString(), valueToGet);
                    break;
                case "trav":
                    value = Server.Default.TC.ToString();
                    Print("get", "Travel ", value.ToString(), valueToGet);
                    break;
                case "cell":
                    value = Server.Default.CT.ToString();
                    Print("get", "Cellphone and Telephone costs", value.ToString(), valueToGet);
                    break;
                case "other":
                   // Server.Default.OE = value;
                    break;
                case "rent":
                    // Server.Default.OE = value;
                    break;
                case "purc":
                    //Server.Default.OE = value;
                    break;
                case "deposit":
                    //Server.Default.OE = value;
                    break;
                case "inter":
                    //Server.Default.OE = value;
                    break;
                case "months":
                    //Server.Default.OE = value;
                    break;
            }
        }
        /*
         * -------------------------------------------------------------------------------------------------------------------------->
         */
        /// <summary>
        /// This Method will take the main string of information and determine weither or not the info contains the command label
        /// if it happens to contain it, the sytem will take another step.
        /// </summary>
        private bool GetLabel(string input)
        {
            bool bWasSuccessful = false;
            try
            {
                /*
                 * Here we get the first character in the input string to check if its a "/" if not then its random stuff the 
                 * user is inputting and we dont need to worry about that.
                 */
                string label = input.Substring(0, 1);
                if (label.Equals("/"))
                {
                    bWasSuccessful = true;
                }
                else
                {
                    bWasSuccessful = false;
                }
            }
            catch (Exception ex)
            {

            }
            return bWasSuccessful;
        }
        /*
         * -------------------------------------------------------------------------------------------------------------------------->
         */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string GetCommand(string input)
        {
            string resultCommand = string.Empty;
            try
            {
                /*
                 * Here we remove empty spaces or unwanted characters from the input data, then we put the filtered data into
                 * a new list to find the command.
                 */
                foreach (var a in input.Split(spaces, StringSplitOptions.RemoveEmptyEntries))
                {
                    StringBuilder bb = new StringBuilder();
                    bb.Append(a);
                    items.Add(bb);
                }
                resultCommand = items[0].ToString();
                /*
                * Once we have found the command word, we then remove it from the list for the next few steps that follow.
                */
                if (!resultCommand.Equals(string.Empty))
                {
                    items.RemoveAt(0);
                }
                else
                {
                    resultCommand = string.Empty;
                }
            }
            catch (Exception ex)
            {

            }
            return resultCommand;
        }
    /*
     * -------------------------------------------------------------------------------------------------------------------------->
     */
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool GetArgs()
        {
            bool bWasSuccessful = false;
            try
            {
                foreach (StringBuilder ss in items)
                {
                    argsList.Add(ss);
                }
               argArray = argsList.ToArray();
            }
            catch (Exception ex)
            {

            }
            return bWasSuccessful;
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