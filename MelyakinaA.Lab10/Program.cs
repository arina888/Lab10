using SberOperations;


Console.WriteLine("Добро пожаловать в Банк! Выберите операцию для совершения действий:");
Console.WriteLine("1.Операции по вкладу");
Console.WriteLine("2.Операции с валютой");
Console.WriteLine("3.Операции по кредиту");
Console.WriteLine("4.Операции по дебетовой карте");
Console.WriteLine("5.Операции по ипотеке");
Console.WriteLine("Введите порядковый номер операции...");
int x = Convert.ToInt32(Console.ReadLine());

while (x != 0)
{

    if (x == 1)
    {
                Deposit deposit = new Deposit();
                deposit.MakeADeposit();
  
    }

    if (x == 2)
    {
        Console.WriteLine("Выберите операцию: покупка или продажа");
        switch (Console.ReadLine().ToUpper())
        {
            case "ПОКУПКА":
                Currency.Buy();

                break;
            case "ПРОДАЖА":
                Currency.Sell();

                break;
        }
    }

    if (x == 3)
    {
        Console.WriteLine("Выберите операцию,которую хотите осуществить: ");
        Console.WriteLine("1.Взять кредит,");
        Console.WriteLine("2.Добавить сумму");
        Console.WriteLine("Введите номер операции...");
        switch (Console.ReadLine())
        {
            case "1":

                Credit credit = new Credit();
                credit.TakeACredit();

                break;

            case "2":
                Credit credit1 = new Credit();
                Console.WriteLine("Введите номер договора...");
                credit1.Contract = Convert.ToInt32(Console.ReadLine());
                credit1.AddSum(credit1.Contract);
                break;
           
        }


    }

    if (x == 4)
    {
        Console.WriteLine("Выберите операцию,которую хотите осуществить по дебетовой карте: пополнение, снятие ");
        switch (Console.ReadLine().ToUpper())
        {
            case "ПОПОЛНЕНИЕ":

                OperationWithAccount operationWithAccount = new OperationWithAccount();
                operationWithAccount.Put();

                break;

            case "СНЯТИЕ":
                OperationWithAccount operationWithAccount1 = new OperationWithAccount();
                operationWithAccount1.Take();
                break;
        }
    }
    if (x == 5)
    {

        Console.WriteLine("Выберите операцию,которую хотите осуществить: ");
        Console.WriteLine("1.Взять Ипотеку,");
        Console.WriteLine("2.Добавить сумму");
        Console.WriteLine("Введите номер операции...");
        switch (Console.ReadLine())
        {
            case "1":

                Mortgage mortgage = new Mortgage();
                mortgage.TakeAMortgage();

                break;

            case "2":
                Mortgage mortgage1 = new Mortgage(); 
                Console.WriteLine("Введите номер договора...");
                mortgage1.Contract = Convert.ToInt32(Console.ReadLine());
                mortgage1.AddSum(mortgage1.Contract);
                break;
            
        }


    }
    Console.WriteLine("Желате продолжить?");
    string answ = Console.ReadLine().ToUpper();
    if (answ == "ДА")
    {
        Console.WriteLine("Выберите операцию для совершения действий:");

        Console.WriteLine("1.Операции по вкладу");
        Console.WriteLine("2.Операции с валютой");
        Console.WriteLine("3.Операции по кредиту");
        Console.WriteLine("4.Операции по дебетовой карте");
        Console.WriteLine("5.Операции по ипотеке");
        Console.WriteLine("Введите порядковый номер операции...");
        x = Convert.ToInt32(Console.ReadLine());

    }
    if (answ == "НЕТ")
    {
        x = 0;
    }  
    
}
Console.WriteLine("Спасибо за пользованием услугами банка! До свидания!");

