namespace VehicleParkSystem.VehicleType
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using VehicleParkSystem.Interfaces;
    using VehicleType;

    public class Motorbike : Vehicle
    {
        public Motorbike(string licensePlate, string owner, int reservedHours)
        {
            this.RegularRate = 1.35M;
            this.OvertimeRate = 3M;
        }

       
    }
}
