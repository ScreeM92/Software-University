using System;
    public abstract class Human : ISpeakable
    {
        private string name;

        public Human(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException("...");
                }
                this.name = value;
            }
        }


        public virtual void SayName() 
        {
            Console.WriteLine(this.Name);
        }

        public abstract void Speak();
    }

