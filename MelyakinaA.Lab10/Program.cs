using SberOperations;

Console.WriteLine("ДОБРО ПОЖАЛОВАТЬ В СБЕРБАНК! ВЫБЕРИТЕ ОПЕРАЦИЮ ДЛЯ СОВЕРШЕНИЯ СДЕЛКИ: КРЕДИТ,ОТКРЫТИЕ ВКЛАДА,ИПОТЕКА,ОТКРЫТИЕ НАКОПИТЕЛЬНОГО СЧЕТА");

Console.WriteLine("ДЛЯ ВЫБОРА ОПЕРАЦИИ ВВЕДИТЕ К - КРЕДИТ, ВКЛ - ВКЛАД, И - ИПОТЕКА,НС - НАКОПИТЕЛЬНЫЙ СЧЕТ, ВАЛ - ВАЛЮТА");
string str = Console.ReadLine().ToUpper();
switch (str)
{
    case "К":
        Credit credit = new Credit();

        Console.WriteLine("ВВЕДИТЕ ВАШЕ ИМЯ:");
        credit.FirstName = Console.ReadLine().ToUpper(); //имя берущего в кредит

        Console.WriteLine("ВВЕДИТЕ ВАШУ ФАМИЛИЮ:");
        credit.LastName = Console.ReadLine().ToUpper();//фамилия

        Console.WriteLine("ВВЕДИТЕ ДАТУ РОЖДЕНИЯ ЧЕРЕЗ ТОЧКУ:");
        credit.Birthday = Convert.ToDateTime(Console.ReadLine());// дата рождения


        Console.WriteLine("ВВЕДИТЕ СРОК КРЕДИТА(не более 5 лет):");
        int term = Convert.ToInt32(Console.ReadLine());
        credit.TermOfCredit = term; //вводим срок кредитования

        while (term > 5)
        {
            Console.WriteLine("СРОК КРЕДИТА НЕ МОЖЕТ ПРЕВЫШАТЬ 5 ЛЕТ. ПОВТОРИТЕ ПОПЫТКУ.");
            term = Convert.ToInt32(Console.ReadLine());
        }


        Console.WriteLine("ВВЕДИТЕ СУММУ КРЕДИТА:");
        int sum = Convert.ToInt32(Console.ReadLine());
        credit.SumOfCredit = sum; //вводим сумму кредитования

        while (sum > 8000000)
        {
            Console.WriteLine("СУММА КРЕДИТА НЕ МОЖЕТ ПРЕВЫШАТЬ  8 МЛН. РУБ. . ПОВТОРИТЕ ПОПЫТКУ.");
            sum = Convert.ToInt32(Console.ReadLine());
        }


        Console.WriteLine("ВВЕДИТЕ ПРЕДМЕТ КРЕДИТОВАНИЯ:");
        credit.Object = Console.ReadLine().ToUpper(); //вводим объект кредитования

        Console.WriteLine();
        Console.WriteLine("Подтверждаем информацию...");
        Console.WriteLine();

        Console.WriteLine(credit.ToString());
        credit.Payment();//выводим ежемесячный платеж

        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine();
        break;

    case "ВКЛ":

        Contribution contrib = new Contribution();

        Console.WriteLine("ВВЕДИТЕ ВАШЕ ИМЯ:");
        contrib.FirstName = Console.ReadLine().ToUpper() ;//имя вкладчика
        Console.WriteLine("ВВЕДИТЕ ВАШУ ФАМИЛИЮ:");//фамилия
        contrib.LastName = Console.ReadLine().ToUpper();//фамилия
        Console.WriteLine("ВВЕДИТЕ ДАТУ РОЖДЕНИЯ ЧЕРЕЗ ТОЧКУ:");
        contrib.Birthday = Convert.ToDateTime(Console.ReadLine()); ;// дата рождения
        Console.WriteLine("ВВЕДИТЕ СРОК ДЕПОЗИТА В МЕСЯЦАХ(не менее 3 месяцев):");
        int term1 = Convert.ToInt32(Console.ReadLine());
        contrib.Term = term1; //вводим срок кредитования

        while (term1 < 3)
        {
            Console.WriteLine("СРОК ДЕПОЗИТА НЕ МОЖЕТ БЫТЬ МЕНЬШЕ 3 МЕСЯЦЕВ. ПОВТОРИТЕ ПОПЫТКУ.");
            term = Convert.ToInt32(Console.ReadLine());
        }


        Console.WriteLine("ВВЕДИТЕ СУММУ КРЕДИТА:");
        int sum1 = Convert.ToInt32(Console.ReadLine());
        contrib.Sum = sum1; //вводим сумму кредитования

        while (sum1 < 30000)
        {
            Console.WriteLine("НАЧАЛЬНАЯ СУММА ДЕПОЗИТА НЕ МОЖЕТ БЫТЬ МЕНЬШЕ  30 ТЫС. РУБ. . ПОВТОРИТЕ ПОПЫТКУ.");
            sum = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine();
        Console.WriteLine("Подтверждаем информацию...");
        Console.WriteLine();

        Console.WriteLine(contrib.ToString());//принтуем данные
        contrib.FinalSum();//сумма на выходе с процентами

        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine();

        break;

    case "И":
        Mortgage mortgage = new Mortgage();

        Console.WriteLine("ВВЕДИТЕ ВАШЕ ИМЯ:");
        mortgage.FirstName = Console.ReadLine().ToUpper(); //имя берущего в кредит

        Console.WriteLine("ВВЕДИТЕ ВАШУ ФАМИЛИЮ:");
        mortgage.LastName = Console.ReadLine().ToUpper();//фамилия

        Console.WriteLine("ВВЕДИТЕ ДАТУ РОЖДЕНИЯ ЧЕРЕЗ ТОЧКУ:");
        mortgage.Birthday = Convert.ToDateTime(Console.ReadLine());// дата рождения


        Console.WriteLine("ВВЕДИТЕ СРОК ИПОТЕКИ(не более 30 лет):");
        int term2 = Convert.ToInt32(Console.ReadLine());
        mortgage.Term = term2; //вводим срок кредитования

        while (term2 > 30)
        {
            Console.WriteLine("СРОК ИПОТЕКИ НЕ МОЖЕТ ПРЕВЫШАТЬ 30 ЛЕТ. ПОВТОРИТЕ ПОПЫТКУ.");
            term2 = Convert.ToInt32(Console.ReadLine());
        }


        Console.WriteLine("ВВЕДИТЕ СУММУ ИПОТЕКИ:");
        int sum2 = Convert.ToInt32(Console.ReadLine());
        mortgage.Sum = sum2; //вводим сумму кредитования

        while (sum2 > 100000000)
        {
            Console.WriteLine("СУММА ИПОТЕКИ НЕ МОЖЕТ ПРЕВЫШАТЬ  100 МЛН. РУБ. . ПОВТОРИТЕ ПОПЫТКУ.");
            sum2 = Convert.ToInt32(Console.ReadLine());
        }


        Console.WriteLine();
        Console.WriteLine("Подтверждаем информацию...");
        Console.WriteLine();

        Console.WriteLine(mortgage.ToString());
        mortgage.Payment();//выводим ежемесячный платеж
        mortgage.FirstPayment();

        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine();

        break;


    case "НС":

        SavingAccount savingaccount = new SavingAccount();

        Console.WriteLine("ВВЕДИТЕ ВАШЕ ИМЯ:");
        savingaccount.FirstName = Console.ReadLine().ToUpper(); //имя берущего в кредит

        Console.WriteLine("ВВЕДИТЕ ВАШУ ФАМИЛИЮ:");
        savingaccount.LastName = Console.ReadLine().ToUpper();//фамилия

        Console.WriteLine("ВВЕДИТЕ ДАТУ РОЖДЕНИЯ ЧЕРЕЗ ТОЧКУ:");
        savingaccount.Birthday = Convert.ToDateTime(Console.ReadLine());// дата рождения


        Console.WriteLine("ВВЕДИТЕ СРОК НАКОПИТЕЛЬНОГО СЧЕТА:");
        int term3 = Convert.ToInt32(Console.ReadLine());
        savingaccount.Term = term3; //вводим срок кредитования


        Console.WriteLine("ВВЕДИТЕ СУММУ НАКОПИТЕЛЬНОГО СЧЕТА:");
        int sum3 = Convert.ToInt32(Console.ReadLine());
        savingaccount.Sum = sum3; //вводим сумму кредитования

        Console.WriteLine();
        Console.WriteLine("Подтверждаем информацию...");
        Console.WriteLine();

        Console.WriteLine(savingaccount.ToString());
        savingaccount.FinalSum();

        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine();

        break;

    case "ВАЛ":

        Currency cur = new Currency();
        
        Console.WriteLine("ВВЕДИТЕ ВАШЕ ИМЯ:");
        cur .FirstName = Console.ReadLine().ToUpper(); //имя 

        Console.WriteLine("ВВЕДИТЕ ВАШУ ФАМИЛИЮ:");
        cur.LastName = Console.ReadLine().ToUpper();//фамилия

        Console.WriteLine("ВЫБЕРИТЕ ВАЛЮТУ ДЛЯ СОВЕРШЕНИЯ ОПЕРАЦИИ: USD - ДОЛЛАР США, EUR - ЕВРО, CAD - КАНАДСКИЙ ДОЛЛАР");
        string typeofcurrency = Console.ReadLine().ToUpper();
        cur.TypeofCurrency = typeofcurrency; //ВАЛЮТА

        Console.WriteLine("ВЫБЕРИТЕ ВИД СДЕЛКИ: ПРОДАЖА, ПОКУПКА");
        string typeofdeal = Console.ReadLine().ToUpper();
        cur.TypeOfDeal= typeofdeal;//СДЕЛКА

        cur.Deal(typeofcurrency,typeofdeal);

        break; 
}



