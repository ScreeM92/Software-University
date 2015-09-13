using System;

class Battery
{
    //Fields
    private string model;
    private int idleHours;
    private int talkHours;
    public BatteryType batteryType;
    

    //Constructors
    public Battery(string model) : this(model, 0, 0) { }

    public Battery(string model, int idleHours) : this(model, idleHours, 0) { }

    public Battery(string model, int idleHours, int talkHours) : this(model, idleHours, 0, BatteryType.LiIon) { }

    public Battery(string model, int idleHours, int talkHours, BatteryType type)
    {   
        this.model = model;
        this.idleHours = idleHours;
        this.talkHours = talkHours;
        this.batteryType = type;
    }

    //Properties
    public string Model
    {
        get
        {
            return this.model;
        }
        set
        {
            this.model = value;
        }
    }

    public int IdleHours
    {
        get
        {
            return this.idleHours;
        }
        set
        {
            if (value >= 0)
            {
                this.idleHours = value;   
            }
            throw new OverflowException();
        }
    }

    public int TalkHours
    {
        get
        {
            return this.talkHours;
        }
        set
        {
            if (value >= 0)
            {
                this.talkHours = value;
            }
            throw new OverflowException();
        }
    }

    public BatteryType BatteryType
    {
        get
        {
            return this.batteryType;
        }
    }
}