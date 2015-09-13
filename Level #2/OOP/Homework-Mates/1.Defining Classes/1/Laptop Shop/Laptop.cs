using System;

public class Laptop
{
    private string model;
    private string manufacturer = "";
    private string processor = "";
    private string ram = "";
    private string graphicsCard = "";
    private string hdd = "";
    private string screen = "";
    private int batteryLife = 0;
    Battery battery = new Battery();
    private decimal price = 0.0m; //

    public string Model
    {
        get { return this.model; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Model Can't be null");
            }
            else
            {
                this.model = value;
            }

        }
    }
    public string Manufacturer
    {
        get { return this.manufacturer; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Manufacturer can't be null!");
            }
            else
            {
                this.manufacturer = value;
            }
        }
    }
    public string Processor
    {
        get { return this.processor; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Processor can't be null!");
            }
            else
            {
                this.processor = value;
            }
        }
    }
    public string Ram
    {
        get { return this.ram; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Ram can't be null!");
            }
            else
            {
                this.ram = value;
            }
        }
    }
    public string GraphicsCard
    {
        get { return this.graphicsCard; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Graphics Card can't be null!");
            }
            else
            {
                this.graphicsCard = value;
            }
        }
    }
    public string Hdd
    {
        get { return this.hdd; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("HDD  can't be null!");
            }
            else
            {
                this.hdd = value;
            }
        }
    }
    public string Screen
    {
        get { return this.screen; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Screen  can't be null!");
            }
            else
            {
                this.screen = value;
            }
        }
    }
    public Battery Battery
    {
        get { return this.battery; }
        set { }
    }

    public int BatteryLife
    {
        get { return this.batteryLife; }
        set { this.batteryLife = value; }
    }
    public decimal Price
    {
        get { return this.price; }
        set { this.price = value; }
    }

    public Laptop(string model, decimal price)
    {
        Model = model;
        Price = price;
    }
    public Laptop(string model, string manufacturerm, string processor, string ram, string graphicsCard,
                  string hdd, string screen, Battery battery, int batteryLife, decimal price)
    {
        Model = model;
        Manufacturer = manufacturer;
        Processor = processor;
        Ram = ram;
        GraphicsCard = graphicsCard;
        Hdd = hdd;
        Screen = screen;
        Battery = battery;
        BatteryLife = batteryLife;
        Price = price;

    }
    public override string ToString()
    {
        return string.Format(
                             "Model {0} \n" +
                             "Manufacturer: {1} \n" +
                             "Processor: {2} \n" +
                             "Ram: {3} \n" +
                             "Graphics Card: {4} \n" +
                             "HDD: {5} \n" +
                             "Screen: {6} \n" +
                             "Battery: {7} \n" +
                             "Battery Life: {8} \n" +
                             "Price: {9}", Model, Manufacturer, Processor, Ram,
                                GraphicsCard, Hdd, Screen,
                                   Battery.ToString(), BatteryLife, Price);
    }
}
