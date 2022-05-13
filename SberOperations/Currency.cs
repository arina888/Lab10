using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberOperations
{
    public class Currency:Person
    {
        public string TypeofCurrency { get; set; }
        public static double ExchangeRate { get; set; }
       // public int Quantity { get; set; }

       public string TypeOfDeal { get; set; }

        //public Currency(string typeofcurrency, string typeofdeal,int quantity )
        //{
        //    TypeofCurrency = typeofcurrency;
        //    TypeOfDeal = typeofdeal;
        //    Quantity = quantity;
            
        //}
        public void Deal(string typeofcurrency, string typeofdeal)
        {
            TypeofCurrency = typeofcurrency;
            TypeOfDeal = typeofdeal;
           

            if (typeofcurrency == "EUR" && typeofdeal == "ПРОДАЖА")
            {
                Console.Write("АКТУАЛЬНЫЙ КУРС (ПРОДАЖА):");
                double exchangerate = 69.66;
                Console.WriteLine(exchangerate);
                Console.WriteLine("ВВЕДИТЕ КОЛИЧЕСТВО ВАЛЮТЫ,КОТОРОЕ ЖЕЛАЕТЕ ПРОДАТЬ:");
                int quantity = Convert.ToInt32(Console.ReadLine());//вводим количесвто валюты
               double y= quantity* exchangerate;//получите за продажу валюты
                Console.WriteLine($"{Math.Round(y)} рублей Вы получите за продажу валюты");
            }
            if (typeofcurrency == "EUR" && typeofdeal == "ПОКУПКА")
            {
                Console.Write("АКТУАЛЬНЫЙ КУРС (ПОКУПКА):");
                double exchangerate = 80.94;
                Console.WriteLine(exchangerate);
                Console.WriteLine("ВВЕДИТЕ КОЛИЧЕСТВО ВАЛЮТЫ,КОТОРОЕ ЖЕЛАЕТЕ КУПИТЬ:");
                int quantity = Convert.ToInt32(Console.ReadLine());//вводим количесвто валюты
                double y = quantity * exchangerate;//надо заплатить при покупке валюты
                Console.WriteLine($"{Math.Round(y)} рублей Вам надо заплатить за покупку валюты");
            }
            if (typeofcurrency == "USD" && typeofdeal == "ПОКУПКА")
            {
                Console.Write("АКТУАЛЬНЫЙ КУРС (ПОКУПКА):");
                double exchangerate = 76.92;
                Console.WriteLine(exchangerate);
                Console.WriteLine("ВВЕДИТЕ КОЛИЧЕСТВО ВАЛЮТЫ,КОТОРОЕ ЖЕЛАЕТЕ КУПИТЬ:");
                int quantity = Convert.ToInt32(Console.ReadLine());//вводим количесвто валюты
                double y = quantity * exchangerate;//надо заплатить при покупке валюты
                Console.WriteLine($"{Math.Round(y)} рублей Вам надо заплатить за покупку валюты");
            }
            if (typeofcurrency == "USD" && typeofdeal == "ПРОДАЖА")
            {
                Console.Write("АКТУАЛЬНЫЙ КУРС (ПРОДАЖА):");
                double exchangerate = 66.38;
                Console.WriteLine(exchangerate);
                Console.WriteLine("ВВЕДИТЕ КОЛИЧЕСТВО ВАЛЮТЫ,КОТОРОЕ ЖЕЛАЕТЕ ПРОДАТЬ:");
                int quantity = Convert.ToInt32(Console.ReadLine());//вводим количесвто валюты
                double y = quantity * exchangerate;//получите за продажу валюты
                Console.WriteLine($"{Math.Round(y)} рублей Вы получите за продажу валюты");
            }
            if (typeofcurrency == "CAD" && typeofdeal == "ПРОДАЖА")
            {
                Console.Write("АКТУАЛЬНЫЙ КУРС (ПРОДАЖА):");
                double exchangerate = 50.75;
                Console.WriteLine(exchangerate);
                Console.WriteLine("ВВЕДИТЕ КОЛИЧЕСТВО ВАЛЮТЫ,КОТОРОЕ ЖЕЛАЕТЕ ПРОДАТЬ:");
                int quantity = Convert.ToInt32(Console.ReadLine());//вводим количесвто валюты
                double y = quantity * exchangerate;//получите за продажу валюты
                Console.WriteLine($"{Math.Round(y)} рублей Вы получите за продажу валюты");
            }
             if (typeofcurrency == "CAD" && typeofdeal == "ПОКУПКА")
            {
                Console.Write("АКТУАЛЬНЫЙ КУРС (ПОКУПКА):");
                double exchangerate = 50.75;
                Console.WriteLine(exchangerate);
                Console.WriteLine("ВВЕДИТЕ КОЛИЧЕСТВО ВАЛЮТЫ,КОТОРОЕ ЖЕЛАЕТЕ КУПИТЬ:");
                int quantity = Convert.ToInt32(Console.ReadLine());//вводим количесвто валюты
                double y = quantity * exchangerate;

                Console.WriteLine($"{Math.Round(y)} рублей Вам надо заплатить за покупку валюты");

             }
        }
       
    }
}
