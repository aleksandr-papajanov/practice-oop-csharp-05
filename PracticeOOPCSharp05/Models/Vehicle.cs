using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOPCSharp05.Models
{
    internal abstract class Vehicle : IVehicle
    {
        public string RegistrationNumber { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }
        public string? Color { get; set; }
        public double? Weight { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public int? PassengerCapacity { get; set; }

        protected Vehicle(string registrationNumber)
        {
            RegistrationNumber = registrationNumber;
        }

        public virtual string GetSummary()
        {
            return $"{GetType().Name}, Registration: {RegistrationNumber}, Color: {Color ?? "N/A"}";
        }

        public abstract string GetDetails();
    }
}
