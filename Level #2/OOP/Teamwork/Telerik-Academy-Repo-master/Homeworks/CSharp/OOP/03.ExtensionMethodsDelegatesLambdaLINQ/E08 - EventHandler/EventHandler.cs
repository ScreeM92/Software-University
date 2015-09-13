using System;
using System.Timers;

class EventHandler
{
    public delegate void Executable();

    public Executable current;
    public Timer newTimer;

    public void OnWait(object source, ElapsedEventArgs eea)
    {
        current();
    }

    public void Run(int miliseconds)
    {
        newTimer.Elapsed += new ElapsedEventHandler(OnWait);
        newTimer.Interval = miliseconds;
        newTimer.Enabled = true;
    }

    public EventHandler()
    {
        newTimer = new Timer(40000);
    }
}