using RaceGame.Cars.VehicleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceGame.Cars.Models
{
    public class RacingShoes : GroundTransport
    {
        public override string Type => "Racing Shoes";
        public override int Speed(int distance)
        {
            //  формула (квадратичная зависимость)
            return 15 + 3 * distance * distance;
        }
        public override int TimeToRest => 2;
        public override int RestDuration(int stopNumber) => stopNumber * 1;
    }

}