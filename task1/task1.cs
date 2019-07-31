using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApp5
{
    class task1
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("исходные данные:");
                List<int> n = new List<int>();

                //чтение файла
                using (StreamReader sr = new StreamReader(args[0], Encoding.Default))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        n.Add(Convert.ToInt32(line));
                        Console.WriteLine(line);
                    }
                }

                //сортировка данных

                int t = 0;
                for (int i = 1; i <= n.Count - 1; i++)
                    for (int j = n.Count - 1; j >= i; j--)
                    {
                        if (n[j] < n[j - 1])
                        {
                            t = n[j];
                            n.RemoveAt(j);
                            n.Insert(j - 1, t);
                        }

                    }
                /*
                foreach (int q in n)
                    Console.Write(q+" ");*/
                Console.WriteLine();
                Console.WriteLine("Выходные данные:");

                //перцентиль 90
                double l90 = 0.9 * (n.Count - 1) + 1;
                double p90 = n[(int)l90-1] + (l90 - (int)l90) * (n[(int)l90] - n[(int)l90-1]);
                Console.WriteLine("{0:0.00}",p90);

                //медиана
                double m;
                if (n.Count % 2 == 0)
                    m = (n[n.Count / 2 - 1] + n[n.Count / 2 - 1]) / 2;
                else
                    m = n[(int) (n.Count/2)];
                Console.WriteLine("{0:0.00}", m);

                //макс знач
                Console.WriteLine("{0:0.00}", n[n.Count-1]);

                //мин знач
                Console.WriteLine("{0:0.00}", n[0]);

                //ср ариф знач
                double sa=0;
                foreach (int q in n)
                    sa += q;
                sa /= n.Count;
                Console.WriteLine("{0:0.00}", sa);

            }
            catch
            {
                Console.WriteLine("Ошибка при выполнении программы");
            }
            Console.ReadLine();
        }
    }
}
