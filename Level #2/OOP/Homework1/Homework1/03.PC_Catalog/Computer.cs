using System;
class Computer
{
    private string name;
    private Component component;
    private decimal price;

    public string Name
    {
        get { return this.name; }
        set {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("The name is null");
            }
            this.name = value; 
        }
    }

    public decimal Price
    {
        get
        {
            decimal sum = Component.GraphicsCardPrice;
            sum += Component.HddPrice;
            sum += Component.MotherBoardPrice;
            sum += Component.ProcessorPrice;
            sum += Component.RamPrice;
            return sum;
        }
        private set {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Negative");
            }
            this.price = value;
        }
    }

    public Component Component
    {
        get { return this.component;}
        set { this.component = value; }
    }

    public Computer(string name, Component component)
    {
        this.Name = name;
        this.Component = component;
    }

    public Computer(string name, Component component, decimal price)
        : this(name, component)
    {
        this.Price = price;
    }

    public override string ToString()
    {
        string namePH = this.name.Length > 0 ? string.Format("Name: {0} \n", this.name) : string.Empty;
        string pricePH = Price == 0 ? pricePH = " \n" : string.Format("Price: {0}лв.\n", Price);

        return string.Format("{0}{1}{2}", namePH, this.component, pricePH);
    }

    public static string Display()
    {
        Component spec1 = new Component("INtel I5", "NVidia", "GB", "1TB", "8GB");
        Component fullSpec1 = new Component("INtel I5", "NVidia", "GB", "1TB", "8GB", 200m, 400m, 100m, 50m, 100m);
        Component fullSpec2 = new Component("INtel I5", "NVidia", "GB", "1TB", "8GB", 100m, 200m, 50m, 20m, 40m);
        Computer comp1 = new Computer("Acer", spec1);
        Computer comp2 = new Computer("Acer", fullSpec1);
        Computer comp3 = new Computer("Toshiba", fullSpec2);

        //Console.WriteLine(comp1);
        if (comp2.Price > comp3.Price)
        {
            Console.WriteLine(comp3);
            Console.WriteLine(comp2);
        }
        else
        {
            Console.WriteLine(comp2);
            Console.WriteLine(comp3);
        }
        return string.Empty;
    }
}
class Program
{
    static void Main()
    {
        Computer.Display();
    }
}
