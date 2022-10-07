using System;
using Tutaev;
using System.Collections;
using System.Diagnostics;

namespace Tutaev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable hashtable = new Hashtable(10001);
            
            Stopwatch stopwatch = new Stopwatch();
            Timing timing = new Timing();
            int[] a = new int[10001];

            Random random = new Random();
            for (int i = 0; i < hashtable.Count; i++)
            {
                hashtable.Add(i, random.Next(10000));
            }

            //сортировка обменом
            fillArray(a);
            timing.StartTime();
            bubleSort(a, stopwatch);
            timing.StopTime();
            Console.WriteLine("Timing: " + timing.Result().ToString());

            //сортировка выбором
            fillArray(a);
            timing.StartTime();
            sortingByChoice(a, stopwatch);
            timing.StopTime();
            Console.WriteLine("Timing: " + timing.Result().ToString());

            //Сортировка вставками
            fillArray(a);
            timing.StartTime();
            sortingByInsert(a, stopwatch);
            timing.StopTime();
            Console.WriteLine("Timing: " + timing.Result().ToString());

            //Линейный поиск
            fillArray(a);
            timing.StartTime();
            linePoisk(a, 7532, stopwatch);
            timing.StopTime();
            Console.WriteLine("Timing: " + timing.Result().ToString());

            // Бинарный поиск
            fillArray(a);
            timing.StartTime();
            binPoisk(a, 7532, stopwatch);
            timing.StopTime();
            Console.WriteLine("Timing: " + timing.Result().ToString());

            // поиск в Hashtable
            timing.StartTime();
            stopwatch.Restart();
            findElement(hashtable, 2);
            stopwatch.Stop();
            timing.StopTime();
            Console.WriteLine("Stopwatch: " + stopwatch.ElapsedTicks.ToString());
            Console.WriteLine("Timing: " + timing.Result().ToString());

        }

        //Заполнение массива
        public static void fillArray(int[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(10000);
            }
           
        }

        // поиск в Hashtable
        public static int findElement(Hashtable hashtable, int element)
        {

            foreach (DictionaryEntry ht in hashtable)
            {
                if (ht.Value.Equals(element))
                    return (int)ht.Key;
            }

            return -1;
        }

        //сортировка обменом
        public static void bubleSort(int[] a, Stopwatch stopwatch)
        {

            stopwatch.Restart();
            int temp;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] > a[j])
                    {
                        temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
            stopwatch.Stop();

            Console.WriteLine("Stopwatch: " + stopwatch.ElapsedTicks.ToString());

        }

        //сортировка выбором
        public static void sortingByChoice(int[] a, Stopwatch stopwatch)
        {

            stopwatch.Restart();
            for (int i = 0; i < a.Length - 1; i++)
            {
                //поиск минимального числа
                int min = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j] < a[min])
                    {
                        min = j;
                    }
                }
                //обмен элементов
                int temp = a[min];
                a[min] = a[i];
                a[i] = temp;
            }
            stopwatch.Stop();

            Console.WriteLine("Stopwatch: " + stopwatch.ElapsedTicks.ToString());


        }

        //Сортировка вставками
        public static void sortingByInsert(int[] a, Stopwatch stopwatch)
        {

            stopwatch.Restart();
            for (int i = 1; i < a.Length; i++)
            {
                int k = a[i];
                int j = i - 1;

                while (j >= 0 && a[j] > k)
                {
                    a[j + 1] = a[j];
                    a[j] = k;
                    j--;
                }
            }
            stopwatch.Stop();

            Console.WriteLine("Stopwatch: " + stopwatch.ElapsedTicks.ToString());


        }

        //Линейный поиск
        static int linePoisk(int[] a, int find, Stopwatch stopwatch)
        {

            stopwatch.Restart();
            int k = -1;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == find) { k = i; break; };
            }
            stopwatch.Stop();

            Console.WriteLine("Stopwatch: " + stopwatch.ElapsedTicks.ToString());

            return k;
        }
        // Бинарный поиск
        static int binPoisk(int[] a, int find, Stopwatch stopwatch)
        {

            stopwatch.Restart();
            int k;   // с
            int L = 0;        // левая граница
            int R = a.Length - 1;    // правая граница
            k = (R + L) / 2;

            while (L < R - 1)
            {

                k = (R + L) / 2;
                if (a[k] == find)
                    return k;

                if (a[k] < find)
                    L = k;
                else
                    R = k;
            }
            if (a[k] != find)
            {
                if (a[L] == find)
                    k = L;
                else
                {
                    if (a[R] == find)
                        k = R;
                    else
                        k = -1;
                };
            }
            stopwatch.Stop();

            Console.WriteLine("Stopwatch: " + stopwatch.ElapsedTicks.ToString());

            return k;
        }
    }
}


