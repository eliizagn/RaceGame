using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceGame.Cars.VehicleBase
{
    public abstract class GroundTransport : Transport
    {
        public abstract int TimeToRest { get; }
        public abstract int RestDuration(int stopNumber);

    }
}
