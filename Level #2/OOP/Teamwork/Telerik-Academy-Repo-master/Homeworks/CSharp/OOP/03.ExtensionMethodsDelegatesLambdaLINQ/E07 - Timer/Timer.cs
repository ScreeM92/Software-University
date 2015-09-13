using System;
using System.Threading;

public class Timer
{
    private delegate void MethodToExecute();
    
    MethodToExecute methodToExecute;
    private int timesToExecute = 0;
    private int delayTime = 1600;

    private int TimesToExecute
    {
        set 
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Must be positive number!");
            }
            this.timesToExecute = value;
        }
    }

    private int DelayTime
    {
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Must be positive number!");
            }
            this.delayTime = value;
        }
    }

    public Timer(Action method) : this(method, 0, 1600) { }

    public Timer(Action method, int timesToExecute) : this(method, timesToExecute, 1600) { }
    
    public Timer(Action method, int timesToExecute, int delayTime)
    {
        this.methodToExecute = new MethodToExecute(method);
        this.TimesToExecute = timesToExecute;
        this.DelayTime = delayTime;
    }

    public void Run()
    {
        Console.WriteLine("Press Esc to quit! Or wait the method to count to the number of your choice.");
        Console.WriteLine("Info: If the timesToExecute is equal to zero the method will execute until the pressing of Esc!");

        int counter = 0;
        bool isBiggerThanZero = this.timesToExecute > 0 ? true : false;
        
        while (true)
	    {
            if (isBiggerThanZero && counter >= this.timesToExecute)
            {
                break;
            }

            if (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                methodToExecute();
                Thread.Sleep(this.delayTime);
            }
            else { break; }
            
            counter++;
	    }
    }
}