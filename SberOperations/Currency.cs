using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberOperations
{
    public class Currency : Account
    {
        public static double SellRateUSD = 60.64;
        public static double BuyRateUSD = 70.38;
        public static double SellRateEUR = 63.49;
        public static double BuyRateEUR = 74.02;
        public static double SellRateCAD = 46.56;
        public static double BuyRateCAD = 59.73;

        public static void Buy()
        {

            Console.WriteLine("Введите обозначение валюты,которую хотите купить(USD - доллар, EUR - евро, CAD - канадский доллар)");
            string typeofcurrency = Console.ReadLine().ToUpper();
            if (typeofcurrency == "USD")
            {
                Console.WriteLine("Введите количество валюты,которую хотите купить:");
                double s = Convert.ToDouble(Console.ReadLine());
               
                Bank.ChangeBank(s, "ПокупкаUSD");
            }
            if (typeofcurrency == "EUR")
            {
                Console.WriteLine("Введите количество валюты,которую хотите купить:");
                double s = Convert.ToDouble(Console.ReadLine());
               
                Bank.ChangeBank(s, "ПокупкаEUR");
            }

            if (typeofcurrency == "CAD")
            {
                double s = Convert.ToDouble(Console.ReadLine());
               
                Bank.ChangeBank(s, "ПокупкаCAD");
            }

        }

        public static void Sell()
        {

            Console.WriteLine("Введите обозначение валюты,которую хотите продать (USD - доллар, EUR - евро, CAD - канадский доллар)");
            string typeofcurrency = Console.ReadLine();
            if (typeofcurrency == "USD")
            {
                Console.WriteLine("Введите количество валюты,которую хотите продать:");
                double s = Convert.ToDouble(Console.ReadLine());
               
                Bank.ChangeBank(s, "ПродажаUSD");
            }
            if (typeofcurrency == "EUR")
            {
                Console.WriteLine("Введите количество валюты,которую хотите продать:");
                double s = Convert.ToDouble(Console.ReadLine());
               
                Bank.ChangeBank(s, "ПродажаEUR");
            }

            if (typeofcurrency == "CAD")
            {
                Console.WriteLine("Введите количество валюты,которую хотите продать:");
                double s = Convert.ToDouble(Console.ReadLine());
                
                Bank.ChangeBank(s, "ПродажаCAD");
            }


        }


    }
}

