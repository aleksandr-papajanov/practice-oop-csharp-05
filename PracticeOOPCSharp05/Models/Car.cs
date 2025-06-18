using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOPCSharp05.Models
{
    internal class Car : Vehicle
    {
        public int? NumberOfDoors { get; set; }
        public double? TrunkCapacity { get; set; }
        public CarFuelType? FuelType { get; set; }

        public Car(string registrationNumber) : base(registrationNumber) { }

        public override string GetDetails()
        {
            return "Car Details:\n" +
                   $"Registration Number: {RegistrationNumber}\n" +
                   $"Model: {Model ?? "N/A"}\n" +
                   $"Year: {Year?.ToString() ?? "N/A"}\n" +
                   $"Color: {Color ?? "N/A"}\n" +
                   $"Weight: {Weight?.ToString() ?? "N/A"} kg\n" +
                   $"Length: {Length?.ToString() ?? "N/A"} m\n" +
                   $"Width: {Width?.ToString() ?? "N/A"} m\n" +
                   $"Height: {Height?.ToString() ?? "N/A"} m\n" +
                   $"Passenger Capacity: {PassengerCapacity?.ToString() ?? "N/A"}\n" +
                   $"Number of Doors: {NumberOfDoors?.ToString() ?? "N/A"}\n" +
                   $"Trunk Capacity: {TrunkCapacity?.ToString() ?? "N/A"} L\n" +
                   $"Fuel Type: {FuelType?.ToString() ?? "N/A"}";
        }
    }
}
