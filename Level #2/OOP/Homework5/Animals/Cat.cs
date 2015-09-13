using System;

    class Cat : Animals, ISound
    {
        public Cat(string name, int age, Gender gender)
            :base(name, age, gender)
        {

        }

        public void ProduceSound()
        {
            Console.WriteLine("barrrrkkkkkkk");
        }
    }


