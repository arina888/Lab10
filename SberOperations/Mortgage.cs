using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberOperations
{
    public class Mortgage:Account
    {
        public int TermOfMortgage { get; set; }  //срок ипотеки
        public double SumOfMortgage { get; set; } // сумма ипотеки
       
        public static double RateOfMortgage = 15.0;//ставка по ипотеке
        public int Contract { get; set; }
        public string Status { get; set; }
        public void TakeAMortgage()
        {
            Mortgage mortgage = new Mortgage();
            Account account = new Account();
            Console.WriteLine("Введите ФИО:");
            account.FIO = Console.ReadLine().ToUpper();//фио

            Console.WriteLine("Введите дату рождения через точку:");
            account.Birthday = Convert.ToDateTime(Console.ReadLine());// дата рождения
            Console.WriteLine("Введите Вашу заработную плату");
            account.Wage = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Введите сумму ипотеки:");
            double sum = Convert.ToDouble(Console.ReadLine());
            mortgage.SumOfMortgage = sum; //вводим сумму ипотеки

            while (sum > 30000000)
            {
                Console.WriteLine("Сумма ипотеки не может превышать 30 млн руб . Повторите попытку.");
                sum = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine("Введите срок ипотеки(не более 30 лет):");
            int term = Convert.ToInt32(Console.ReadLine());
            mortgage.TermOfMortgage = term; //вводим срок ипотеки

            while (term > 30)
            {
                Console.WriteLine("Срок ипотеки не может превышать 30 лет.Потворите попытку.");
                term = Convert.ToInt32(Console.ReadLine());
            }
            Random r = new Random();
            mortgage.Contract = r.Next(10000, 99999);
            if (Check.CheckClientMortgage(account, mortgage) == true)
            { 
              Bank.ChangeBank(sum, "Ипотека");
                mortgage.Status = "Операция прошла";
            }
            else
            {
                Console.Write("Ипотека не одобрена.");
                mortgage.Status = "Операция не прошла";

            }
            IAC.AddInfo(mortgage.SumOfMortgage,"Ипотека", mortgage.Contract, account.FIO, mortgage.Status);

        }
        public void FirstPayment()
        {
            Mortgage mortgage = new Mortgage();
            double y = (mortgage.SumOfMortgage * 20)/100.0;
            Console.WriteLine($"Первый взнос составит : ");
            Console.WriteLine(Math.Round(y));
        }
        public static double MonthlyPayment(double sumofmortgage)
        {   Mortgage mortgage = new Mortgage();
            mortgage.SumOfMortgage = sumofmortgage;
            double x = sumofmortgage * ((RateOfMortgage / (100.0*12))  / (1-((1 + RateOfMortgage / (100.0* 12 )* (1- mortgage.TermOfMortgage * 12))))) ;
            return x;
        }

        public void AddPayment(int contract)
        {
            Mortgage mortgage = new Mortgage();
            Account account = new Account();

            double y = MonthlyPayment(mortgage.SumOfMortgage);
            Bank.ChangeBank(y, "Депозит");
           
            IAC.AddInfo(y, "Докладывание", contract, account.FIO,"Операция прошла");

        }
        public void AddSum(int contract)
        {
            Mortgage mortgage = new Mortgage();
            Account account = new Account();
            Console.WriteLine("Введите сумму которую хотите внести:");
            double sum2 = Convert.ToDouble(Console.ReadLine());
         
            
            Bank.ChangeBank(sum2, "Депозит");
            double x = (mortgage.SumOfMortgage - sum2) * ((RateOfMortgage / 100.0) + (RateOfMortgage / 100.0) / ((Math.Pow(1 + RateOfMortgage / 100.0, 12 * mortgage.TermOfMortgage) - 1)));
            //Console.WriteLine($"Сделан перерасчет. Ежемесячный платеж составит : ");
            //Console.WriteLine(Math.Round(x));
            IAC.AddInfo(sum2, "Докладывание", contract, account.FIO, "Операция прошла");
        }
    }
}
