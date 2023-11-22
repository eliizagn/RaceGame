using RaceGame.Cars.VehicleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceGame.Cars.Models
{
    public class ChickenLegsHut : GroundTransport
    {
        public override string Type => "Chicken Legs Hut";
        public override int Speed(int distance)
        {
            return 120 - 4 * distance;
        }
        public override int TimeToRest => 5;
        public override int RestDuration(int stopNumber) => stopNumber * 4;
    }
}