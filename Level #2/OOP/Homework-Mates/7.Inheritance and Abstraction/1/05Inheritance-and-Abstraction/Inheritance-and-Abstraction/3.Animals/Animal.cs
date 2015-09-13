using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private Genders gender;

        public string Name { get; set; }
        public int Age { get; set; }
        public Genders Gender { get; set; }
        

        public Animal(string name, int age, Genders gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        public abstract void ProduceSound();
    }
}
