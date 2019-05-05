using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace tema_3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. C# Program to Check Whether the Entered Year is a Leap Year or Not
            // An bisect - multiplu de 4, cu exceptia anilor centenari - nu sunt divizibili cu 400
            // CheckLeapYear();

            //2. ATM Transactions
            //ATM();

            //3. Add two numbers in a file: You have data in a file in two rows. On the third row save the sum of the numbers above.
            // File.Create("E:\\vio\\wantsome\\w3\\3.2\\file.txt");
            string text = File.ReadAllText("E:\\vio\\wantsome\\w3\\3.2\\file2.txt");
            Console.WriteLine($"{text}\n{text[0]}");
            string[] lines = File.ReadAllLines("E:\\vio\\wantsome\\w3\\3.2\\file2.txt");
            double suma = 0;
            foreach (string line in lines)
            {
                suma += Convert.ToDouble(line);
                Console.WriteLine("\t" + line);

            }
            string[] sum = new string[] { Convert.ToString(suma) };
            File.WriteAllLines("E:\\vio\\wantsome\\w3\\3.2\\file2.txt",sum);
            text = File.ReadAllText("E:\\vio\\wantsome\\w3\\3.2\\file2.txt");
            Console.WriteLine($"{text}");




        }
        // Functiile pentru exercitiul 2
        private static void ATM()
        {
            Double sold = 9890.78;
            Console.WriteLine($"Bine ati venit! Ce operatiune doriti sa faceti astazi {DateTime.Today.Date} ?\nApasati 1 pentru Verificare sold, 2 pentru retragere numerar si 3 pentru depunere numerar");

            string input = Console.ReadLine();
            if (!char.IsNumber(input[0]))
            {
                Console.WriteLine("Va rugam introduceti o valoare valida");
                ATM();
            }
            else
            {//verificare sold
                if (input[0] - '0' == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Soldul dvs. este: " + sold.ToString());
                    OperatiuneNoua();

                }
                else
                {//retragere numerar
                    if (input[0] - '0' == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("In ce moneda doriti sa fie efectuata retragerea?\n1-Lei\n2-Euro");
                        input = Console.ReadLine();
                        if (!char.IsNumber(input[0]))
                        {
                            Console.WriteLine("Va rugam introduceti o valoare valida");
                            ATM();
                        }
                        else
                        {//retragere numerar in lei
                            if (input[0] - '0' == 1)
                            {
                                Console.Clear();
                                Console.WriteLine(RetragereLei(sold));
                                
                            }
                            else
                            {//retragere numerar in Euro
                                if (input[0] - '0' == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine(RetragereEuro(sold));
                                    
                                }
                            }
                        }

                    }
                    else
                    {
                        if (input[0] - '0' == 3)
                        {
                            Console.Clear();
                            DepunereNumerar(sold);
                        }
                    }
                }
            }
        }
        
        public static string RetragereEuro(double sold)
        {
            double SoldEuro = sold / 4.78;
            Console.WriteLine($"Cursul BNR de astazi este 1 EUR = 4.78 lei.\nSoldul dvs in euro este {SoldEuro}\nCe suma doriti sa retrageti?\n1-50EUR\n2-100EUR\n3-200EUR\n4-Alta Suma");
            string input = Console.ReadLine();
            if (!char.IsNumber(input[0]))
            {

                Console.WriteLine("Va rugam introduceti o valoare valida");
                return RetragereEuro(sold);


            }
            else
            {
                if (input[0] - '0' == 1)
                {
                    return SumaRamasa(SoldEuro, 50);
                }
                else
                {
                    if (input[0] - '0' == 2)
                    {
                        return SumaRamasa(SoldEuro, 100);
                    }
                    else
                    {
                        if (input[0] - '0' == 3)
                        {
                            return SumaRamasa(SoldEuro, 200);
                        }
                        else
                        {
                            return SumaRamasa(SoldEuro, AltaSuma());
                        }
                    }
                }
            }
        }
        public static string RetragereLei(double sold)
            {

                Console.WriteLine("Ce suma doriti sa retrageti?\n1-50Lei\n2-100Lei\n3-200Lei\n4-Alta Suma");
                string input = Console.ReadLine();
                if (!char.IsNumber(input[0]))
                {

                    Console.WriteLine("Va rugam introduceti o valoare valida");
                    return RetragereLei(sold);


                }
                else
                {
                    if (input[0] - '0' == 1)
                    {
                        return SumaRamasa(sold, 50);
                    }
                    else
                    {
                        if (input[0] - '0' == 2)
                        {
                            return SumaRamasa(sold, 100);
                        }
                        else
                        {
                            if (input[0] - '0' == 3)
                            {
                                return SumaRamasa(sold, 150);
                            }
                            else
                            {
                                return SumaRamasa(sold, AltaSuma());
                            }
                        }
                    }


                }
            }
        private static int AltaSuma()
        {
            Console.WriteLine("Ce suma doriti sa retrageti?");
            string input = Console.ReadLine();
            int numar = 0;
            foreach (var a in input)
            {
                if (char.IsNumber(a))
                {
                    numar++;
                }
            }
            if (numar == input.Length)
            {
                return Convert.ToInt32(input);
            }
            else
            {
                Console.WriteLine("Introduceti o suma valida");
                AltaSuma();
                return 0;

            }
        }
        private static string SumaRamasa(double sold, int valoare)
        {
            double SoldNou;
            if (sold < valoare)
            {

                Console.WriteLine("Fonduri insuficiente.");
                OperatiuneNoua();
                return "";

            }
            else
            {
                SoldNou = sold - valoare;
                return $"Operatiune efectuata cu succes, soldul ramas:{SoldNou.ToString()}";

            }
        }

        public static void OperatiuneNoua()
        {
            Console.WriteLine("Doriti sa faceti alta operatiune?\n1-Da\n2-Nu");
            string raspuns = Console.ReadLine();

            if (!char.IsNumber(raspuns[0]))
            {
                Console.WriteLine("Va rugam introduceti o valoare valida");
                OperatiuneNoua();

            }
            else
            {
                if (raspuns[0] - '0' == 1)
                {
                    ATM();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        public static double DepunereNumerar(double sold)
        {
            Console.WriteLine("Introduceti suma: ");
            string input = Console.ReadLine();
            if (!char.IsNumber(input[0]))
            {

                Console.WriteLine("Va rugam introduceti o valoare valida");
                DepunereNumerar(sold);
                return sold;
            }
            else
            {
                double SoldNou = Convert.ToDouble(input) + sold;
                Console.WriteLine($"Noul sold este: {SoldNou}");
                return SoldNou;

            }


        }
        //Functiile pentru exercitiul 1 
        private static void CheckLeapYear()
        {
            Console.WriteLine("Introduceti anul pentru verificare:");
            string input = Console.ReadLine();
            int numar = 0, year;
            if (input.Length == 4)
            {
                foreach (var a in input)
                {
                    if (char.IsNumber(a))
                    {
                        numar++;
                    }
                }
                if (numar == input.Length)
                {
                    year = Convert.ToInt32(input);
                    Console.WriteLine(LeapYear(year));
                }
                else
                {
                    Console.WriteLine("Introduceti un an valid");
                }
            }
            else
            {
                Console.WriteLine("Introduceti un an valid");
                CheckLeapYear();
            }


        }

        public static string LeapYear(int year)
        {
            if ((year % 4 == 0 & year % 100 == 0) || (year % 400 == 0))
            {
                return "The given year Leap year";
            }
            else
            {
                return "The given year is not Leap year";
            }
        }


        }

    }

