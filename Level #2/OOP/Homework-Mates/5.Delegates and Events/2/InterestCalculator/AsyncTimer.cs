using System;
using System.Threading;


class AsyncTimer
{
    private Action<string> _actionMethod;
    private int _interval;
    private int _ticks;

    public AsyncTimer(Action<string> actionMethod, int interval, int ticks)
    {
        this._actionMethod = actionMethod;
        this._interval = interval;
        this._ticks = ticks;
    }

    private void DoWork()
    {
        while (this._ticks > 0)
        {
            Thread.Sleep(this._interval);

            if (_actionMethod != null)
            {
                _actionMethod(this._ticks + "");
            }

            this._ticks--;
        }
    }

    public void Start()
    {
        Thread thread = new Thread(this.DoWork);
        thread.Start();
    }
}

