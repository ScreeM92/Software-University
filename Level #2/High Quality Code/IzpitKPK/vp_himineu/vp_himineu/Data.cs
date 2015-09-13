namespace VehicleParkSystem
{
    using Wintellect.PowerCollections;
    using System;
    using System.Collections.Generic;
    using VehicleParkSystem.Interfaces;

    class Data
    {
        public Dictionary<IVehicle, string> carsInPark { get; set; }
        public Dictionary<string, IVehicle> park { get; set; }
        public Dictionary<string, IVehicle> num { get; set; }
        public Dictionary<IVehicle, DateTime> dateAndTime { get; set; }
        public MultiDictionary<string, IVehicle> owner { get; set; }
        public int[] count { get; set; }

        public Data(int numberOfSectors)
        {
            this.carsInPark = new Dictionary<IVehicle, string>();
            this.park = new Dictionary<string, IVehicle>();
            this.num = new Dictionary<string, IVehicle>();
            this.dateAndTime = new Dictionary<IVehicle, DateTime>();
            this.owner = new MultiDictionary<string, IVehicle>(false);
            this.count = new int[numberOfSectors];
        }
    }
}

