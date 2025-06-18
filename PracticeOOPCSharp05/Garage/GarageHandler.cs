using PracticeOOPCSharp05.Models;

namespace PracticeOOPCSharp05.Garage
{
    internal class GarageHandler : IGarageHandler
    {
        private readonly IGarageDIFactory _garageFactory;
        private IGarage<IVehicle>? _garage;

        public IGarageSnapshot<IVehicle> Garage => _garage ?? throw new Exception("Garage has not been created yet.");

        public GarageHandler(IGarageDIFactory garageFactory)
        {
            _garageFactory = garageFactory;
        }

        public void CreateGarage(int capacity)
        {
            _garage = _garageFactory.CreateGarage(capacity);
        }

        public int PopuateGarage()
        {
            if (_garage == null)
            {
                throw new Exception("Garage has not been created yet.");
            }

            var vehicles = new List<IVehicle>
            {
                new Car("ABC123") { NumberOfDoors = 4, TrunkCapacity = 500, FuelType = CarFuelType.Petrol, Model = "Sedan", Year = 2020, Color = "Red", Weight = 1500, Length = 4.5, Width = 1.8, Height = 1.4, PassengerCapacity = 5 },
                new Car("GHI789") { NumberOfDoors = 4, TrunkCapacity = 450, FuelType = CarFuelType.Diesel, Model = "SUV", Year = 2018, Color = "Blue", Weight = 1800, Length = 4.8, Width = 2.0, Height = 1.7, PassengerCapacity = 7 },
                new Bus("JKL012") { HasWiFi = true, HasRestroom = true, NumberOfWheels = 6, Model = "City Bus", Year = 2015, Color = "Yellow", Weight = 12000, Length = 12.0, Width = 2.5, Height = 3.2, PassengerCapacity = 50 },
                new Bus("MNO345") { HasWiFi = false, HasRestroom = false, NumberOfWheels = 8, Model = "Tour Bus", Year = 2017, Color = "White", Weight = 14000, Length = 13.0, Width = 2.6, Height = 3.5, PassengerCapacity = 60 },
                new Bus("PQR678") { HasWiFi = true, HasRestroom = false, NumberOfWheels = 10, Model = "Double Decker", Year = 2016, Color = "Red", Weight = 16000, Length = 14.0, Width = 2.5, Height = 4.0, PassengerCapacity = 80 },
                new Boat("STU901") { MaxSpeed = 40, HasEngine = true, HasCabin = true, Model = "Yacht", Year = 2019, Color = "White", Weight = 8000, Length = 15.0, Width = 4.0, Height = 5.0, PassengerCapacity = 10 },
                new Motorcycle("EFG123") { HasSidecar = true, EngineVolume = 750, IsOffRoad = false, Model = "Touring", Year = 2018, Color = "Black", Weight = 300, Length = 2.2, Width = 0.8, Height = 1.2, PassengerCapacity = 2 },
                new Boat("VWX234") { MaxSpeed = 25, HasEngine = false, HasCabin = false, Model = "Sailboat", Year = 2015, Color = "Blue", Weight = 5000, Length = 10.0, Width = 3.0, Height = 4.0, PassengerCapacity = 6 },
                new Car("DEF456") { NumberOfDoors = 2, TrunkCapacity = 300, FuelType = CarFuelType.Electric, Model = "Coupe", Year = 2022, Color = "White", Weight = 1400, Length = 4.2, Width = 1.7, Height = 1.3, PassengerCapacity = 4 },
                new Boat("YZA567") { MaxSpeed = 50, HasEngine = true, HasCabin = false, Model = "Speedboat", Year = 2021, Color = "Red", Weight = 2000, Length = 8.0, Width = 2.5, Height = 2.0, PassengerCapacity = 4 },
                new Motorcycle("BCD890") { HasSidecar = false, EngineVolume = 600, IsOffRoad = true, Model = "Dirt Bike", Year = 2021, Color = "Red", Weight = 150, Length = 2.0, Width = 0.7, Height = 1.1, PassengerCapacity = 1 },
                new Motorcycle("HIJ456") { HasSidecar = false, EngineVolume = 500, IsOffRoad = true, Model = "Enduro", Year = 2020, Color = "Blue", Weight = 160, Length = 2.1, Width = 0.8, Height = 1.2, PassengerCapacity = 1 },
                new Airplane("KLM789") { NumberOfEngines = 2, EngineType = AirplaneEngineType.Jet, MaxAltitude = 35000, Model = "Private Jet", Year = 2015, Color = "White", Weight = 20000, Length = 20.0, Width = 15.0, Height = 6.0, PassengerCapacity = 8 },
                new Airplane("NOP012") { NumberOfEngines = 4, EngineType = AirplaneEngineType.Turboprop, MaxAltitude = 40000, Model = "Commercial", Year = 2018, Color = "Blue", Weight = 80000, Length = 50.0, Width = 45.0, Height = 12.0, PassengerCapacity = 200 },
                new Airplane("QRS345") { NumberOfEngines = 1, EngineType = AirplaneEngineType.Jet, MaxAltitude = 30000, Model = "Fighter Jet", Year = 2020, Color = "Gray", Weight = 10000, Length = 15.0, Width = 10.0, Height = 4.0, PassengerCapacity = 1 },
                new Car("TUV678") { NumberOfDoors = 5, TrunkCapacity = 600, FuelType = CarFuelType.Hybrid, Model = "Hatchback", Year = 2021, Color = "Green", Weight = 1600, Length = 4.3, Width = 1.8, Height = 1.5, PassengerCapacity = 5 },
                new Bus("WXY901") { HasWiFi = true, HasRestroom = true, NumberOfWheels = 12, Model = "Luxury Bus", Year = 2020, Color = "Blue", Weight = 15000, Length = 14.0, Width = 2.6, Height = 3.8, PassengerCapacity = 70 },
                new Boat("ZAB234") { MaxSpeed = 60, HasEngine = true, HasCabin = true, Model = "Cruiser", Year = 2020, Color = "Black", Weight = 10000, Length = 18.0, Width = 5.0, Height = 6.0, PassengerCapacity = 12 },
                new Motorcycle("CDE567") { HasSidecar = false, EngineVolume = 800, IsOffRoad = false, Model = "Cruiser", Year = 2019, Color = "White", Weight = 250, Length = 2.3, Width = 0.9, Height = 1.3, PassengerCapacity = 2 },
                new Airplane("FGH890") { NumberOfEngines = 3, EngineType = AirplaneEngineType.Turboprop, MaxAltitude = 45000, Model = "Cargo Plane", Year = 2017, Color = "Green", Weight = 90000, Length = 60.0, Width = 50.0, Height = 15.0, PassengerCapacity = 2 }
            };

            int added = 0;

            foreach (var vehicle in vehicles)
            {
                if (_garage.IsFull)
                    break;

                _garage.Park(vehicle);
                added++;
            }

            return added;
        }

        public void ParkVehicle(IVehicle vehicle)
        {
            if (_garage == null)
            {
                throw new Exception("Garage has not been created yet.");
            }

            _garage.Park(vehicle);
        }
        
        public void RemoveVehicle(string registationNumber)
        {
            if (_garage == null)
            {
                throw new Exception("Garage has not been created yet.");
            }

            _garage.Remove(registationNumber);
        }
    }
}
