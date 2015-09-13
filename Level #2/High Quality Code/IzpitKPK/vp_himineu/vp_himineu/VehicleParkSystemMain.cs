namespace VehicleParkSystem
{
    using System.Globalization;
    using System.Threading;

    public static class VehicleParkSystemMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var engine = new Mechanism();
            engine.Run();
        }
    }
}