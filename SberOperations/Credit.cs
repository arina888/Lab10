namespace SberOperations
{
    public class Credit : Check
    {
        public int TermOfCredit { get; set; }  //срок кредитования
        public  double SumOfCredit { get; set; } // сумма кредита
        public int Contract { get; set; }
        public string ObjectOfCredit { get; set; } // объект кредитования
        public static double RateOfCredit = 13;//ставка по кредиту
        public string Status { get; set; }
        public static double MonthlyPayment(Credit credit)
        {
            double x = credit.SumOfCredit * ((RateOfCredit / 100.0) + (RateOfCredit / 100.0) / ((Math.Pow(1 + RateOfCredit / 100.0, 12 * credit.TermOfCredit) - 1)));
            return x;
        }
        public void AddPayment(int contr)
        {Credit credit = new Credit();  
            Account account = new Account();
            
            double y = credit.SumOfCredit - credit.SumOfCredit * ((RateOfCredit / 100.0) + (RateOfCredit / 100.0) / ((Math.Pow(1 + RateOfCredit / 100.0, 12 * credit.TermOfCredit) - 1)));
            
            double x = credit.SumOfCredit * ((RateOfCredit / 100.0) + (RateOfCredit / 100.0) / ((Math.Pow(1 + RateOfCredit / 100.0, 12 * credit.TermOfCredit) - 1)));
            IAC.AddInfo(x, "Докладывание", contr, account.FIO,"Операция прошла");
            Bank.ChangeBank(x, "Депозит");
        }
        public void AddSum(int contr)
        {
            Account account = new Account();
            Console.WriteLine("Введите сумму, которую хотите внести:");
            double sum2 = Convert.ToDouble(Console.ReadLine());
            
            IAC.AddInfo(sum2, "Докладывание", contr, account.FIO, "Операция прошла");
            double y = SumOfCredit - sum2;
            Bank.ChangeBank(sum2, "Депозит");
            double x = (SumOfCredit - sum2) * ((RateOfCredit / 100.0) + (RateOfCredit / 100.0) / ((Math.Pow(1 + RateOfCredit / 100.0, 12 * TermOfCredit) - 1)));
            //Console.WriteLine($"Сделан перерасчет. Ежемесячный платеж составит :");
            //Console.WriteLine(Math.Round(x));
            
        }
        public void TakeACredit()
        {
            Credit credit = new Credit();
            Account account = new Account();
            Console.WriteLine("Введите ФИО:");
            account.FIO = Console.ReadLine().ToUpper();//фио

            Console.WriteLine("Введите дату рождения через точку:");
            account.Birthday = Convert.ToDateTime(Console.ReadLine());// дата рождения
            Console.WriteLine("Введите Вашу заработную плату");
            account.Wage = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите срок кредита(не более 5 лет):");
            int term = Convert.ToInt32(Console.ReadLine());
            credit.TermOfCredit = term; //вводим срок кредитования

            while (term > 5)
            {
                Console.WriteLine("Срок кредита не может превышать 5 лет. Повторите попытку.");
                term = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Введите сумму кредита:");
            double sum = Convert.ToDouble(Console.ReadLine());
            credit.SumOfCredit = sum; //вводим сумму кредитования

            while (sum > 8000000)
            {
                Console.WriteLine("Сумма кредита не может превышать 8 млн руб .Повторите попытку.");
                sum = Convert.ToDouble(Console.ReadLine());
            }
            Random r = new Random();
            Console.WriteLine("Введите предмет кредитования:");
            credit.ObjectOfCredit = Console.ReadLine().ToUpper(); //вводим объект кредитования
            credit.Contract = r.Next(10000, 99999);
            if (Check.CheckClientCredit(account, credit) == true)
            { 
                Bank.ChangeBank(sum,"Кредит");
                credit.Status = "Операция прошла";
            }
            else
            {
                Console.Write("Кредит не одобрен." );
                credit.Status = "Операция не прошла";
                
            }IAC.AddInfo(credit.SumOfCredit, "Кредит", credit.Contract, account.FIO,credit.Status);

        }
    }
}

     
