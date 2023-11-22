using RaceGame.Cars.VehicleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceGame.Cars.Models
{
    public class FlyingShip : AirTransport
    {
        public override string Type => "Flying Ship";
        public override int Speed(int speed)
        {
            return 123;
        }
        public override int AccelerationCoefficient(int distance) => 1;
    }
}
