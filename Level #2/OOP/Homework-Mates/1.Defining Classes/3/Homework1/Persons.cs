using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class Program
    {
        class Person 
        {
            private string name;
            private int age;
            private string email;

            public Person(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }

            public Person(string name, int age,string email){}

            public int Age 
            {
                get { return this.age; }
                set 
                {
                    if (age < 1 || age > 100)
                        throw new ArgumentException("The age must be between 1 and 100");
                     this.age = value;
                }
            }

            public string Name
            {
                get { return this.name; }
                set
                {
                    if (String.IsNullOrEmpty(value))
                        throw new ArgumentException("Invalid name!");
                    this.name = value;
                }
            }
            public string Email
            {
                get { return this.email; }
                set
                    { 
                if(null!=value && (value.Length==0 || !value.Contains("@"))) throw new ArgumentException("Invalid email!");
                this.email = value;

                }
            }

            public override string ToString()
            {
                return string.Format("name: {0}, age: {1}", this.Name, this.Age) + (this.Email == null ? "" : ", email: " + this.Email);
            }

        }

        static void Main(string[] args)
        {
            Person per = new Person("Sasho", 32, "sasho@abv.bg");
            Console.WriteLine(per.Name);
            Console.WriteLine(per.Age);
            Console.WriteLine(per.Email);


        }
    }
