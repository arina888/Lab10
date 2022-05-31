using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberOperations
{
    public class IAC:Account
    {
        public int Id { get; set; }

        public int Contract { get; set; }
        public double Entered { get; set; }
        public double Summ { get; set; }
        public double Rate { get; set; }
        public double Left { get; set; }
        public string Status { get; set; }

        public static void AddInfo(double sum,string typeoperation,int contract, string fio,string status)
        {

            var path1 = "InformationAboutClients.csv";

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding = Encoding.GetEncoding(1251);

            var lines1 = File.ReadAllLines(path1, encoding);
            var iacs = new IAC[lines1.Length - 1];
            List<int> listI = new List<int>();
            for (int i = 1; i < lines1.Length; i++)
            {
                var splits = lines1[i].Split(';');

                var iac = new IAC();
                iac.Id = Convert.ToInt32(splits[0]);
                iac.FIO = splits[1];
                iac.Contract = Convert.ToInt32(splits[2]);
                iac.Summ = Convert.ToDouble(splits[3]);
                iac.Operation = splits[4];
                iac.Entered = Convert.ToDouble(splits[5]);
                iac.Rate = Convert.ToDouble(splits[6]);
                iac.Left= Convert.ToDouble(splits[7]);
                iac.Status = splits[8];
                listI.Add(Convert.ToInt32(splits[0]));
                iacs[i - 1] = iac;
            }

            if (typeoperation == "Кредит")

            {
                Console.WriteLine("Номер договора:");
                Console.WriteLine(contract);
                using (var writer = new StreamWriter(path1, true, encoding))

                {   var NewRecord = new List<IAC>()
                    {
                    new IAC { Id = listI.Count , FIO = fio,Contract = contract,Operation = "Кредит", Summ =  sum, Entered = 0, Rate = Credit.RateOfCredit,Left=sum,Status=status}
                    };
                    foreach (var k in NewRecord)
                    {
                        writer.WriteLine(k.ToExcel());
                    }

                }

            }
            if (typeoperation == "Ипотека")

            {
                Console.WriteLine("Номер договора:");
                Console.WriteLine(contract);
                using (var writer = new StreamWriter(path1, true, encoding))

                {
                    var NewRecord = new List<IAC>()
                    {
                    new IAC { Id = listI.Count , FIO = fio,Contract = contract,Operation = "Ипотека", Summ =  sum, Entered = 0, Rate = Credit.RateOfCredit,Left=sum,Status=status}
                    };
                    foreach (var k in NewRecord)
                    {
                        writer.WriteLine(k.ToExcel());
                    }

                }

            }
            if (typeoperation == "Депозит")
            {
                Console.WriteLine("Номер договора:");
                Console.WriteLine(contract);
        
                using (var writer = new StreamWriter(path1, true, encoding))

                {
                    var NewRecord = new List<IAC>()
                    {
                    new IAC { Id = listI.Count ,FIO = fio, Contract = contract,Operation = "Депозит",  Summ =  sum,Entered = 0, Rate = Deposit.RateOfDeposit,Left=0,Status=status}
                    };
                    foreach (var k in NewRecord)
                    {
                        writer.WriteLine(k.ToExcel());
                    }

                }
             }
            if (typeoperation == "Докладывание")
            {
                
                Random r = new Random();
                var selectinfo = from p in iacs
                                   where p.Contract == contract
                                   orderby p.Id
                                   select p;
                using (var writer = new StreamWriter(path1, true, encoding))

                {
                    foreach (var n in selectinfo)
                    {
                        var NewRecord = new List<IAC>()
                        {
                        new IAC { Id = listI.Count ,FIO = n.FIO, Contract = contract,Operation = n.Operation, Summ = n.Summ, Entered = sum, Rate = n.Rate,Left = n.Summ-sum,Status=status}
                        };
                        foreach (var k in NewRecord)
                        {
                            writer.WriteLine(k.ToExcel());
                        }
                        Console.WriteLine($"Осталось выплатить: {n.Summ-sum}") ;
                    }

                }
            }

        }
        public string ToExcel()
        {
            return $"{Id};{FIO};{Contract};{Summ};{Operation};{Entered};{Rate};{Left};{Status}";
        }
        
    }
}
