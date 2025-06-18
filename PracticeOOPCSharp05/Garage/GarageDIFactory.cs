using PracticeOOPCSharp05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOPCSharp05.Garage
{
    internal interface IGarageFactory
    {
        IGarage<IVehicle> CreateGarage(int capacity);
    }

    internal class GarageFactory : IGarageFactory
    {
        public IGarage<IVehicle> CreateGarage(int capacity)
        {
            return new Garage<IVehicle>(capacity);
        }
    }
}
