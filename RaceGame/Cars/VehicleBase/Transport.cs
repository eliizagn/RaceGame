using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceGame.Cars.VehicleBase
{
    public abstract class Transport
    {
        public abstract int Speed(int distance);
        public abstract string Type { get; }
    }
}
