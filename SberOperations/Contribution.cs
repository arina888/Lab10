using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberOperations
{
    public class Contribution:Person
    {
        public int Term { get; set; }  //срок депозита
        public int Sum { get; set; } // сумма депозита

        public static double Rate = 9.07;//ставка по депозиту
        public void FinalSum()// считаем конечную сумму по вкладу через Term месяцев
        {
            double x = Sum * (Math.Pow(Rate / (12*100)+ 1,Term));
            Console.WriteLine($"Конечная сумма составит : {Math.Round(x)} рублей");
        }
        public override string ToString()
        {
            return $"Имя: {FirstName}\nФамилия: {LastName}\nДата рождения: {Birthday}\nСрок депозита: {Term} месяцев\nСумма вложений: {Sum}\nПроцентная ставка по депозиту: {Rate}";
        }
        public string ToExcel()
        {
            return $"{FirstName};{LastName};{Birthday};Вклад;{Term};{Sum};{Rate}";
        }
    }

}
