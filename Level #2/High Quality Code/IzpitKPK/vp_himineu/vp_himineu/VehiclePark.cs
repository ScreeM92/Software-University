namespace VehicleParkSystem
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using VehicleParkSystem.Interfaces;
    using VehicleParkSystem.VehicleType;

    public class VehiclePark : IVehiclePark
    {
        private Layout layout;
        private Data data;

        public VehiclePark(int numberOfSectors, int placesPerSector)
        {
            this.layout = new Layout(numberOfSectors, placesPerSector);
            this.data = new Data(numberOfSectors);
        }

        public string InsertCar(Car car, int sector, int placeNumber, DateTime startTime)
        {
            if (sector > layout.numberOfSectors) return string.Format("There is no sector {0} in the park", sector);
            if (placeNumber > layout.placesPerSector) return string.Format("There is no place {0} in sector {1}", placeNumber, sector);

            if (data.park.ContainsKey(string.Format("({0},{1})", sector, placeNumber)))
            {
                return string.Format("The place ({0},{1}) is occupied", sector, placeNumber);
            }
            if (data.num.ContainsKey(car.LicensePlate))
            {
                return string.Format("There is already a vehicle with license plate {0} in the park", car.LicensePlate);
            }

            data.carsInPark[car] = string.Format("({0},{1})", sector, placeNumber);
            data.park[string.Format("({0},{1})", sector, placeNumber)] = car;
            data.num[car.LicensePlate] = car;
            data.dateAndTime[car] = startTime;
            data.owner[car.Owner].Add(car);
            data.count[sector - 1]--;
            return string.Format("{0} parked successfully at place ({1},{2})", car.GetType().Name, sector, placeNumber);
        }

        public string InsertMotorbike(Motorbike motor, int sector, int placeNumber, DateTime startTime)
        {
            if (sector > layout.numberOfSectors) return string.Format("There is no sector {0} in the park", sector);
            if (placeNumber > layout.placesPerSector) return string.Format("There is no place {0} in sector {1}", placeNumber, sector);
            if (data.park.ContainsKey(string.Format("({0},{1})", sector, placeNumber)))
            {
                return string.Format("The place ({0},{1}) is occupied", sector, placeNumber);
            }
            if (data.num.ContainsKey(motor.LicensePlate))
            {
                return string.Format("There is already a vehicle with license plate {0} in the park", motor.LicensePlate);
            }

            data.carsInPark[motor] = string.Format("({0},{1})", sector, placeNumber);
            data.park[string.Format("({0},{1})", sector, placeNumber)] = motor;
            data.num[motor.LicensePlate] = motor;
            data.dateAndTime[motor] = startTime;
            data.owner[motor.Owner].Add(motor);
            data.count[sector - 1]++;

            return string.Format("{0} parked successfully at place ({1},{2})", motor.GetType().Name, sector, placeNumber);
        }

        public string InsertTruck(Truck truck, int sector, int placeNumber, DateTime startTime)
        {
            if (sector > layout.numberOfSectors) return string.Format("There is no sector {0} in the park", sector);
            if (placeNumber > layout.placesPerSector) return string.Format("There is no place {0} in sector {1}", placeNumber, sector);
            if (data.park.ContainsKey(string.Format("({0},{1})", sector, placeNumber)))
            {
                return string.Format("The place ({0},{1}) is occupied", sector, placeNumber);
            }
            if (data.num.ContainsKey(truck.LicensePlate))
            {
                return string.Format("There is already a vehicle with license plate {0} in the park", truck.LicensePlate);
            }

            data.carsInPark[truck] = string.Format("({0},{1})", sector, placeNumber);
            data.park[string.Format("({0},{1})", sector, placeNumber)] = truck;
            data.num[truck.LicensePlate] = truck;
            data.dateAndTime[truck] = startTime;
            data.owner[truck.Owner].Add(truck);
            return string.Format("{0} parked successfully at place ({1},{2})", truck.GetType().Name, sector, placeNumber);
        }

        public string ExitVehicle(string licensePlate, DateTime endTime, decimal amountPaid)
        {
            var vehicle = (data.num.ContainsKey(licensePlate)) ? data.num[licensePlate] : null;
            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park", licensePlate);
            }

            var start = data.dateAndTime[vehicle];
            int endd = (int)Math.Round((endTime - start).TotalHours);
            var ticket = new StringBuilder();
            ticket.AppendLine(new string('*', 20)).AppendFormat("{0}", vehicle.ToString())
                .AppendLine().AppendFormat("at place {0}", data.carsInPark[vehicle])
                .AppendLine().AppendFormat("Rate: ${0:F2}", (vehicle.ReservedHours * vehicle.RegularRate))
                .AppendLine().AppendFormat("Overtime rate: ${0:F2}",
                (endd > vehicle.ReservedHours ? (endd - vehicle.ReservedHours) * vehicle.OvertimeRate : 0))
                .AppendLine().AppendLine(new string('-', 20))
                .AppendFormat("Total: ${0:F2}", (vehicle.ReservedHours * vehicle.RegularRate +
                (endd > vehicle.ReservedHours ? (endd - vehicle.ReservedHours) * vehicle.OvertimeRate : 0)))
                .AppendLine().AppendFormat("Paid: ${0:F2}", amountPaid)
                .AppendLine().AppendFormat("Change: ${0:F2}", amountPaid - ((vehicle.ReservedHours * vehicle.RegularRate) +
                (endd > vehicle.ReservedHours ? (endd - vehicle.ReservedHours) * vehicle.OvertimeRate : 0)))
                .AppendLine().Append(new string('*', 20));

            //DELETE
            int sector = int.Parse(data.carsInPark[vehicle].Split(new[] { "(", ",", ")" }, StringSplitOptions.RemoveEmptyEntries)[0]);
            data.park.Remove(data.carsInPark[vehicle]);
            data.carsInPark.Remove(vehicle);
            data.num.Remove(vehicle.LicensePlate);
            data.dateAndTime.Remove(vehicle);
            data.owner.Remove(vehicle.Owner, vehicle);
            data.count[sector - 1]--;

            //END OF DELETE
            return ticket.ToString();
        }

        public string GetStatus()
        {
            var places = data.count.Select((sssss, iiiii) =>
            string.Format("Sector {0}: {1} / {2} ({3}% full)",
                            iiiii + 1,
                            sssss,
                            layout.placesPerSector,
                            Math.Round((double)sssss / layout.placesPerSector * 100)));

            return string.Join(Environment.NewLine, places);
        }

        public string FindVehicle(string licensePlate)
        {
            var vehicle = (data.num.ContainsKey(licensePlate)) ? data.num[licensePlate] : null;
            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park", licensePlate);
            }

            return Input(new[] { vehicle });
        }

        public string FindVehiclesByOwner(string owner)
        {
            if (!data.park.Values.Where(v => v.Owner == owner).Any())
            {
                return string.Format("No vehicles by {0}", owner);
            }

            var found = data.park.Values.ToList();
            var res = found.Where(v => v.Owner == owner).ToList();
 
            return string.Join(Environment.NewLine, Input(res));
        }

        private string Input(IEnumerable<IVehicle> car)
        {
            return string.Join(Environment.NewLine, car.Select(vehicle => string.Format("{0}{1}Parked at {2}",
                vehicle.ToString(), Environment.NewLine, data.carsInPark[vehicle])));
        }
    }
}