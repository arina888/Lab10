using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberOperations
{
    public class Mortgage:Person
    {
        public int Term { get; set; }  //срок ипотеки
        public int Sum { get; set; } // сумма ипотеки
       
        public static double Rate = 15.0;//ставка по кредиту

        public void FirstPayment()
        {
            double y = (Sum * 20)/100.0;
            Console.WriteLine($"Первый взнос составит : {Math.Round(y)} рублей");
        }
        public void Payment()
        {
            double x = Sum * ((Rate / (100.0*12))  / (1-((1 + Rate / (100.0* 12 )* (1-Term*12))))) ;
            Console.WriteLine($"Ежемесячный платеж составит : {Math.Round(x)} рублей");
        }
        public override string ToString()
        {
            return $"Имя: {FirstName}\nФамилия: {LastName}\nДата рождения: {Birthday}\nСрок ипотеки: {Term} (лет)\nСумма ипотеки: {Sum} руб.\nИпотечная ставка : {Rate}";
        }
        public string ToExcel()
        {
            return $"{FirstName};{LastName};{Birthday};Ипотека;{Term};{Sum};{Rate}";
        }
    }
}
