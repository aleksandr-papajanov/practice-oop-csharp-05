using PracticeOOPCSharp05.Garage;
using PracticeOOPCSharp05.Models;

public interface IGarage<T> : IGarageSnapshot<T>
    where T : IVehicle
{
    void Park(T vehicle);
    void Remove(string registrationNumber);
}