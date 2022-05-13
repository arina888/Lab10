namespace SberOperations
{

    public class Credit : Person
    {

        public int TermOfCredit { get; set; }  //срок кредитования
        public int SumOfCredit { get; set; } // сумма кредита
        public string Object { get; set; } // объект кредитования
        public static double RateOfCredit = 13;//ставка по кредиту

        

        public void Payment()
        {
            double x = SumOfCredit * ((RateOfCredit / 100.0) + (RateOfCredit / 100.0) / ((Math.Pow(1 + RateOfCredit / 100.0, 12 * TermOfCredit) - 1)));
            Console.WriteLine($"Ежемесячный платеж составит : {Math.Round(x)} рублей");
        }
        public override string ToString()
        {
            return $"Имя: {FirstName}\nФамилия: {LastName}\nДата рождения: {Birthday}\nСрок кредитования: {TermOfCredit * 12} (месяц.)\nСумма кредита: {SumOfCredit} руб.\nОбъект кредитования: {Object}\nПроцентная ставка по кредиту: {RateOfCredit}";
        }
        public string ToExcel()
        {
            return $"{FirstName};{LastName};{Birthday};Кредит;{TermOfCredit};{SumOfCredit};{Object};{RateOfCredit}";
        }
    }
    

}

     
