using PracticeOOPCSharp05.Garage;
using PracticeOOPCSharp05.Models;

namespace PracticeOOPCSharp05.UI
{
    internal class ConsoleUI : IUI
    {
        private readonly IGarageHandler _garageHandler;

        public ConsoleUI(IGarageHandler garageHandler)
        {
            _garageHandler = garageHandler;
        }

        public void Run()
        {
            var isComplete = false;
            var menu = new List<IMenuAction>
            {
                new MenuAction("1", "Create Garage", CreateGarageAction),
                new MenuAction("2", "Populate Garage", PopulateGarageAction),
                new MenuAction("3", "Show Garage", ShowGarageAction),
                new MenuAction("4", "Show statistics", ShowStatistics),
                new MenuAction("5", "Find vehicle", FindVehicleAction),
                new MenuAction("6", "Park vehicle", ParkVehicleAction),
                new MenuAction("7", "Remove vehicle", RemoveVehicleAction),
                new MenuAction("8", "Search", SearchAction),
                new MenuAction("0", "Exit", () => isComplete = true)
            };

            while (!isComplete)
            {
                Console.Clear();
                menu.Print(this);

                var action = Read((string key, out IMenuAction result) =>
                    (result = menu.FirstOrDefault(a => a.Key == key)!) != null, "Select an action: ");

                try
                {
                    action.Invoke();
                }
                catch (Exception ex)
                {
                    Write($"Error: {ex.Message}", UIMessageType.Error);
                }

                Write("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void CreateGarageAction()
        {
            int capacity = Read<int>(Validators.IntPositive, "Enter garage capacity: ");

            _garageHandler.CreateGarage(capacity);
            Write($"Garage created with capacity {capacity}.", UIMessageType.Success);
        }

        private void PopulateGarageAction()
        {
            var added = _garageHandler.PopuateGarage();
            Write($"Garage populated with {added} vehicles", UIMessageType.Success);
        }

        private void ShowGarageAction()
        {
            Write($"Garage is filled with {_garageHandler.Garage.Count} " +
                  $"vehicles out of {_garageHandler.Garage.Capacity} places.",
                  UIMessageType.Title);

            foreach (var vehicle in _garageHandler.Garage)
            {
                Write(vehicle.GetSummary());
            }
        }

        private void ShowStatistics()
        {
            if (_garageHandler.Garage.IsEmpty)
            {
                Write("No vehicles in the garage.", UIMessageType.Error);
                return;
            }

            var stats = new Dictionary<string, int>();

            foreach (var vehicle in _garageHandler.Garage)
            {
                var key = vehicle.GetType().Name;
                stats[key] = stats.ContainsKey(key) ? stats[key] + 1 : 1;
            }

            Write("Garage Statistics:", UIMessageType.Title);

            foreach (var type in stats)
            {
                Write($"{type.Key}: {type.Value}");
            }
        }

        private void FindVehicleAction()
        {
            var registration = Read<string>(Validators.StringNotEmpty, "Enter registration number: ");

            var vehicle = _garageHandler.Garage.Find(registration);

            if (vehicle != null)
            {
                Write($"Vehicle found:", UIMessageType.Title);
                Write(vehicle.GetDetails());
            }
            else
            {
                Write($"No vehicle found with registration number '{registration}'.", UIMessageType.Error);
            }
        }

        private void ParkVehicleAction()
        {
            if (_garageHandler.Garage.IsFull)
            {
                Write("Garage is full. Cannot park new vehicle.", UIMessageType.Error);
                return;
            }

            var menu = new List<IMenuAction<IVehicle>>()
            {
                new MenuAction<IVehicle>("1", "Airplane", () => new Airplane(Read<string>(Validators.StringNotEmpty, "Enter registration number: "))
                {
                    Model             = Read<string>(Validators.StringNotEmpty, "Enter model: "),
                    Year              = Read<int>(Validators.Year, "Enter year: "),
                    Color             = Read<string>(Validators.StringNotEmpty, "Enter color: "),
                    Weight            = Read<double>(Validators.DoublePositive, "Enter weight (kg): "),
                    Length            = Read<double>(Validators.DoublePositive, "Enter length (m): "),
                    Width             = Read<double>(Validators.DoublePositive, "Enter width (m): "),
                    Height            = Read<double>(Validators.DoublePositive, "Enter height (m): "),
                    PassengerCapacity = Read<int>(Validators.IntPositive, "Enter passenger capacity: "),
                    NumberOfEngines   = Read<int>(Validators.IntPositive, "Enter number of engines: "),
                    EngineType        = Read<AirplaneEngineType>(Validators.Enumeration, $"Enter engine type ({UIExtentions.GetEnumOptions<AirplaneEngineType>()}): "),
                    MaxAltitude       = Read<int>(Validators.IntPositive, "Enter max altitude (m): ")
                }),
                new MenuAction<IVehicle>("2", "Boat", () => new Boat(Read<string>(Validators.StringNotEmpty, "Enter registration number: "))
                {
                    Model             = Read<string>(Validators.StringNotEmpty, "Enter model: "),
                    Year              = Read<int>(Validators.Year, "Enter year: "),
                    Color             = Read<string>(Validators.StringNotEmpty, "Enter color: "),
                    Weight            = Read<double>(Validators.DoublePositive, "Enter weight (kg): "),
                    Length            = Read<double>(Validators.DoublePositive, "Enter length (m): "),
                    Width             = Read<double>(Validators.DoublePositive, "Enter width (m): "),
                    Height            = Read<double>(Validators.DoublePositive, "Enter height (m): "),
                    PassengerCapacity = Read<int>(Validators.IntPositive, "Enter passenger capacity: "),
                    MaxSpeed          = Read<int>(Validators.IntPositive, "Enter max speed (km/h): "),
                    HasEngine         = Read<bool>(Validators.Bool, "Does the boat have an engine (True, False): "),
                    HasCabin          = Read<bool>(Validators.Bool, "Does the boat have a cabin (True, False): ")
                }),
                new MenuAction<IVehicle>("3", "Bus", () => new Bus(Read<string>(Validators.StringNotEmpty, "Enter registration number: "))
                {
                    Model             = Read<string>(Validators.StringNotEmpty, "Enter model: "),
                    Year              = Read<int>(Validators.Year, "Enter year: "),
                    Color             = Read<string>(Validators.StringNotEmpty, "Enter color: "),
                    Weight            = Read<double>(Validators.DoublePositive, "Enter weight (kg): "),
                    Length            = Read<double>(Validators.DoublePositive, "Enter length (m): "),
                    Width             = Read<double>(Validators.DoublePositive, "Enter width (m): "),
                    Height            = Read<double>(Validators.DoublePositive, "Enter height (m): "),
                    PassengerCapacity = Read<int>(Validators.IntPositive, "Enter passenger capacity: "),
                    HasWiFi           = Read<bool>(Validators.Bool, "Does the bus have WiFi (True, False): "),
                    HasRestroom       = Read<bool>(Validators.Bool, "Does the bus have a restroom (True, False): "),
                    NumberOfWheels    = Read<int>(Validators.IntPositive, "Enter number of wheels: ")
                }),
                new MenuAction<IVehicle>("4", "Car", () => new Car(Read<string>(Validators.StringNotEmpty, "Enter registration number: "))
                {
                    Model             = Read<string>(Validators.StringNotEmpty, "Enter model: "),
                    Year              = Read<int>(Validators.Year, "Enter year: "),
                    Color             = Read<string>(Validators.StringNotEmpty, "Enter color: "),
                    Weight            = Read<double>(Validators.DoublePositive, "Enter weight (kg): "),
                    Length            = Read<double>(Validators.DoublePositive, "Enter length (m): "),
                    Width             = Read<double>(Validators.DoublePositive, "Enter width (m): "),
                    Height            = Read<double>(Validators.DoublePositive, "Enter height (m): "),
                    PassengerCapacity = Read<int>(Validators.IntPositive, "Enter passenger capacity: "),
                    NumberOfDoors     = Read<int>(Validators.IntPositive, "Enter number of doors: "),
                    TrunkCapacity     = Read<double>(Validators.DoublePositive, "Enter trunk capacity (L): "),
                    FuelType          = Read<CarFuelType>(Validators.Enumeration, $"Enter fuel type ({UIExtentions.GetEnumOptions<CarFuelType>()}): ")
                }),
                new MenuAction<IVehicle>("5", "Motorcycle", () => new Motorcycle(Read<string>(Validators.StringNotEmpty, "Enter registration number: "))
                {
                    Model             = Read<string>(Validators.StringNotEmpty, "Enter model: "),
                    Year              = Read<int>(Validators.Year, "Enter year: "),
                    Color             = Read<string>(Validators.StringNotEmpty, "Enter color: "),
                    Weight            = Read<double>(Validators.DoublePositive, "Enter weight (kg): "),
                    Length            = Read<double>(Validators.DoublePositive, "Enter length (m): "),
                    Width             = Read<double>(Validators.DoublePositive, "Enter width (m): "),
                    Height            = Read<double>(Validators.DoublePositive, "Enter height (m): "),
                    PassengerCapacity = Read<int>(Validators.IntPositive, "Enter passenger capacity: "),
                    EngineVolume      = Read<double>(Validators.DoublePositive, "Enter engine volume: "),
                    HasSidecar        = Read<bool>(Validators.Bool, "Does the motorcycle have a sidecar (True, False): "),
                    IsOffRoad         = Read<bool>(Validators.Bool, "Is the motorcycle off-road (True, False): ")
                })
            };

            menu.Print(this);

            var action = Read(
                (string key, out IMenuAction<IVehicle> result) => (result = menu.FirstOrDefault(a => a.Key == key)!) != null,
                "Select vehicle type to park: ");

            var vehicle = action.InvokeWithResult();

            try
            {
                _garageHandler.ParkVehicle(vehicle);
                Write($"Vehicle parked", UIMessageType.Success);
            }
            catch (Exception ex)
            {
                Write($"Error creating vehicle: {ex.Message}", UIMessageType.Error);
            }
        }

        private void RemoveVehicleAction()
        {
            var registration = Read<string>(Validators.StringNotEmpty, "Enter registration number to remove: ");
            
            try
            {
                _garageHandler.RemoveVehicle(registration);
                Write($"Vehicle was removed from garage.", UIMessageType.Success);
            }
            catch (Exception ex)
            {
                Write($"Error removing vehicle: {ex.Message}", UIMessageType.Error);
            }
        }

        private void SearchAction()
        {
            if (_garageHandler.Garage.IsEmpty)
            {
                Write("Garage is empty. Cannot search.", UIMessageType.Error);
                return;
            }

            IEnumerable<IVehicle> result = _garageHandler.Garage;
            bool isComplete = false;
            var filters = new List<string>();
            var menu = new List<IMenuAction<IEnumerable<IVehicle>>>()
            {
                new MenuAction<IEnumerable<IVehicle>>("1", $"Add filter by Vehicle type ({UIExtentions.GetEnumOptions<VehicleType>()})", () =>
                {
                    var request = Read<VehicleType>(Validators.Enumeration, "Enter vehicle type: ");
                    filters.Add("Vehicle type: " + request);

                    var type = request switch
                    {
                        VehicleType.Airplane => typeof(Airplane),
                        VehicleType.Boat => typeof(Boat),
                        VehicleType.Bus => typeof(Bus),
                        VehicleType.Car => typeof(Car),
                        VehicleType.Motorcycle => typeof(Motorcycle),
                        _ => throw new ArgumentException("Invalid vehicle type.")
                    };

                    return _garageHandler.Garage.Where(v => type.IsInstanceOfType(v));
                }),
                new MenuAction<IEnumerable<IVehicle>>("2", "Add filter by Model", () =>
                {
                    var request = Read<string>(Validators.StringNotEmpty, "Enter model to search: ");
                    filters.Add("Model: " + request);
                    return _garageHandler.Garage.Where(v
                        => v.Model != null &&
                           v.Model.Contains(request, StringComparison.OrdinalIgnoreCase));
                }),
                new MenuAction<IEnumerable<IVehicle>>("3", "Add filter by Year", () =>
                {
                    var request = Read<int>(Validators.IntPositive, "Enter year to search: ");
                    filters.Add("Year: " + request);
                    return _garageHandler.Garage.Where(v
                        => v.Year != null &&
                           v.Year.Equals(request));
                }),
                new MenuAction<IEnumerable<IVehicle>>("4", "Add filter by Color", () =>
                {
                    var request = Read<string>(Validators.StringNotEmpty, "Enter color to search: ");
                    filters.Add("Color: " + request);
                    return _garageHandler.Garage.Where(v
                        => v.Color != null && v.Color.Contains(request, StringComparison.OrdinalIgnoreCase));
                }),
                new MenuAction<IEnumerable<IVehicle>>("5", "Add filter by Weight", () =>
                {
                    var request = Read<double>(Validators.DoublePositive, "Enter weight to search (kg): ");
                    filters.Add("Weight: " + request);
                    return _garageHandler.Garage.Where(v
                        => v.Weight != null &&
                           v.Weight.Equals(request));
                }),
                new MenuAction<IEnumerable<IVehicle>>("6", "Add filter by Length", () =>
                {
                    var request = Read<double>(Validators.DoublePositive, "Enter length to search (m): ");
                    filters.Add("Length: " + request);
                    return _garageHandler.Garage.Where(v
                        => v.Length != null &&
                           v.Length.Equals(request));
                }),
                new MenuAction<IEnumerable<IVehicle>>("7", "Add filter by Height", () =>
                {
                    var request = Read<double>(Validators.DoublePositive, "Enter height to search (m): ");
                    filters.Add("Height: " + request);
                    return _garageHandler.Garage.Where(v
                        => v.Height != null &&
                           v.Height.Equals(request));
                }),
                new MenuAction<IEnumerable<IVehicle>>("8", "Add filter by Passenger Capacity", () =>
                {
                    var request = Read<int>(Validators.IntPositive, "Enter passenger capacity to search: ");
                    filters.Add("Passenger Capacity: " + request);
                    return _garageHandler.Garage.Where(v
                        => v.PassengerCapacity != null &&
                           v.PassengerCapacity.Equals(request));
                }),
                new MenuAction<IEnumerable<IVehicle>>("9", "Show current result", () =>
                {
                    if (filters.Count == 0)
                    {
                        Write("No filters applied yet.", UIMessageType.Error);
                        return null!;
                    }

                    Write($"Current search result: {result.Count()} vehicles found " +
                          $"that satisfy the following filters: {string.Join(", ", filters)}", UIMessageType.Title);

                    foreach (var current in result)
                    {
                        Write(current.GetSummary());
                    }

                    return null!;
                }),
                new MenuAction<IEnumerable<IVehicle>>("0", "Exit", () =>
                {
                    isComplete = true;
                    return null!;
                })
            };

            menu.Print(this);

            while (!isComplete)
            {
                var action = Read((string key, out IMenuAction<IEnumerable<IVehicle>> result) =>
                    (result = menu.FirstOrDefault(a => a.Key == key)!) != null,
                    "Select filter to apply: ");

                var res = action.InvokeWithResult();

                // received clarification
                if (res is IEnumerable<IVehicle>)
                {
                    result = res.Intersect(result);
                    Write("Filter applied!", UIMessageType.Success);
                }
            }
        }

        public void Write(string message, UIMessageType messageType = UIMessageType.Regular, bool isInline = false)
        {
            Console.ForegroundColor = messageType switch
            {
                UIMessageType.Request => ConsoleColor.Cyan,
                UIMessageType.Menu => ConsoleColor.Yellow,
                UIMessageType.Error => ConsoleColor.Red,
                UIMessageType.Success => ConsoleColor.Green,
                UIMessageType.Title => ConsoleColor.Magenta,
                _ => ConsoleColor.White
            };

            if (isInline)
            {
                Console.Write(message);
            }
            else
            {
                Console.WriteLine(message);
            }

            Console.ResetColor();
        }

        private T Read<T>(Validators.TryValidateDelegate<T> validator, string requestMessage)
        {
            while (true)
            {
                Write(requestMessage, UIMessageType.Request, true);

                string input = Console.ReadLine() ?? string.Empty;

                if (validator(input, out T value))
                {
                    return value;
                }

                Write("Invalid input. Try again.", UIMessageType.Error);
            }
        }
    }
}
