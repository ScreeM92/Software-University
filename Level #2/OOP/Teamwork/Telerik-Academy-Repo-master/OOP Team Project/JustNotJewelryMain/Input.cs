using System;
using System.Linq;

namespace JustNotJewelryMain
{
    class Input : IInput
    {
        public event EventHandler OnLeftArrowPress;
        public event EventHandler OnRightArrowPress;
        public event EventHandler OnSpacebarPress;
        public event EventHandler OnUpArrowPress;
        public event EventHandler OnDownArrowPress;
        public event EventHandler OnSButtonPress;

        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                if (pressedKey.Key.Equals(ConsoleKey.LeftArrow) || pressedKey.Key.Equals(ConsoleKey.A))
                {
                    if (this.OnLeftArrowPress != null)
                    {
                        this.OnLeftArrowPress(this, new EventArgs());   
                    }
                }

                if (pressedKey.Key.Equals(ConsoleKey.RightArrow) || pressedKey.Key.Equals(ConsoleKey.D))
                {
                    if (this.OnRightArrowPress != null)
                    {
                        this.OnRightArrowPress(this, new EventArgs());
                    }
                }

                if (pressedKey.Key.Equals(ConsoleKey.Spacebar))
                {
                    this.OnSpacebarPress(this, new EventArgs());
                }

                if (pressedKey.Key.Equals(ConsoleKey.UpArrow))
                {
                    if (this.OnUpArrowPress != null)
                    {
                        try
                        {
                            this.OnUpArrowPress(this, new EventArgs());
                        }
                        catch (LevelSpeedException)
                        {
                            Console.WriteLine();
                            Console.Error.WriteLine("Slow down bro!");
                        }
                    }
                }

                if (pressedKey.Key.Equals(ConsoleKey.DownArrow))
                {
                    if (this.OnDownArrowPress != null)
                    {
                        try
                        {
                            this.OnDownArrowPress(this, new EventArgs());
                        }
                        catch (LevelSpeedException)
                        {
                            Console.Error.WriteLine("Increase the speed granny");
                        }
                    }
                }

                if (pressedKey.Key.Equals(ConsoleKey.S))
                {
                    if (this.OnSButtonPress != null)
                    {
                        this.OnSButtonPress(this, new EventArgs());
                    }
                }

            }
        }
    }
}
