using System;
public class Component
{
    private string name;
    private string details;
    private decimal price;

    public string Name {
        get {
            return this.name;
        }
        set {
            if (value == null)
            {
                throw new ArgumentNullException("Component name Can't be empty!");
            }
            else {
                this.name = value;
            }
        }

    }

    public string Details {
        get {
            return this.details;
        }
        set {
            this.details = value;
        }
    }

    public decimal Price {
        get {
            return this.price;
        }
        private set {
            this.price = value;
        }
    }

    public Component(string name, string details, decimal price)
    {
        Name = name;
        Details = details;
        Price = price;
    }
    public Component(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return string.Format("Name: {0}, Details: {1}, Price: {2} \n", Name,Details,Price);
    }
}

