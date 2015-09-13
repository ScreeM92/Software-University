using System;
using System.Collections.Generic;
public class Computer
{
    private string name;
    private List<Component> components = new List<Component>();
    private decimal price;

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Name can't be null");
            }
            else
            {
                this.name = value;
            }
        }
    }

    public List<Component> Components
    {
        get
        {
            return this.components;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Component can't be null!");
            }
            else
            {
                this.components = value;
            }
        }
    }

    public decimal Price
    {
        get { return this.price; }
        set { this.price = value; }
    }

    public Computer(string name, List<Component> components )
    {
        Name = name;
        Components = components;
        Price = CalculateComputerPrice(components);
    }

   
    public decimal CalculateComputerPrice(List<Component> components){
        decimal price = 0m;
        foreach (Component component in components)
	    {
		 price += component.Price;
    	}
        return price;
    }

    public override string ToString()
    {
       
        string output = "";
        output += string.Format("Name: {0} \n",Name) ;
        foreach( Component component in Components){
            output += string.Format("Component: {0} \n", component.ToString());
        }
        output += string.Format("Price: {0} \n",Price);
        return output;
    }

}


