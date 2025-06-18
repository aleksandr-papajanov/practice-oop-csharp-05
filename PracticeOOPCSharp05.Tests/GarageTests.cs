using Moq;
using System.Diagnostics.Metrics;
using PracticeOOPCSharp05.Models;

namespace PracticeOOPCSharp05.Tests
{
    public class GarageTests
    {
        private Mock<IVehicle> CreateVehicleMock(string regNumber)
        {
            var mock = new Mock<IVehicle>();
            mock.SetupGet(v => v.RegistrationNumber).Returns(regNumber);
            return mock;
        }

        [Fact]
        public void CreateGarage_WithValidCapacity_ShouldSetCapacity()
        {
            var garage = new Garage<IVehicle>(5);

            Assert.Equal(5, garage.Capacity);
            Assert.Equal(0, garage.Count);
        }

        [Fact]
        public void CreateGarage_WithZeroCapacity_ShouldThrow()
        {
            Assert.Throws<Exception>(() => new Garage<IVehicle>(0));
        }

        [Fact]
        public void ParkVehicle_WhenSpaceAvailable_ShouldIncreaseCount()
        {
            var garage = new Garage<IVehicle>(2);
            var vehicleMock = CreateVehicleMock("ABC123");

            garage.Park(vehicleMock.Object);

            Assert.Equal(1, garage.Count);
            Assert.Equal(vehicleMock.Object, garage.Find("ABC123"));
        }

        [Fact]
        public void ParkVehicle_WhenDuplicateRegistration_ShouldThrow()
        {
            var garage = new Garage<IVehicle>(2);
            var vehicle1 = CreateVehicleMock("ABC123");
            var vehicle2 = CreateVehicleMock("ABC123");

            garage.Park(vehicle1.Object);

            var ex = Assert.Throws<Exception>(() => garage.Park(vehicle2.Object));
            Assert.Contains("already exists", ex.Message);
        }

        [Fact]
        public void ParkVehicle_WhenGarageFull_ShouldThrow()
        {
            var garage = new Garage<IVehicle>(1);
            var v1 = CreateVehicleMock("ABC123");
            var v2 = CreateVehicleMock("000000");

            garage.Park(v1.Object);

            var ex = Assert.Throws<Exception>(() => garage.Park(v2.Object));
            Assert.Contains("Garage is full", ex.Message);
        }

        [Fact]
        public void RemoveVehicle_ShouldDecreaseCount()
        {
            var garage = new Garage<IVehicle>(2);
            var vehicle = CreateVehicleMock("ABC123");

            garage.Park(vehicle.Object);
            garage.Remove("ABC123");

            Assert.Equal(0, garage.Count);
            Assert.Null(garage.Find("ABC123"));
        }

        [Fact]
        public void RemoveVehicle_WhenNotFound_ShouldThrow()
        {
            var garage = new Garage<IVehicle>(2);

            var ex = Assert.Throws<Exception>(() => garage.Remove("ABC123"));
            Assert.Contains("not found", ex.Message);
        }

        [Fact]
        public void Enumerator_ShouldReturnAllParkedVehicles()
        {
            var garage = new Garage<IVehicle>(3);
            var v1 = CreateVehicleMock("A");
            var v2 = CreateVehicleMock("B");

            garage.Park(v1.Object);
            garage.Park(v2.Object);

            var list = garage.ToList();

            Assert.Contains(v1.Object, list);
            Assert.Contains(v2.Object, list);
            Assert.Equal(2, list.Count);
        }
    }
}
