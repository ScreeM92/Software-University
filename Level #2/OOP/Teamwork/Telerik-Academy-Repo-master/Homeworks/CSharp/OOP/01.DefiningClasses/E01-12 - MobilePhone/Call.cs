using System;

class Call
{
    public DateTime date;

    public string time;
    public uint dialedNumber;
    public uint duration;

    public Call(DateTime date, string time, uint dialedNumber, uint duration)
    {
        this.date = date;
        this.time = time;
        this.dialedNumber = dialedNumber;
        this.duration = duration;
    }

    public string Time
    {
        set
        {
            this.time = value;
        }
        get
        {
            return this.time;
        }
    }

    public uint DialedNumber
    {
        set
        {
            this.dialedNumber = value;
        }
        get
        {
            return this.dialedNumber;
        }
    }

    public uint Duration
    {
        set
        {
            this.duration = value;
        }
        get
        {
            return this.duration;
        }
    }
}

