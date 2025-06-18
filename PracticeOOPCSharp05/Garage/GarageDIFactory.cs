using PracticeOOPCSharp05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOPCSharp05.Garage
{
    internal interface IGarageDIFactory
    {
        IGarage<IVehicle> CreateGarage(int capacity);
    }

    internal class GarageDIFactory : IGarageDIFactory
    {
        public IGarage<IVehicle> CreateGarage(int capacity)
        {
            return new Garage<IVehicle>(capacity);
        }
    }
}
