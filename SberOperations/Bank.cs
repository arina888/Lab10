using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberOperations
{
    public class Bank
    {
        public double Rubles { get; set; }
        public double USD { get; set; }
        public double EUR { get; set; }
        public double CAD { get; set; }


        public string ToExcel()
        {
            return $"{Rubles};{USD};{EUR};{CAD}";
        }

        public static void ChangeBank(double sum, string typeoperation)
        {
            var path = "Bank.csv";

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding = Encoding.GetEncoding(1251);

            var lines = File.ReadAllLines(path, encoding);
            var bankk = new Bank[lines.Length - 1];

            List<double> listR = new List<double>();
            List<double> listU = new List<double>();
            List<double> listE = new List<double>();
            List<double> listC = new List<double>();

            for (int i = 1; i < lines.Length; i++)
            {
                var splits = lines[i].Split(';');

                var bank = new Bank();
                bank.Rubles = Convert.ToDouble(splits[0]);
                bank.USD = Convert.ToDouble(splits[1]);
                bank.EUR = Convert.ToDouble(splits[2]);
                bank.CAD = Convert.ToDouble(splits[3]);
                bankk[i - 1] = bank;
                listR.Add(Convert.ToDouble(splits[0]));
                listU.Add(Convert.ToDouble(splits[1]));
                listE.Add(Convert.ToDouble(splits[2]));
                listC.Add(Convert.ToDouble(splits[3]));

            }

            if (typeoperation == "Кредит" || typeoperation == "Ипотека")
            {

                if (listR[listR.Count - 1] < sum)
                {
                    Console.WriteLine("У банка недостаточно средств для предоставления данной услуги. Повторите позже.");

                }
                else
                {
                    listR[listR.Count - 1] -= sum;
                    Console.WriteLine("Сделка одобрена");
                    
                    using (var writer = new StreamWriter(path, true, encoding))

                    {
                    var NewRecord = new List<Bank>()
                    {
                     new Bank {Rubles = listR[listR.Count-1], USD=listU[listU.Count-1], EUR=listE[listE.Count-1], CAD=listC[listC.Count-1] }
                    };
                    foreach (var n in NewRecord)
                    {
                        writer.WriteLine(n.ToExcel());
                    }
                    }
                }
            }


            if (typeoperation == "Деопзит")
            {

                listR[listR.Count-1] += sum;

                using (var writer = new StreamWriter(path, true, encoding))

                {
                    var NewRecord = new List<Bank>()
                {
                new Bank {Rubles = listR[listR.Count-1], USD=listU[listU.Count-1], EUR=listE[listE.Count-1], CAD=listC[listC.Count-1] }
                };
                    foreach (var n in NewRecord)
                    {
                        writer.WriteLine(n.ToExcel());
                    }
                }
            }

            if (typeoperation == "ПокупкаUSD")
            {

                if (listU[listU.Count-1] <= sum )
                {
                    Console.WriteLine("У банка недостаточно средств для предоставления данной услуги. Повторите позже.");

                }
                else

                {
                    listR[listR.Count-1] += sum * Currency.BuyRateUSD;
                    listU[listU.Count-1] -= sum ;
                    Console.WriteLine("Сделка совершена.");

                

                using (var writer = new StreamWriter(path, true, encoding))

                {
                    var NewRecord = new List<Bank>()
                    {
                     new Bank {Rubles = listR[listR.Count-1], USD=listU[listU.Count-1], EUR=listE[listE.Count-1], CAD=listC[listC.Count-1] }
                    };
                
                    foreach (var n in NewRecord)
                    {
                        writer.WriteLine(n.ToExcel());
                    }
                }}
            }
            if (typeoperation == "ПокупкаEUR")
            {
                ////listR[listR.Count-1] += sum * Currency.BuyRateEUR;

                //if (listE[listE.Count-1] <= sum )
                //{
                //    Console.WriteLine("У банка недостаточно средств для предоставления данной услуги. Повторите позже.");

                //}
                //else
                //{
                    listR[listR.Count - 1] += sum * Currency.BuyRateEUR;
                    listE[listE.Count-1] -= sum ;
                    Console.WriteLine("Сделка совершена.");
               
                    using (var writer = new StreamWriter(path, true, encoding))
                    {
                    var NewRecord = new List<Bank>()
                    {
                    new Bank {Rubles = listR[listR.Count-1], USD=listU[listU.Count-1], EUR=listE[listE.Count-1], CAD=listC[listC.Count-1] }
                    };
                    foreach (var n in NewRecord)
                    {
                        writer.WriteLine(n.ToExcel());
                    }
                    }      
            }


            if (typeoperation == "ПокупкаCAD")
            {
                if (listC[listC.Count - 1] <= sum)
                {
                    Console.WriteLine("У банка недостаточно средств для предоставления данной услуги. Повторите позже.");

                }
                else
                {
                    listR[listR.Count - 1] += sum * Currency.BuyRateEUR;
                    listC[listC.Count - 1] -= sum;
                    Console.WriteLine("Сделка совершена.");

                    using (var writer = new StreamWriter(path, true, encoding))
                    {
                        var NewRecord = new List<Bank>()
                            {
                             new Bank {Rubles = listR[listR.Count-1], USD=listU[listU.Count-1], EUR=listE[listE.Count-1], CAD=listC[listC.Count-1] }
                            };
                        foreach (var n in NewRecord)
                        {
                            writer.WriteLine(n.ToExcel());
                        }
                    }
                }
            }
                    if (typeoperation == "ПродажаU")
                    {
                    if (listR[listR.Count - 1] <= sum * Currency.SellRateUSD)
                    {
                        Console.WriteLine("У банка недостаточно средств для предоставления данной услуги. Повторите позже.");

                    }
                    else
                    {
                        listU[listU.Count - 1] += sum;
                        listR[listR.Count - 1] -= sum * Currency.SellRateUSD;
                        Console.WriteLine("Сделка совершена.");


                        using (var writer = new StreamWriter(path, true, encoding))
                        {
                            var NewRecord = new List<Bank>()
                            {
                             new Bank {Rubles = listR[listR.Count-1], USD=listU[listU.Count-1], EUR=listE[listE.Count-1], CAD=listC[listC.Count-1] }
                            };
                            foreach (var n in NewRecord)
                            {
                                writer.WriteLine(n.ToExcel());
                            }

                        }
                    }

                    }

            if (typeoperation == "ПродажаE")
            {

                if (listR[listR.Count - 1] <= sum * Currency.SellRateEUR)
                {
                    Console.WriteLine("У банка недостаточно средств для предоставления данной услуги. Повторите позже.");

                }
                else
                {
                    listE[listE.Count - 1] += sum;
                    listR[listR.Count - 1] -= sum * Currency.SellRateEUR;
                    Console.WriteLine("Сделка совершена.");

                    using (var writer = new StreamWriter(path, true, encoding))
                    {
                        var NewRecord = new List<Bank>()
                            {
                           new Bank {Rubles = listR[listR.Count-1], USD=listU[listU.Count-1], EUR=listE[listE.Count-1], CAD=listC[listC.Count-1] }
                            };
                        foreach (var n in NewRecord)
                        {
                            writer.WriteLine(n.ToExcel());
                        }


                    }

                }
            }


            if (typeoperation == "ПродажаC")
            {

                if (listR[listR.Count - 1] <= sum * Currency.SellRateUSD)
                {
                    Console.WriteLine("У банка недостаточно средств для предоставления данной услуги. Повторите позже.");

                }
                else
                {
                    listC[listC.Count - 1] += sum;
                    listR[listR.Count - 1] -= sum * Currency.SellRateCAD;
                    Console.WriteLine("Сделка совершена.");

                    using (var writer = new StreamWriter(path, true, encoding))
                    {
                        var NewRecord = new List<Bank>()
                            {
                             new Bank {Rubles = listR[listR.Count-1], USD=listU[listU.Count-1], EUR=listE[listE.Count-1], CAD=listC[listC.Count-1] }
                            };
                        foreach (var n in NewRecord)
                        {
                            writer.WriteLine(n.ToExcel());
                        }

                    }

                }
            }
                        

            }
        }
    }

