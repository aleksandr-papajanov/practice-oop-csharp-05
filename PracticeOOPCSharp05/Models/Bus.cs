using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOPCSharp05.Models
{
    internal class Bus : Vehicle
    {
        public bool? HasWiFi { get; set; }
        public bool? HasRestroom { get; set; }
        public int? NumberOfWheels { get; set; }

        public Bus(string registrationNumber) : base(registrationNumber) { }

        public override string GetDetails()
        {
            return "Bus Details:\n" +
                   $"Registration Number: {RegistrationNumber}\n" +
                   $"Model: {Model ?? "N/A"}\n" +
                   $"Year: {Year?.ToString() ?? "N/A"}\n" +
                   $"Color: {Color ?? "N/A"}\n" +
                   $"Weight: {Weight?.ToString() ?? "N/A"} kg\n" +
                   $"Length: {Length?.ToString() ?? "N/A"} m\n" +
                   $"Width: {Width?.ToString() ?? "N/A"} m\n" +
                   $"Height: {Height?.ToString() ?? "N/A"} m\n" +
                   $"Passenger Capacity: {PassengerCapacity?.ToString() ?? "N/A"}\n" +
                   $"Has WiFi: {(HasWiFi.HasValue ? (HasWiFi.Value ? "Yes" : "No") : "N/A")}\n" +
                   $"Has Restroom: {(HasRestroom.HasValue ? (HasRestroom.Value ? "Yes" : "No") : "N/A")}\n" +
                   $"Number of Wheels: {NumberOfWheels?.ToString() ?? "N/A"}";
        }
    }
}
