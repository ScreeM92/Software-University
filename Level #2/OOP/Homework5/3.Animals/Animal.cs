using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Animal : ISound
{
    private string name;
    private int age;


    public Animal(string name, int age)       
    {
        this.Name = name;
        this.Age = age;
    }  

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("The name cannot be null or whitespace");
            }
            this.name = value;
        }
    }

    public int Age 
    {
        get
        {
            return this.age;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("The age cannot be 0 or negative");
            }
            this.age = value;
        }
    }

    public override string ToString()
    {
        return string.Format("I am {0}", (this.GetType()).ToString());
    }

    public abstract void ProduceSound();
}



















