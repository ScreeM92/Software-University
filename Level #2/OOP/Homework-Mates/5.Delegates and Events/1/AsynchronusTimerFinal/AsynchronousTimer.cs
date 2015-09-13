using System;
using System.Threading;

class AsynchTimer
{
    private Action ticks;
    private int times;
    private int interval;
    public static bool wheel = true;

    public AsynchTimer(int times, int interval, Action ticks)
    {
        this.Times = times;
        this.Interval = interval;
        this.Ticks = ticks;
        this.OnTick(EventArgs.Empty);
    }

    public int Times
    {
        get { return this.times; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(
                    String.Format("TimeInterval cannot be negative!")
                );
            }
            this.times = value;
        }
    }

    public int Interval
    {
        get { return this.interval; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(
                    String.Format("TimeInterval cannot be negative!")
                );
            }
            this.interval = value;
        }
    }

    public Action Ticks
    {
        get { return this.ticks; }
        set { this.ticks = value; }
    }

    public virtual void OnTick(EventArgs e)
    {
        if (null != this.ticks)
        {
            Thread newThread = new Thread(() =>
            {
                int dynamicTicks = 0;
                while (dynamicTicks <= this.times)
                {
                    dynamicTicks++;
                    this.ticks();
                    Thread.Sleep(this.interval);
                }
            });
            newThread.Start();
        }
    }
}