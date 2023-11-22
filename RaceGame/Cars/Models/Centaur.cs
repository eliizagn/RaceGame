using RaceGame.Cars.VehicleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceGame.Cars.Models
{
    public class Centaur : GroundTransport
    {
        public override string Type => "Centaur";
        public override int Speed(int distance)
        {
            // Пример формулы (квадратичная зависимость)
            return 200 - 2 * distance;
        }
        public override int TimeToRest => 2;
        public override int RestDuration(int stopNumber) => stopNumber * 1;
    }
}
