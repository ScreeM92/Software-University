using System;

public class Customer
{
    public string Name { get; private set; }

    public Customer(string name)
    {
        this.Name = name;
    }
}

