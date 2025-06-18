using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOPCSharp05.Models
{
    internal class Boat : Vehicle
    {
        public int? MaxSpeed { get; set; }
        public bool? HasEngine { get; set; }
        public bool? HasCabin { get; set; }

        public Boat(string registrationNumber) : base(registrationNumber) { }

        public override string GetDetails()
        {
            return "Boat Details:\n" +
                   $"Registration Number: {RegistrationNumber}\n" +
                   $"Model: {Model ?? "N/A"}\n" +
                   $"Year: {Year?.ToString() ?? "N/A"}\n" +
                   $"Color: {Color ?? "N/A"}\n" +
                   $"Weight: {Weight?.ToString() ?? "N/A"} kg\n" +
                   $"Length: {Length?.ToString() ?? "N/A"} m\n" +
                   $"Width: {Width?.ToString() ?? "N/A"} m\n" +
                   $"Height: {Height?.ToString() ?? "N/A"} m\n" +
                   $"Passenger Capacity: {PassengerCapacity?.ToString() ?? "N/A"}\n" +
                   $"Max Speed: {MaxSpeed?.ToString() ?? "N/A"} km/h\n" +
                   $"Has Engine: {(HasEngine.HasValue ? (HasEngine.Value ? "Yes" : "No") : "N/A")}\n" +
                   $"Has Cabin: {(HasCabin.HasValue ? (HasCabin.Value ? "Yes" : "No") : "N/A")}";
        }
    }
}
