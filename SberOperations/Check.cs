using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SberOperations;

namespace SberOperations
{
    public interface Check
    {
        public static bool CheckClientCredit(Account account, Credit credit)
        {
            
            bool payposs = 2 * account.Wage >= Credit.MonthlyPayment(credit);
            return payposs;

        }
        public static bool CheckClientMortgage(Account account, Mortgage mortgage)
        {
            bool payposs = 2 * account.Wage >= Mortgage.MonthlyPayment(mortgage.SumOfMortgage);
            return payposs;


        }
        //public static bool CheckBankCred(Credit credit)
        //{
        //    return Bank.Rubles >= credit.SumOfCredit;

        //}
        //public static bool CheckBankMortgage( Mortgage mortgage)
        //{
            
        //    return Bank.Rubles >= mortgage.SumOfMortgage;

        
        //}

    }
}
