using System;
using System.Collections.Generic;

class GSM
{
    //Fields
    private string device;
    private string manifacturer;
    private string owner;
    private decimal price;

    public Battery batteryCharacteristics;
    public Display displayCharacteristics;
    private static GSM iPhone4S;

    public List<Call> callHistory = new List<Call>();

    //Contructors
    public GSM() { }

    public GSM(string device) : this(device, null) { }

    public GSM(string device, string manifacturer) : this(device, manifacturer, null) { }

    public GSM(string device, string manifacturer, string owner) : this(device, manifacturer, owner, 0) { }

    public GSM(string device, string manifacturer, string owner, decimal price)
    {
        this.device = device;
        this.manifacturer = manifacturer;
        this.owner = owner;
        this.price = price;
    }

    public GSM(string device, string manifacturer, string owner, decimal price, string batteryModel, int idleHours, int talkHours, float displaySize, int displayNumberOfColors, BatteryType batteryType)
    {
        this.device = device;
        this.manifacturer = manifacturer;
        this.owner = owner;
        this.price = price;
        this.batteryCharacteristics = new Battery(batteryModel, idleHours, talkHours, batteryType);
        this.displayCharacteristics = new Display(displaySize, displayNumberOfColors);
    }

    //Properties
    public string Device
    {
        set
        {
            this.device = value;
        }
        get
        {
            return this.device;
        }
    }

    public string Manifacturer
    {
        set
        {
            this.manifacturer = value;
        }
        get
        {
            return this.manifacturer;
        }
    }

    public string Owner
    {
        set
        {
            this.owner = value;
        }
        get
        {
            return this.owner;
        }
    }

    public decimal Price
    {
        set
        {
            if (value >= 0 )
            {
                this.price = value;
            }
            throw new OverflowException();
        }
        get
        {
            return this.price;
        }
    }

    public override string ToString()
    {
        return string.Format("Device: {0} \nOwner's name: {1} \nManifacturer: {2} \nPrice: {3} \n\nBattery characteristics \nModel: {4} \nIdle hours: {5} \nTalk hours: {6} \n\nDisplay characteristics \nSize: {7} \nNumber of colors: {8} \nBattery type: {9}",
             this.Device, this.Owner, this.Manifacturer, this.Price, batteryCharacteristics.Model, batteryCharacteristics.IdleHours, batteryCharacteristics.TalkHours,
             displayCharacteristics.Size, displayCharacteristics.NumberOfColors, batteryCharacteristics.batteryType);
    }

    public static GSM IPhone4S
    {
        get
        {
            return iPhone4S = new GSM("Iphone4S", "Apple", "Unknown", 1059.00m, "BBAI003", 200, 8, 3, 1600000, BatteryType.LiIon);
        }
    }

    public void GetInfo()
    {
        Console.WriteLine("Mobile phone info");
        Console.WriteLine("Device: {0}", this.Device);
        Console.WriteLine("Manifacturer: {0}", this.Manifacturer);
        Console.WriteLine("Owner: {0}", this.Owner);
        Console.WriteLine("Price: {0}BGN", this.Price);
        Console.WriteLine();
        Console.WriteLine("Battery characteristics");
        Console.WriteLine("Battery model: {0}", batteryCharacteristics.Model);
        Console.WriteLine("Battery idle hours: {0}", batteryCharacteristics.IdleHours);
        Console.WriteLine("Battery talk hours: {0}", batteryCharacteristics.TalkHours);
        Console.WriteLine();
        Console.WriteLine("Display characteristics");
        Console.WriteLine("Display size: {0} inch", displayCharacteristics.Size);
        Console.WriteLine("Display number of colors: {0}", displayCharacteristics.NumberOfColors);
    }

    public void AddCalls(string time, uint dialedNumber, uint duration, int day, int month, int year)
    {
        this.callHistory.Add(new Call(new DateTime(year, month, day), time, dialedNumber, duration));
    }

    public void DeleteCalls(string time, uint dialedNumber, uint duration, int day, int month, int year)
    {
        this.callHistory.Remove(new Call(new DateTime(year, month, day), time, dialedNumber, duration));
    }

    public void ClearAllCalls()
    {
        this.callHistory.Clear();
    }

    public decimal CalculateTotalBill(decimal callPricePerMinute)
    {
        uint sum = 0;
        for (int index = 0; index < this.callHistory.Count; index++)
        {
            sum += this.callHistory[index].duration;
        }
        decimal durationToMinutes = sum / 60;
        decimal totalPrice = durationToMinutes * callPricePerMinute;
        return totalPrice;
    }
}

