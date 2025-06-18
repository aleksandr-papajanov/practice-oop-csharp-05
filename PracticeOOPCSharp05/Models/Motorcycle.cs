using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOPCSharp05.Models
{
    internal class Motorcycle : Vehicle
    {
        public bool? HasSidecar { get; set; }
        public double? EngineVolume { get; set; }
        public bool? IsOffRoad { get; set; }

        public Motorcycle(string registrationNumber) : base(registrationNumber) { }

        public override string GetDetails()
        {
            return "Motorcycle Details:\n" +
                   $"Registration Number: {RegistrationNumber}\n" +
                   $"Model: {Model ?? "N/A"}\n" +
                   $"Year: {Year?.ToString() ?? "N/A"}\n" +
                   $"Color: {Color ?? "N/A"}\n" +
                   $"Weight: {Weight?.ToString() ?? "N/A"} kg\n" +
                   $"Length: {Length?.ToString() ?? "N/A"} m\n" +
                   $"Width: {Width?.ToString() ?? "N/A"} m\n" +
                   $"Height: {Height?.ToString() ?? "N/A"} m\n" +
                   $"Passenger Capacity: {PassengerCapacity?.ToString() ?? "N/A"}\n" +
                   $"Has Sidecar: {(HasSidecar.HasValue ? (HasSidecar.Value ? "Yes" : "No") : "N/A")}\n" +
                   $"Engine Volume: {EngineVolume?.ToString() ?? "N/A"} L\n" +
                   $"Is Off-Road: {(IsOffRoad.HasValue ? (IsOffRoad.Value ? "Yes" : "No") : "N/A")}";
        }
    }
}
