using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHelper.Classes
{
    class PrintClass
    {
        public void PrintGeneral(string value)
        {
            Console.WriteLine(value);
        }
        public void PrintBalance(int printType, double value)
        {
            try
            {
                string message = string.Empty;
                switch (printType)
                {
                    case 0:
                        message = string.Format("Your balace after expenses is R{0}",value);
                        Console.WriteLine(message);
                        break;
                    case 1:
                        message = string.Format("Your balace after rent is R{0}", value);
                        Console.WriteLine(message);
                        break;
                    case 2:
                        message = string.Format("Your balace after purchase is R{0}", value);
                        Console.WriteLine(message);
                        break;
                }
            }
            catch (Exception ex)
            {

            }
           
        }
        public void PrintHelp()
        {

        }
    }
}
