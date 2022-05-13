using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberOperations
{
    public class SavingAccount:Person
    {

        public int Term { get; set; }  //срок СЧЕТА
        public int Sum { get; set; } // сумма СЧЕТА

        public  static double Rate = 10;//ставка по СЧЕТУ

        public void FinalSum()// считаем конечную сумму на счете через Term месяцев
        {
            double x = Sum * (Math.Pow(Rate / (12 * 100) + 1, Term));
            Console.WriteLine($"Конечная сумма составит : {Math.Round(x)} рублей");
        }
        public override string ToString()
        {
            return $"Имя: {FirstName}\nФамилия: {LastName}\nДата рождения: {Birthday}\nСрок накопительного счета: {Term} (лет)\nСумма вложения: {Sum} руб.\nСтавка по депозиту : {Rate}";
        }

    }
}
