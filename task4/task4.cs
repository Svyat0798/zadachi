using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace task4
{
    class task4
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("исходные данные:");
                List<event0> ev = new List<event0>();
                //DateTime ti = Convert.ToDateTime("8:00");
                //Console.WriteLine(ti.Hour+" "+ti.Minute+ " " + ti.TimeOfDay);
                
                //чтение файла
                using (StreamReader sr = new StreamReader(args[0], Encoding.Default))
                {
                    string line;
                    int k = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        int p = line.IndexOf(' ');
                        string line2 = "";

                        for (int i = 0; i < p; i++)
                            line2 += line[i];
                        ev.Add(new event0());
                        ev[k].time = Convert.ToDateTime(line2);
                        ev[k].pers = 1;

                        k++;
                        line2 = "";

                        for (int i = p+1; i < line.Length; i++)
                            line2 += line[i];
                        ev.Add(new event0());
                        ev[k].time = Convert.ToDateTime(line2);
                        ev[k].pers = -1;

                        k++;

                        Console.WriteLine(line);
                    }

                    //сортировка данных

                    event0 t;
                    for (int i = 1; i <= ev.Count - 1; i++)
                        for (int j = ev.Count - 1; j >= i; j--)
                        {
                            if (ev[j].time < ev[j - 1].time)
                            {
                                t = ev[j];
                                ev.RemoveAt(j);
                                ev.Insert(j - 1, t);
                            }
                        }
                
                    /*foreach (event0 q in ev)
                        Console.WriteLine(q.time.ToString() + " "+q.pers);
                    Console.WriteLine();*/

                    //узнаем сколько посетителей в момент времени
                    for (int i = 1; i <= ev.Count - 1; i++) { 
                        ev[i].pers += ev[i - 1].pers;
                        if (ev[i].time == ev[i - 1].time)
                        {
                            ev.RemoveAt(i-1);
                            i--;
                        }

                    }

                    /*foreach (event0 q in ev)
                        Console.WriteLine(q.time.ToString() + " " + q.pers);
                    Console.WriteLine();*/

                    //сжать список по посетителям
                    for (int i = 1; i <= ev.Count - 1; i++)
                        if (ev[i].pers == ev[i - 1].pers)
                        {
                            ev.RemoveAt(i);
                            i--;
                        }

                    /*foreach (event0 q in ev)
                        Console.WriteLine(q.time.ToString() + " " + q.pers);
                    Console.WriteLine();*/

                    //узнаем макс кол-во людей
                    int max=ev[0].pers;
                    for (int i = 1; i <= ev.Count - 1; i++)
                        if (ev[i].pers > max) max = ev[i].pers;

                    //Console.WriteLine(max); Console.WriteLine();

                    Console.WriteLine("выходные данные:");

                    //выводим ответ
                    for (int i = 0; i <= ev.Count - 1; i++)
                        if (ev[i].pers == max)
                            Console.WriteLine(ev[i].time.ToShortTimeString() + 
                                " " + ev[i+1].time.ToShortTimeString());
                }

            }
            catch
            {
                Console.WriteLine("Ошибка при выполнении программы");
            }
            Console.ReadLine();
        }
    }

    class event0
    {
        public DateTime time;
        public int pers;
    }
}
