using PracticeOOPCSharp05.Models;

namespace PracticeOOPCSharp05.Garage
{
    internal interface IGarageHandler
    {
        IGarageSnapshot<IVehicle> Garage { get; }

        void CreateGarage(int capacity);
        int PopuateGarage();
        void ParkVehicle(IVehicle vehicle);
        void RemoveVehicle(string registrationNumber);
    }
}
