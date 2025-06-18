using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOPCSharp05.Models
{
    public interface IVehicle
    {
        string RegistrationNumber { get; }
        string? Model { get; set; }
        int? Year { get; set; }
        string? Color { get; set; }
        double? Weight { get; set; }
        double? Length { get; set; }
        double? Width { get; set; }
        double? Height { get; set; }
        int? PassengerCapacity { get; set; }

        string GetSummary();
        string GetDetails();
    }
}
