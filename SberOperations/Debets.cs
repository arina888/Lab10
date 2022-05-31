using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberOperations
{
    public class Debets : Account
    {
        public double Balance { get; set; }
        public int Id { get; set; }
        public string Requisites { get; set; }
        public double Sum { get; set; }
        public void ChangeDebets(double sum, string typeoperation, string req)
        {
            var path1 = "Debets.csv";

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding1 = Encoding.GetEncoding(1251);

            var lines1 = File.ReadAllLines(path1, encoding1);
            var debet = new Debets[lines1.Length - 1];
            
            List<int> listI=new List<int>();  
            for (int i = 1; i < lines1.Length; i++)
            {
                var splits = lines1[i].Split(';');

                var debets = new Debets();
                debets.Id = Convert.ToInt32(splits[0]);
                debets.Requisites = splits[1];
                debets.Balance = Convert.ToDouble(splits[2]);
                debets.Operation = splits[3];
                listI.Add(Convert.ToInt32(splits[0]));
                    
                debet[i - 1] = debets;
            }

            if (typeoperation == "Пополнение")
            {
                var selectdebet1 = from p in debet
                                   where p.Requisites == req
                                   orderby p.Id
                                   select p;
                var selectdebet = selectdebet1.TakeLast(1);
                // var selectdebet = debet.GroupBy(l => l.Requisites).Where(a => a.Requisites==req).Select(g => g.OrderByDescending(c => c.ID).FirstOrDefault());

                if (selectdebet?.Any() == false)
                {

                    using (var writer = new StreamWriter(path1, true, encoding1))

                    {
                        var NewRecord = new List<Debets>()
                        {
                        new Debets { Id = listI.Count , Requisites = req, Balance = sum, Operation = "Пополнение", Sum = sum }
                        };
                        foreach (var k in NewRecord)
                        {
                            writer.WriteLine(k.ToExcel());
                        }    Console.WriteLine($"Счет создан и пополнен.Текущий баланс: {Balance}");

                    }
                
                }
                if (selectdebet?.Any() == true)
                {
                        using (var writer = new StreamWriter(path1, true, encoding1))

                        {
                            foreach (var n in selectdebet)
                            {
                                var NewRecord = new List<Debets>()
                                {
                                 new Debets { Id = listI.Count, Requisites = req, Balance = n.Balance + sum, Operation = "Пополнение", Sum = sum }
                                 };
                                foreach (var k in NewRecord)
                                {
                                    writer.WriteLine(k.ToExcel());
                                } Console.WriteLine($"Текущий баланс: {n.Balance + sum}");
                            }
                        }
                   
                }
                
            }


            if (typeoperation == "Снятие")
            {
                var selectdebet1 = from p in debet
                                   where p.Requisites == req
                                   orderby p.Id
                                   select p;
                var selectdebet = selectdebet1.TakeLast(1);

                if (selectdebet?.Any() == false)
                {

                    using (var writer = new StreamWriter(path1, true, encoding1))

                    {
                        var NewRecord = new List<Debets>()
                            {
                        new Debets { Id =listI.Count, Requisites = req, Balance = 0, Operation = "Снятие", Sum = 0 }
                             };
                        foreach (var k in NewRecord)
                        {
                            writer.WriteLine(k.ToExcel());
                        } Console.WriteLine($"Снять средства не удается,так как счет только что был добавлен в базу данных. Текущий баланс: {Balance}");

                    }
                   
                }

                if (selectdebet?.Any() == true)
                {
                    using (var writer = new StreamWriter(path1, true, encoding1))
                    {
                        foreach (var s in selectdebet)
                        {if (s.Balance < sum)
                            {
                                Console.WriteLine($"Недостаточно средств.Текущий баланс: {s.Balance }");
                            }
                            else
                            {
                                var NewRecord = new List<Debets>()
                            {
                            new Debets { Id = listI.Count, Requisites = req, Balance = s.Balance - sum, Operation = "Снятие", Sum = sum }
                            };
                                foreach (var k in NewRecord)
                                {
                                    writer.WriteLine(k.ToExcel());
                                }
                                Console.WriteLine($"Текущий баланс: {s.Balance - sum}");
                            }
                        }
                    }
                 
                }
            }
            
        }
        public string ToExcel()
        {
        return $"{Id};{Requisites};{Balance};{Operation};{Sum}";
        } 
    }
}
