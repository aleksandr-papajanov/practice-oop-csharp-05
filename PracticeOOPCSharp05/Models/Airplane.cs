using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOPCSharp05.Models
{
    internal class Airplane : Vehicle
    {
        public int? NumberOfEngines { get; set; }
        public AirplaneEngineType? EngineType { get; set; }
        public int? MaxAltitude { get; set; }

        public Airplane(string registrationNumber) : base(registrationNumber) { }

        public override string GetDetails()
        {
            return "Airplane Details:\n" +
                   $"Registration Number: {RegistrationNumber}\n" +
                   $"Model: {Model ?? "N/A"}\n" +
                   $"Year: {Year?.ToString() ?? "N/A"}\n" +
                   $"Color: {Color ?? "N/A"}\n" +
                   $"Weight: {Weight?.ToString() ?? "N/A"} kg\n" +
                   $"Length: {Length?.ToString() ?? "N/A"} m\n" +
                   $"Width: {Width?.ToString() ?? "N/A"} m\n" +
                   $"Height: {Height?.ToString() ?? "N/A"} m\n" +
                   $"Passenger Capacity: {PassengerCapacity?.ToString() ?? "N/A"}\n" +
                   $"Number of Engines: {NumberOfEngines?.ToString() ?? "N/A"}\n" +
                   $"Engine Type: {EngineType?.ToString() ?? "N/A"}\n" +
                   $"Max Altitude: {MaxAltitude?.ToString() ?? "N/A"} m";
        }
    }
}
