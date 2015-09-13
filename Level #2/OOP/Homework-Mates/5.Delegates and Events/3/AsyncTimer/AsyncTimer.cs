using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AsyncTimer
{
    class AsyncTimer
    {
        private Action tick;
        private int countTicks;
        private int milliSeconds;



        public AsyncTimer(Action tick, int countTicks, int milliSeconds)
        {
            this.Tick = tick;
            this.CountTicks = countTicks;
            this.Milliseconds = milliSeconds;
        }


        public Action Tick
        {
            get { return this.tick; }
            set { this.tick = value; }
        }

        public int CountTicks
        {
            get { return this.countTicks; }
            set { this.countTicks = value; }
        }

        public int Milliseconds
        {
            get { return this.milliSeconds; }
            set { this.milliSeconds = value; }
        }



        public virtual void OnTick(EventArgs e)
        {
            if (null != this.tick)
            {
                Thread newThread = new Thread(() =>
                {
                    int countedTicks = 0;
                    while (countedTicks < this.countTicks)
                    {
                        this.tick();
                        countedTicks++;
                        Thread.Sleep(this.milliSeconds);
                    }
                });
                newThread.Start();
            }
        }

        public static void MethodOne()
        {
            Console.WriteLine("First method");
        }
        public static void MethodTwo()
        {
            Console.WriteLine("Second method");
        }

        static void Main()
        {

            AsyncTimer a = new AsyncTimer(MethodOne, 20, 500);
            AsyncTimer b = new AsyncTimer(MethodTwo, 10, 1000);
            for (int i = 0; i < b.countTicks; i++)
            {
                b.tick();
                Thread.Sleep(b.milliSeconds);
            }
        }
    }
}
