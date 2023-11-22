using RaceGame.Cars.VehicleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceGame.Cars.Models
{
    public class WalkingBoots : GroundTransport
    {
        public override string Type => "Walking Boots";
        public override int TimeToRest => 3;
        public override int RestDuration(int stopNumber) => stopNumber * 4;
        public override int Speed(int speed)
        {
            return 100;
        }
    }
}