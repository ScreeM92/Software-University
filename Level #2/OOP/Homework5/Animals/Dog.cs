using System;

    class Dog : Animals, ISound
    {
        public Dog(string name, int age, Gender gender)
            :base(name, age, gender)
        {

        }



        public void ProduceSound()
        {
            Console.WriteLine("mquuuuuuuuu");
        }
    }

