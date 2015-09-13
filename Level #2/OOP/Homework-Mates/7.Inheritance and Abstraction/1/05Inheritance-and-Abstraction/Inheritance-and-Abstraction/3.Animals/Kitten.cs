﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Animals
{
    class Kitten :Cat
    {
        public Kitten(string name, int age)
            : base(name, age, Genders.Female)
        {

        }
        public override void ProduceSound()
        {
            Console.WriteLine("I say myauuu!");
        }
    }
}
