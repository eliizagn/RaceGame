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
        private readonly List<Transport> participants = new List<Transport>();
        public RaceType Type { get; private set; }
        private readonly Dictionary<RaceType, List<Transport>> raceParticipants = new Dictionary<RaceType, List<Transport>>();

        public void ChooseDistance()
        {
            Console.WriteLine("Choose distance");
            int raceDistance = int.Parse(Console.ReadLine());
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
                    SetRaceType(RaceType.GroundOnly);
                    break;
                case 2:
                    SetRaceType(RaceType.AirOnly);
                   
                    break;
                case 3:
                    SetRaceType(RaceType.MixType);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
        private void SetRaceType(RaceType raceType)
{
    Type = raceType; // Поле Type вашего класса Race, куда сохраняется выбранный тип гонки
}

        public void RegisterTransportForRace(Transport transport, RaceType raceType)
        {
            switch (raceType)
            {
                case RaceType.GroundOnly:
                    if (transport is GroundTransport)
                        RegisterForGroundRace((GroundTransport)transport);
                    else
                        Console.WriteLine("Invalid transport type for Ground race.");
                    break;
                case RaceType.AirOnly:
                    if (transport is AirTransport)
                        RegisterForAirRace((AirTransport)transport);
                    else
                        Console.WriteLine("Invalid transport type for Air race.");
                    break;
                case RaceType.MixType:
                    RegisterForMixRace(transport);
                    break;
                default:
                    Console.WriteLine("Invalid race type.");
                    break;
            }
        }

        private void RegisterForGroundRace(GroundTransport groundTransport)
        {
            Console.WriteLine($"Registered {groundTransport.Type} for Ground race.");
            AddToRaceParticipants(RaceType.GroundOnly, groundTransport);
        }

        private void RegisterForAirRace(AirTransport airTransport)
        {
            Console.WriteLine($"Registered {airTransport.Type} for Air race.");
            AddToRaceParticipants(RaceType.AirOnly, airTransport);
        }

        private void RegisterForMixRace(Transport transport)
        {
            Console.WriteLine($"Registered {transport.Type} for Mix race.");
            AddToRaceParticipants(RaceType.MixType, transport);
        }

        private void AddToRaceParticipants(RaceType raceType, Transport transport)
        {
            if (!raceParticipants.ContainsKey(raceType))
            {
                raceParticipants[raceType] = new List<Transport>();
            }
            raceParticipants[raceType].Add(transport);
        }

        public void DisplayRaceParticipants()
        {
            foreach (var kvp in raceParticipants)
            {
                Console.WriteLine($"Race Type: {kvp.Key}");
                Console.WriteLine("Participants:");
                foreach (var transport in kvp.Value)
                {
                    Console.WriteLine(transport.Type);
                }
                Console.WriteLine();
            }
        }
        static void RegisterVehiclesforMixtype(Race raceSimulator)
        {
            Console.WriteLine("Register vehicles for the race:");

            while (true)
            {
                Console.WriteLine("Choose vehicle type to register (or 'exit' to finish registration):");
                Console.WriteLine("1. Centaur\n2. Chicken Legs Hut\n3. Flying Ship\n4. Hoverboard\n5. Magic Carpet\n6. Pumpkin Carriage\n7. Racing Shoes\n8. Walkin Boots\n9. Witch Broom");


                string choice = Console.ReadLine();

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("\nGame Over.");
                    break;
                }


                switch (choice)
                {
                    case "1":
                        raceSimulator.RegisterForMixRace(new Centaur());
                        break;
                    case "2":
                        raceSimulator.RegisterForMixRace(new ChickenLegsHut());
                        break;
                    case "3":
                        raceSimulator.RegisterForMixRace(new FlyingShip());
                        break;
                    case "4":
                        raceSimulator.RegisterForMixRace(new Hoverboard());
                        break;
                    case "5":
                        raceSimulator.RegisterForMixRace(new MagicCarpet());
                        break;
                    case "6":
                        raceSimulator.RegisterForMixRace(new PumpkinCarriage());
                        break;
                    case "7":
                        raceSimulator.RegisterForMixRace(new RacingShoes());
                        break;
                    case "8":
                        raceSimulator.RegisterForMixRace(new WalkingBoots());
                        break;
                    case "9":
                        raceSimulator.RegisterForMixRace(new WitchBroom());
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            static void RegisterVehiclesforAirType(Race raceSimulator)
            {
                Console.WriteLine("Register vehicles for the race:");

                while (true)
                {
                    Console.WriteLine("Choose vehicle type to register (or 'exit' to finish registration):");
                    Console.WriteLine("1. Flying Ship\n2. Magic Carpet\n 3. Witch Broom");


                    string choice = Console.ReadLine();

                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("\nGame Over.");
                        break;
                    }


                    switch (choice)
                    {
                        case "1":
                            raceSimulator.RegisterForMixRace(new FlyingShip());
                            break;
                        case "2":
                            raceSimulator.RegisterForMixRace(new MagicCarpet());
                            break;
                        case "3":
                            raceSimulator.RegisterForMixRace(new WitchBroom());
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }

            }
            static void RegisterVehiclesforMixtype(Race raceSimulator)
            {
                Console.WriteLine("Register vehicles for the race:");

                while (true)
                {
                    Console.WriteLine("Choose vehicle type to register (or 'exit' to finish registration):");
                    Console.WriteLine("1. Centaur\n2. Chicken Legs Hut\n3. Hoverboard\n 4.Pumpkin Carriage\n 5. Racing Shoes\n 6. Walkin Boots\n");


                    string choice = Console.ReadLine();

                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("\nGame Over.");
                        break;
                    }


                    switch (choice)
                    {
                        case "1":
                            raceSimulator.RegisterForMixRace(new Centaur());
                            break;
                        case "2":
                            raceSimulator.RegisterForMixRace(new ChickenLegsHut());
                            break;
                        case "3":
                            raceSimulator.RegisterForMixRace(new Hoverboard());
                            break;
                        case "4":
                            raceSimulator.RegisterForMixRace(new PumpkinCarriage());
                            break;
                        case "5":
                            raceSimulator.RegisterForMixRace(new RacingShoes());
                            break;
                        case "6":
                            raceSimulator.RegisterForMixRace(new WalkingBoots());
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
            }
            }

    }
}

  
