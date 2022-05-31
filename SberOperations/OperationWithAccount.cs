using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberOperations
{
        public class OperationWithAccount:Debets
        {
            public  delegate void AccountHandler(string message);
            public  event AccountHandler? Notify;

            public  event AccountHandler? TakeNotify;
            public  event AccountHandler? PutNotify;


            AccountHandler? notify;
            public event AccountHandler? NotifyWithManage
            {
                add
                {
                    notify += value;
                    //Console.WriteLine($"{value.Method.Name} добавлен");
                }
                remove
                {
                    notify -= value;
                    //Console.WriteLine($"{value.Method.Name} удален");
                }
            }

            public void Put()
            {
            Account account = new Account();
            Debets debet = new Debets();
            PutNotify += DisplayGreenMessage;

            //Console.WriteLine("Введите ФИО:");
            //account.FIO = Console.ReadLine().ToUpper();//фио

            Console.WriteLine("Введите номер карты (не более 16 цифр):");
            string req  = Console.ReadLine();
            debet.Requisites= req; 
            
            if (req.Length >= 16)
            {
                Console.WriteLine("Неверный номер карты.Повторите попытку."); 
                req = Console.ReadLine();
            }

            Console.WriteLine("Введите сумму,которую хотите внести:");
            debet.Sum = Convert.ToDouble(Console.ReadLine());
            
            
                Notify?.Invoke($"На счет поступило: { debet.Sum}");
                PutNotify?.Invoke($"На счет поступило: { debet.Sum}");

                notify?.Invoke($"На счет поступило: { debet.Sum}");
                
                debet.ChangeDebets(debet.Sum,"Пополнение",req);
            //Console.WriteLine($"На счет поступило: {sum}");
            }

        public void Take()
        {
            Account account = new Account();
            Debets debet1 = new Debets();
            TakeNotify += DisplayRedMessage;

            Console.WriteLine("Введите номер карты (не более 16 цифр):");
            string req1 = Console.ReadLine();
            debet1.Requisites = req1;
            if (req1.Length >= 16)
            {
                Console.WriteLine("Неверный номер карты.Повторите попытку.");
                req1 = Console.ReadLine();
            }


            Console.WriteLine("Введите сумму,которую хотите снять:");
            debet1.Sum = Convert.ToDouble(Console.ReadLine());

                Notify?.Invoke($"Со счета снято: {debet1.Sum}");
                TakeNotify?.Invoke($"Со счета снято: {debet1.Sum}");

                notify?.Invoke($"Со счета снято: {debet1.Sum}");
                debet1.ChangeDebets(debet1.Sum, "Снятие", req1);
                
            
        
               
            
        }
        public static void Account_Notify(string message)
        {
            Console.WriteLine(message);
        }

        public static void DisplayRedMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void DisplayGreenMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
 
}