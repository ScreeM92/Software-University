namespace VehicleParkSystem.VehicleType
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using VehicleParkSystem.Interfaces;

    public class Truck : Vehicle
    {
        public Truck(string licensePlate, string owner, int reservedHours)
        {
            this.RegularRate = 4.75M;
            this.OvertimeRate = 6.2M;
        } 
    }
}
