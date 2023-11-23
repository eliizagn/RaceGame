using RaceGame.Cars.VehicleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceGame.Cars.Models
{
    public class Hoverboard : GroundTransport
    {
        public override string Type => "Hoverboard";
        public override int Speed(int distance)
        {
            return 130;
        }
        public override int TimeToRest => 3;
        public override int RestDuration(int stopNumber) => stopNumber * 2;
    }
}
