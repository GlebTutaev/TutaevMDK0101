using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutaev
{
    internal class Timing
    {

        TimeSpan duration; //хранение результата 
        TimeSpan[] threads; // значения времени
        public Timing()
        {
            duration = new TimeSpan(0);
            threads = new TimeSpan[Process.GetCurrentProcess().
            Threads.Count];
        }
        public void StartTime() //инициализация массива threads после вызова сборщика мусора
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            for (int i = 0; i < threads.Length; i++)
                threads[i] = Process.GetCurrentProcess().Threads[i].
                UserProcessorTime;
        }
        public void StopTime() //повторный запрос текущего времени
        {				
            TimeSpan tmp;
            for (int i = 0; i < threads.Length; i++)
            {
                tmp = Process.GetCurrentProcess().Threads[i].
                UserProcessorTime.Subtract(threads[i]);
                if (tmp > TimeSpan.Zero)
                    duration = tmp;
            }
        }

       
        public TimeSpan Result()
        {
            return duration;
        }


    }
}

  
