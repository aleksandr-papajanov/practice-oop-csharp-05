using PracticeOOPCSharp05.Garage;
using PracticeOOPCSharp05.Models;
using System.Collections;

public class Garage<T> : IGarage<T> where T : IVehicle
{
    private readonly T?[] _vehicles; // массив может содержать null для свободных мест
    private int _count = 0;

    public int Count => _count;

    public int Capacity { get; }

    public Garage(int capacity)
    {
        if (capacity <= 0)
        {
            throw new Exception("Capacity must be greater than zero.");
        }

        Capacity = capacity;
        _vehicles = new T?[capacity];
    }

    public T? Find(string registrationNumber)
    {
        foreach (var vehicle in _vehicles)
        {
            if (vehicle != null && vehicle.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase))
            {
                return vehicle;
            }
        }

        return default;
    }

    public void Park(T vehicle)
    {
        if (_count >= Capacity)
        {
            throw new Exception("Garage is full. Cannot park more vehicles.");
        }

        if (Find(vehicle.RegistrationNumber) != null)
        {
            throw new Exception("A vehicle with the same registration number already exists.");
        }

        for (int i = 0; i < _vehicles.Length; i++)
        {
            // free slot
            if (_vehicles[i] == null)
            {
                _vehicles[i] = vehicle;
                _count++;

                return;
            }
        }

        throw new Exception("No free slots available in the garage.");
    }

    public void Remove(string registrationNumber)
    {
        for (int i = 0; i < _vehicles.Length; i++)
        {
            if (_vehicles[i] != null && _vehicles[i]!.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase))
            {
                // free slot
                _vehicles[i] = default;
                _count--;

                return;
            }
        }

        throw new Exception($"Vehicle with registration number {registrationNumber} not found in the garage.");
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var v in _vehicles)
        {
            if (v != null)
            {
                yield return v;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}