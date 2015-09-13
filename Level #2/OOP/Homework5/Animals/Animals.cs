using System;

abstract class Animals
{
    private string name;
    private int age;
    private Gender gender;

    public Animals(string name, int age, Gender gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
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
            this.age = value;
        }
    }

    public Gender Gender
    {
        get
        {
            return this.gender;
        }
        set
        {
            this.gender = value;
        }
    }
}