namespace VehicleParkSystem.VehicleType
{
    public class Car : Vehicle
    {
        public Car(string licensePlate, string person, int reservedHours)
        {
            this.RegularRate = 2M;
            this.OvertimeRate = 3.5M;
        }
    }
}











