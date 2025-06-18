using PracticeOOPCSharp05.Models;

namespace PracticeOOPCSharp05.Garage
{
    public interface IGarageSnapshot<T> : IEnumerable<T>
        where T : IVehicle
    {
        int Count { get; }
        int Capacity { get; }
        bool IsFull => Count >= Capacity;
        bool IsEmpty => Count == 0;

        T? Find(string registrationNumber);
    }
}
