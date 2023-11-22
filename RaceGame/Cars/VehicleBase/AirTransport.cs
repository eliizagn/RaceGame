using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceGame.Cars.VehicleBase
{
    public abstract class AirTransport : Transport
    {
        public abstract int AccelerationCoefficient(int distance);
    }
}
