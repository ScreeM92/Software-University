using System;

public class InvalidRangeException<T> : ApplicationException
{
    public T Min { get; set; }
    public T Max { get; set; }
   
    public InvalidRangeException(T min, T max)
    {
        this.Min = min;
        this.Max = max;
    }

    public override string Message
    {
        get 
        {
            string message = string.Format("Out of range!! Must be in the interval {0} - {1}", this.Min,this.Max);
            return message;   
        }
    }
}