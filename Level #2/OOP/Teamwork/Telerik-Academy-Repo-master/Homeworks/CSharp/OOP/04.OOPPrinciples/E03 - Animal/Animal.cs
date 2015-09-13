using System;
using System.Linq;

public abstract class Animal 
{
    public abstract string GetName();
    public abstract int GetAge();

    public int Age { get; private set; }
    public string Name { get; private set; }
    public string Sex { get; private set; }

    public Animal(string name) : this(0, name, "undefined") { }

    public Animal(int age, string name) : this(age, name, "undefined") { }
    
    public Animal(int age, string name, string sex)
    {
        if (age < 0)
        {
            throw new FormatException("The age must be positive integer!");
        }
        if (sex != "female" && sex != "undefined")
        {
            if (sex != "male")
            {   
                throw new FormatException("The sex can be only male and female!");    
            }
        }

        this.Age = age;
        this.Name = name;
        this.Sex = sex;
    }

    public static double GetAverageAge(dynamic listOfAnimals)
    {
        double averageAge = 0;
        for (int i = 0; i < listOfAnimals.Length; i++)
        {
            averageAge += listOfAnimals[i].Age;
        }
        averageAge /= listOfAnimals.Length;

        return averageAge;
    }
}
