using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public abstract class Animal : ISound
    {
        private string name;
        private int age;
        private Gender gender;

        public Animal(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Name can not be an empty string.");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Age", "Age can not be a negative number.");
                }

                this.age = value;
            }
        }

        public Gender Gender
        {
            get { return this.gender; }
            protected set { this.gender = value; }
        }

        // define an abstract method ProduceSound() to be implemented by the derived classes
        public abstract string ProduceSound();

        // override the ToString() method
        public override string ToString()
        {
            return String.Format("my name is {0}, I'm {1} years old, I'm {2} and I can {3}",
                 this.name, this.age, this.gender, this.ProduceSound());
        }
    }
    public abstract class Cat : Animal
    {
        public Cat(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }
    }
    public class Dog : Animal, ISound
    {
        public Dog(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }

        // implemetn the Isound interface 
        public override string ProduceSound()
        {
            return "bark";
        }

        // define a method for fetching a stick
        public void FetchStick()
        {
            Console.WriteLine("Throw me a stick and I'll fetch it for you.");
        }

        // override the ToString() method
        public override string ToString()
        {
            return String.Format("I'm a dog ") + base.ToString();
        }
    }
    public class Frog : Animal, ISound
    {
        public Frog(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }

        // implement the ISound interface
        public override string ProduceSound()
        {
            return "rrrebbet";
        }

        // define a method for jumping
        public void Jump()
        {
            Console.WriteLine("Now I'll jump on your head.");
        }

        // override the ToString() method
        public override string ToString()
        {
            return String.Format("I'm a frog ") + base.ToString();
        }

    }
    public enum Gender
    {
        Male,
        Female,
    }
    public interface ISound
    {
        void ProduceSound();
    }
    public class Kitten : Cat, ISound
    {
        public Kitten(string name, int age)
            : base(name, age, Gender.Female)
        {
        }

        // implemetn the ISound interface
        public override string ProduceSound()
        {
            return "miaooow";
        }

        // define a cry method
        public void Cry()
        {
            Console.WriteLine("I'm so cute I'll make you cry");
        }

        // override the ToString() method
        public override string ToString()
        {
            return String.Format("I'm a kiiten ") + base.ToString();
        }
    }
    public class Tomcat : Cat, ISound
    {
        public Tomcat(string name, int age)
            : base(name, age, Gender.Female)
        {
        }

        // implemetn the ISound interface
        public override string ProduceSound()
        {
            return "phhh";
        }

        // define a Piss() method
        public void Piss()
        {
            Console.WriteLine("I'll piss all over your carpet");
        }

        // override the ToString() method
        public override string ToString()
        {
            return String.Format("I'm a tomcat ") + base.ToString();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog("Pesho", 3, Gender.Male);
            Console.WriteLine(dog);
            dog.FetchStick();

            Console.WriteLine();

            Frog frog = new Frog("Peter", 33, Gender.Male);
            Console.WriteLine(frog);
            frog.Jump();

            Console.WriteLine();

            Kitten kitty = new Kitten("Ioio", 1);
            Console.WriteLine(kitty);
            kitty.Cry();

            Console.WriteLine();

            Tomcat tomcat = new Tomcat("Gogo", 12);
            Console.WriteLine(tomcat);
            tomcat.Piss();

            Console.WriteLine();

            // create an array of Animals
            Animal[] animals = new Animal[]
            {
                new Dog("Ares",3, Gender.Male),
                new Frog("Mitko", 1, Gender.Female),
                new Kitten("Mac", 1),
                new Tomcat("Cotka",2),
                new Dog("Saires", 4, Gender.Male),
                new Frog("Stilian", 1, Gender.Female),
                new Kitten("Ioio", 2),
                new Tomcat("Antony",6),
                new Dog("Roy",2, Gender.Male),
                new Frog("Angelina", 6, Gender.Female),
                new Kitten("Alex", 1),
                new Tomcat("Mecjo",4),
            };

            // calculate the aveage age of each animal and print them 
            var averageAge =
                from an in animals
                group an by new { GroupName = an.GetType().Name } into gr
                select new
                {
                    GroupName = gr.Key.GroupName,
                    AvarageAge = gr.Average(an => an.Age)
                };

            foreach (var animal in averageAge)
            {
                Console.WriteLine(String.Format("Group: {0}, AvarageAge: {1:0.00}.", animal.GroupName, animal.AvarageAge));
            }
        }
    }
}
