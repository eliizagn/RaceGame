using RaceGame.Cars.VehicleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceGame.Cars.Models
{
    public class PumpkinCarriage : GroundTransport
    {
        public override string Type => "Pumpkin Carriage";
        public override int Speed(int distance)
        {
            return 150;
        }
        public override int TimeToRest => 4;
        public override int RestDuration(int stopNumber) => stopNumber * 3;
    }
}