using System;

    class Frog : Animals, ISound
    {
        public Frog(string name, int age, Gender gender)
            :base(name, age, gender)
        {

        }

        public void ProduceSound()
        {
            Console.WriteLine("booooooooooooook");
        }
    }

