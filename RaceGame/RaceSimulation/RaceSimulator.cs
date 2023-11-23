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
        private int CalculateRaceTime(Transport transport)
        {
            if (transport is GroundTransport groundTransport)
            {
                int totalTime = 0;
                for (int i = 0; i < StopNumber; i++)
                {
                    totalTime += groundTransport.Speed(raceDistance);
                    totalTime += groundTransport.RestDuration(i + 1);
                }
                return totalTime;
            }
            else if (transport is AirTransport airTransport)
            {
                int acceleration = airTransport.AccelerationCoefficient(raceDistance);
                int totalTime = raceDistance / acceleration;
                return totalTime;
            }
            return -1; // Handle other types of transport if needed
        }
        public void RunRace()
        {
            ChooseRaceType();
            RegisterTransport(Type);

            while (true)
            {
                ChooseDistance();
                Console.WriteLine("Race is starting!");

                switch (Type)
                {
                    case RaceType.GroundOnly:
                        RunGroundRace();
                        DetermineWinner(groundParticipants);
                        break;
                    case RaceType.AirOnly:
                        RunAirRace();
                        DetermineWinner(airParticipants);
                        break;
                    case RaceType.MixType:
                        RunMixRace();
                        DetermineWinner(participants);
                        break;
                    default:
                        Console.WriteLine("Invalid race type");
                        break;
                }

                Console.WriteLine("Do you want to race again? (yes/no)");
                string playAgain = Console.ReadLine().ToLower();
                if (playAgain != "yes")
                {
                    break;
                }

            }
        }
        private void RunGroundRace()
        {
           
            foreach (var groundTransport in groundParticipants)
            {
                int totalDistanceCovered = 0;
                int totalRaceTime = 0;

                while (totalDistanceCovered < raceDistance)
                {
                    int remainingDistance = raceDistance - totalDistanceCovered;
                    int segmentDistance = Math.Min(remainingDistance, 10); 

                    int segmentTime = groundTransport.Speed(segmentDistance);
                    totalRaceTime += segmentTime;

                    totalDistanceCovered += segmentDistance;

                    if (totalDistanceCovered < raceDistance)
                    {
                        totalRaceTime += groundTransport.RestDuration(StopNumber);
                        StopNumber++;
                    }
                }
            }
          
        }
        private void RunMixRace()
        {

            // Ground transports race segment
            foreach (var groundTransport in groundParticipants)
            {
                int totalDistanceCovered = 0;
                int totalRaceTime = 0;

                while (totalDistanceCovered < raceDistance)
                {
                    int remainingDistance = raceDistance - totalDistanceCovered;
                    int segmentDistance = Math.Min(remainingDistance, 10); // Assume each segment distance is 10 units

                    int segmentTime = groundTransport.Speed(segmentDistance);
                    totalRaceTime += segmentTime;

                    totalDistanceCovered += segmentDistance;

                    if (totalDistanceCovered < raceDistance)
                    {
                        totalRaceTime += groundTransport.RestDuration(StopNumber);
                        StopNumber++;
                    }
                }
            }

            // Air transports race segment
            foreach (var airTransport in airParticipants)
            {
                int acceleration = airTransport.AccelerationCoefficient(raceDistance);
                int totalRaceTime = raceDistance / acceleration;
            }
         
        }
        private void RunAirRace()
        {
            
            foreach (var airTransport in airParticipants)
            {
                int acceleration = airTransport.AccelerationCoefficient(raceDistance);
                int totalRaceTime = raceDistance / acceleration;
            }
   
        }

        private void DetermineWinner<T>(List<T> participants) where T : Transport
        {
            Transport winner = null;
            int minTime = int.MaxValue;

            foreach (var participant in participants)
            {
                int raceTime = CalculateRaceTime(participant);
                if (raceTime < minTime)
                {
                    minTime = raceTime;
                    winner = participant;
                }
            }

            if (winner != null)
            {
                Console.WriteLine($"The winner is {winner.Type}!");
            }
            else
            {
                Console.WriteLine("No winner found");
            }
        }
    }
}