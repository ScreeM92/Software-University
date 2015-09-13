namespace VehicleParkSystem
{
    using System;
    using VehicleParkSystem.Interfaces;
    using VehicleParkSystem.VehicleType;

    public class Executor
    {
        public VehiclePark VehiclePark { get; set; }

        public string Execute(ICommandHandler command)
        {
            if (command.Name != "SetupPark" && VehiclePark == null)
            {
                return "The vehicle park has not been set up";
            }

            switch(command.Name.ToString())
            {
                case "SetupPark":
                    VehiclePark = new VehiclePark(int.Parse(command.Parameters["sectors"]), int.Parse(command.Parameters["placesPerSector"]));
                    return "Vehicle park created";

                case "Park":
                    switch (command.Parameters["type"])
                        {
                            case "car":
                                return VehiclePark.InsertCar(new Car(command.Parameters["licensePlate"],
                                       command.Parameters["owner"], int.Parse(command.Parameters["hours"])), int.Parse(command.Parameters["sector"]),
                                       int.Parse(command.Parameters["place"]), DateTime.Parse(command.Parameters["time"], null,
                                       System.Globalization.DateTimeStyles.RoundtripKind));

                            case "motorbike":
                                return VehiclePark.InsertMotorbike(new Motorbike(command.Parameters["licensePlate"],
                                      command.Parameters["owner"], int.Parse(command.Parameters["hours"])), int.Parse(command.Parameters["sector"]),
                                      int.Parse(command.Parameters["place"]), DateTime.Parse(command.Parameters["time"], null,
                                      System.Globalization.DateTimeStyles.RoundtripKind));

                            case "truck":
                                return VehiclePark.InsertTruck(new Truck(command.Parameters["licensePlate"],
                                      command.Parameters["owner"], int.Parse(command.Parameters["hours"])), int.Parse(command.Parameters["sector"]),
                                      int.Parse(command.Parameters["place"]), DateTime.Parse(command.Parameters["time"], null,
                                      System.Globalization.DateTimeStyles.RoundtripKind));
                        }
                    break;

                case "Exit":
                    return VehiclePark.ExitVehicle(command.Parameters["licensePlate"],
                           DateTime.Parse(command.Parameters["time"], null, System.Globalization.DateTimeStyles.RoundtripKind),
                           decimal.Parse(command.Parameters["money"]));

                case "Status": return VehiclePark.GetStatus();
                case "FindVehicle": return VehiclePark.FindVehicle(command.Parameters["licensePlate"]);
                case "VehiclesByOwner": return VehiclePark.FindVehiclesByOwner(command.Parameters["owner"]);
                default:
                    throw new IndexOutOfRangeException("Invalid command.");
            }

            return string.Empty;
        }
    }
}
