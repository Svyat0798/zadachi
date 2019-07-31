using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Globalization;

namespace task3
{
    class task3
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("исходные данные:");
                CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

                //чтение файла
                double[,] n = new double[16,5];
                string fn;
                
                for (int i=0; i<5; i++)
                {
                    fn = args[0] + @"\Cash" + Convert.ToString(i+1) + ".txt";
                    //Console.WriteLine(i);
                    //Console.WriteLine(fn);

                    using (StreamReader sr = new StreamReader(fn, Encoding.Default))
                    {
                        string line;
                        int j = 0;
                        while ((line = sr.ReadLine()) != null)
                        {
                            n[j, i] = Convert.ToDouble(line);
                            j++;                            
                        }
                    }
                }

                for (int i = 0; i < 16; i++) {
                    for (int j = 0; j < 5; j++)
                        Console.Write(" {0:0.00}",n[i,j]);
                    Console.WriteLine();
                        };


                Console.WriteLine("Выходные данные:");

                //сложение поситителей в кассах на каждый момент времени
                double[] sum = new double[16];
                
                for (int i =0;i<16;i++)
                    for (int j = 0; j < 5; j++)
                    {
                        sum[i] += n[i,j];                     
                    }          

                //нахождение наибольшего числа поситителей
                double res=sum[0];
                int nres = 0;

                for (int i = 1; i < 16; i++)
                if (sum[i]>res)
                {
                        res = sum[i];
                        nres = i;
                }

                Console.WriteLine(nres+1);

                Thread.CurrentThread.CurrentCulture = temp_culture;

            }
            catch
            {
                Console.WriteLine("Ошибка при выполнении программы");
            }
            Console.ReadLine();
        }
    }
}
