using RaceGame.Cars.VehicleBase;
using RaceGame.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using RaceGame.Cars.Models;

namespace RaceGame.RaceSimulation
{
    public enum RaceType
    {
        GroundOnly,
        AirOnly,
        MixType
    }

    public class Race
    {

        private int raceDistance;
        private readonly List<Transport> participants = new List<Transport>();
        public RaceType Type { get; private set; }
        private readonly Dictionary<RaceType, List<Transport>> raceParticipants = new Dictionary<RaceType, List<Transport>>();
        private readonly List<GroundTransport> groundParticipants = new List<GroundTransport>();
        private readonly List<AirTransport> airParticipants = new List<AirTransport>();
        public int StopNumber { get; private set; }
        public List<GroundTransport> GroundTransports { get; private set; }
        public void ChooseDistance()
        {
            Console.WriteLine("Choose distance");
            raceDistance = int.Parse(Console.ReadLine());
        }
        public void ChooseRaceType()
        {
            Console.WriteLine("Choose race type:");
            Console.WriteLine("1. Ground Only");
            Console.WriteLine("2. Air Only");
            Console.WriteLine("3. Mix Type");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Type = RaceType.GroundOnly;
                    break;
                case 2:
                    Type = RaceType.AirOnly;
                    break;
                case 3:
                    Type = RaceType.MixType;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
        public void RegisterTransport(RaceType raceType)
        {
            switch (raceType)
            {
                case RaceType.GroundOnly:
                    RegisterGroundTransport();
                    break;
                case RaceType.AirOnly:
                    RegisterAirTransport();
                    break;
                case RaceType.MixType:
                    RegisterMixTransport();
                    break;
                default:
                    Console.WriteLine("Invalid race type");
                    break;
            }
        }
        
        private void RegisterGroundTransport()
        {
            Console.WriteLine("Choose ground transport type to register (or 'exit' to finish registration):");

            while (true)
            {
                Console.WriteLine("1. Centaur\n2. Chicken Legs Hut\n3. Hoverboard\n4. Pumpkin Carriage\n5. Racing Shoes\n6. Walkin Boots");
                string selectedGroundTransport = Console.ReadLine();

                if (selectedGroundTransport.ToLower() == "exit")
                {
                    Console.WriteLine("Ground transport registration completed.");
                    break;
                }
                
                GroundTransport groundTransport = null;

                switch (selectedGroundTransport)
                {
                    case "1":
                        groundTransport = new Centaur();
                        break;
                    case "2":
                        groundTransport = new ChickenLegsHut();
                        break;
                    case "3":
                        groundTransport = new Hoverboard();
                        break;
                    case "4":
                        groundTransport = new PumpkinCarriage();
                        break;
                    case "5":
                        groundTransport = new RacingShoes();
                        break;
                    case "6":
                        groundTransport = new WalkingBoots();
                        break;
                    default:
                        Console.WriteLine("Invalid choice for ground transport.");
                        break;
                }

                if (groundTransport != null)
                {
                    groundParticipants.Add(groundTransport);
                    Console.WriteLine($"{groundTransport.Type} registered for the ground race!");
                }
               
            }
        }

        private void RegisterMixTransport()
        {
            Console.WriteLine("Choose transport type to register (or 'exit' to finish registration):");

            while (true)
            {
                Console.WriteLine("1. Centaur\n2. Chicken Legs Hut\n3. Flying Ship\n4. Hoverboard\n5. Magic Carpet\n6. Pumpkin Carriage\n7. Racing Shoes\n8. Walkin Boots\n9. Witch Broom");
                string selectedTransport = Console.ReadLine();

                if (selectedTransport.ToLower() == "exit")
                {
                    Console.WriteLine("Registration completed.");
                    break;
                }

                Transport transport = null;

                switch (selectedTransport)
                {
                    case "1":
                        transport = new Centaur();
                        break;
                    case "2":
                        transport = new ChickenLegsHut();
                        break;
                    case "3":
                        transport = new FlyingShip();
                        break;
                    case "4":
                        transport = new Hoverboard();
                        break;
                    case "5":
                        transport = new MagicCarpet();
                        break;
                    case "6":
                        transport = new PumpkinCarriage();
                        break;
                    case "7":
                        transport = new RacingShoes();
                        break;
                    case "8":
                        transport = new WalkingBoots();
                        break;
                    case "9":
                        transport = new WitchBroom();
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                if (transport != null)
                {
                    participants.Add(transport);
                    Console.WriteLine($"{transport.Type} registered for the race!");
                }
            }
        }
        private void RegisterAirTransport()
        {
            Console.WriteLine("Choose air transport type to register (or 'exit' to finish registration):");

            while (true)
            {
                Console.WriteLine("1. Flying Ship\n2. Magic Carpet\n3. Witch Broom");
                string selectedAirTransport = Console.ReadLine();

                if (selectedAirTransport.ToLower() == "exit")
                {
                    Console.WriteLine("Air transport registration completed.");
                    break;
                }

                AirTransport airTransport = null;

                switch (selectedAirTransport)
                {
                    case "1":
                        airTransport = new FlyingShip();
                        break;
                    case "2":
                        airTransport = new MagicCarpet();
                        break;
                    case "3":
                        airTransport = new WitchBroom();
                        break;
                    default:
                        Console.WriteLine("Invalid choice for air transport.");
                        break;
                }

                if (airTransport != null)
                {
                    airParticipants.Add(airTransport);
                    Console.WriteLine($"{airTransport.Type} registered for the air race!");
                }
            }
        }
        public void RunRace()
        {
            ChooseDistance();
            ChooseRaceType();
            RegisterTransport(Type);
            

            Console.WriteLine("Race is starting!");

            switch (Type)
            {
                case RaceType.GroundOnly:
                    RunGroundRace();
           
                    break;
                case RaceType.AirOnly:
                    RunAirRace();
                
                    break;
                case RaceType.MixType:
                    RunMixRace();
              
                    break;
                default:
                    Console.WriteLine("Invalid race type");
                    break;
            }
           
        }
        private void RunGroundRace()
        {
            var stops = CreateStops(); // Создаем остановки

            foreach (var groundTransport in groundParticipants)
            {
                int distanceCovered = 0;
                int currentStop = 1;

                while (distanceCovered < raceDistance)
                {
                    int remainingDistance = raceDistance - distanceCovered;

                    int speed = groundTransport.Speed(remainingDistance);

                    // Проверяем, нужно ли останавливаться на текущей остановке
                    if (stops.ContainsKey(currentStop))
                    {
                        stops[currentStop].RestAtStop();
                    }

                    distanceCovered += speed;
                    Console.WriteLine($"{groundTransport.Type} moved {speed} this turn. Total distance covered: {distanceCovered} out of {raceDistance}.");

                    currentStop++;
                }
                Console.WriteLine($"{groundTransport.Type} finished the race!");
            }

            DetermineWinner();
        }
        private void RunAirRace()
        {
            var stops = CreateStops(); // Создаем остановки

            foreach (var airTransport in airParticipants)
            {
                int distanceCovered = 0;
                int currentStop = 1;

                while (distanceCovered < raceDistance)
                {
                    int remainingDistance = raceDistance - distanceCovered;

                    // Вычисляем скорость на данном отрезке дистанции с учетом ускорения
                    int acceleration = airTransport.AccelerationCoefficient(remainingDistance);
                    int speed = airTransport.Speed(acceleration);

                    // Проверяем, нужно ли останавливаться на текущей остановке
                    if (stops.ContainsKey(currentStop) && stops[currentStop].ContainsAirTransport(airTransport))
                    {
                        stops[currentStop].RestAtStop();
                    }

                    distanceCovered += speed;
                    Console.WriteLine($"{airTransport.Type} moved {speed} this turn. Total distance covered: {distanceCovered} out of {raceDistance}.");

                    currentStop++;
                }
                Console.WriteLine($"{airTransport.Type} finished the race!");
            }

            DetermineWinner();
        }

        private void RunMixRace()
        {
            var groundStops = CreateStops(); // Создаем остановки для наземных транспортов
            var airStops = CreateStops(); // Создаем остановки для воздушных транспортов

            int groundTransportIndex = 0;
            int airTransportIndex = 0;

            while (groundTransportIndex < groundParticipants.Count || airTransportIndex < airParticipants.Count)
            {
                // Проводим гонку для каждого наземного транспорта
                if (groundTransportIndex < groundParticipants.Count)
                {
                    var groundTransport = groundParticipants[groundTransportIndex];
                    RunRaceForTransport(groundTransport, groundStops);
                    groundTransportIndex++;
                }

                // Проводим гонку для каждого воздушного транспорта
                if (airTransportIndex < airParticipants.Count)
                {
                    var airTransport = airParticipants[airTransportIndex];
                    RunRaceForTransport(airTransport, airStops);
                    airTransportIndex++;
                }
            }

            DetermineWinner();
        }
        private void RunRaceForTransport(Transport transport, Dictionary<int, RaceStop> stops)
        {
            int distanceCovered = 0;
            int currentStop = 1;

            while (distanceCovered < raceDistance)
            {
                int remainingDistance = raceDistance - distanceCovered;
                int speed = transport switch
                {
                    GroundTransport ground => ground.Speed(remainingDistance),
                    AirTransport air => air.Speed(remainingDistance),
                    _ => 0
                };

                if (stops.ContainsKey(currentStop))
                {
                    if (transport is GroundTransport groundTransport && stops[currentStop].RestDurations.ContainsKey(groundTransport))
                    {
                        stops[currentStop].RestAtStop();
                    }
                    else if (transport is AirTransport airTransport && stops[currentStop].ContainsAirTransport(airTransport))
                    {
                        stops[currentStop].RestAtStop();
                    }
                }

                distanceCovered += speed;
                Console.WriteLine($"{transport.Type} moved {speed} this turn. Total distance covered: {distanceCovered} out of {raceDistance}.");

                currentStop++;
            }

            Console.WriteLine($"{transport.Type} finished the race!");
        }

        private Dictionary<int, RaceStop> CreateStops()
        {
            // Create stops considering stop distribution and rest times for different transports
            var stops = new Dictionary<int, RaceStop>();

            // Example stop addition:
            var stop1 = new RaceStop(1);
            stop1.AssignRestDuration(new Centaur(), 2);
            stop1.AssignRestDuration(new RacingShoes(), 1);
            stops.Add(1, stop1);

            var stop2 = new RaceStop(2);
            stop2.AssignRestDuration(new RacingShoes(), 2);
            stop2.AssignRestDuration(new WalkingBoots(), 3);
            stops.Add(2, stop2);

            // ... add other stops

            return stops;
        }
        public class RaceStop
        {
            public int StopNumber { get; }
            public Dictionary<GroundTransport, int> RestDurations { get; }

            public RaceStop(int stopNumber)
            {
                StopNumber = stopNumber;
                RestDurations = new Dictionary<GroundTransport, int>();
            }

            public void AssignRestDuration(GroundTransport transport, int duration)
            {
                RestDurations.Add(transport, duration);
            }

            public void RestAtStop()
            {
                Console.WriteLine($"Stop {StopNumber}: Resting...");

                foreach (var kvp in RestDurations)
                {
                    var transport = kvp.Key;
                    var duration = kvp.Value;

                    Console.WriteLine($"{transport.Type} is resting for {duration} units of time.");
                    // Perform rest for the specific transport here
                }
            }
            public bool ContainsAirTransport(AirTransport transport)
            {
                // Проверка наличия воздушного транспорта на остановке
                return RestDurations.Keys.OfType<AirTransport>().Any(airTransport => airTransport.GetType() == transport.GetType());
            }
        }

        public void DetermineWinner()
        {
            // Находим победителя на основе пройденной дистанции
            Transport winner = null;
            int maxDistance = 0;

            foreach (var participant in participants)
            {
                int distance = participant switch
                {
                    GroundTransport ground => ground.Speed(raceDistance),
                    AirTransport air => air.Speed(raceDistance),
                    _ => 0,
                };

                if (distance > maxDistance)
                {
                    maxDistance = distance;
                    winner = participant;
                }
            }

            if (winner != null)
            {
                Console.WriteLine($"Победитель гонки: {winner.Type}! Пройдено {maxDistance} из {raceDistance}.");
            }
            else
            {
                Console.WriteLine("Победитель не найден.");
            }
        }
    }
}