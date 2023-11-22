using RaceGame.Cars.VehicleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceGame.Cars.Models
{

    public class WitchBroom : AirTransport
    {
        public override string Type => "Witch's Broom";
        public override int Speed(int speed)
        {
            return 125;
        }
        public override int AccelerationCoefficient(int distance) => 1;
    }
}