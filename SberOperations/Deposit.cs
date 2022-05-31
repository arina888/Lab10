using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberOperations
{
    public class Deposit:Account
    {
        public int TermOfDeposit { get; set; }  //срок депозита
        public int Contract { get; set; }
        public double SumOfDeposit { get; set; } // сумма депозита

        public static double RateOfDeposit = 9.07;//ставка по депозиту

        public void MakeADeposit()
        {
            Deposit deposit = new Deposit();
            Account account = new Account();
            
            Console.WriteLine("Введите ФИО:");
            account.FIO = Console.ReadLine().ToUpper();//фио

            Console.WriteLine("Введите дату рождения через точку:");
            account.Birthday = Convert.ToDateTime(Console.ReadLine());// дата рождения
            
            Console.WriteLine("Введите сумму вложения:");
            double sum = Convert.ToDouble(Console.ReadLine());
            deposit.SumOfDeposit = sum; //вводим сумму вклада
            Random r = new Random();    
            deposit.Contract = r.Next(10000, 99999);

            Console.WriteLine("Депозит создан.Благодарим Вас за пользование услуг нашего банка.");
           
            IAC.AddInfo(deposit.SumOfDeposit,"Депозит", deposit.Contract, account.FIO, "Операция прошла");
            

            Bank.ChangeBank(sum, "Депозит");

        }
        public void FinalSum()// считаем конечную сумму по вкладу через Term месяцев
        {
            double x = SumOfDeposit * (Math.Pow(RateOfDeposit / (12*100)+ 1, TermOfDeposit));
            Console.WriteLine($"Конечная сумма составит : {Math.Round(x)} рублей");
        }
        public void AddSum(int contr)// считаем конечную сумму по вкладу через Term месяцев после докладывания
        {Account account = new Account();
            Console.WriteLine("Введите сумму которую хотите внести:");
            double summ = Convert.ToDouble(Console.ReadLine());
            Bank.ChangeBank(summ,"Депозит") ;
            double x = (SumOfDeposit + summ) * (Math.Pow(RateOfDeposit / (12 * 100) + 1, TermOfDeposit));
            Console.WriteLine($"Конечная сумма составит : {Math.Round(x)} рублей");
            IAC.AddInfo(SumOfDeposit, "Депозит", contr, account.FIO, "Операция прошла");
        }
      
        
    }


}
