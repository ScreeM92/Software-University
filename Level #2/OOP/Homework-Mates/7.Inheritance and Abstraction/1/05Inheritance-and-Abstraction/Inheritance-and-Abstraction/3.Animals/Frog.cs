using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Animals
{
    class Frog :Animal
    {
        public Frog(string name, int age, Genders gender) :base(name, age, gender)
        {

        }
        public override void ProduceSound()
        {
            Console.WriteLine("I say krya-krya!");
        }
    }
}
