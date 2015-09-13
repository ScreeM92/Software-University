using System;
using TheSlum.GameEngine;
using System.Threading;
namespace TheSlum
{
    public class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            Engine engine = new ExtendedEngine();
            engine.Run();
        }
    }
}
