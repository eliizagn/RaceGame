using RaceGame.Cars.VehicleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceGame.Cars.Models
{
    public class MagicCarpet : AirTransport
    {
        public override string Type => "Magic Carpet";
        public override int Speed(int speed)
        {
            return 106;
        }
        public override int AccelerationCoefficient(int distance) => 2;
    }
}