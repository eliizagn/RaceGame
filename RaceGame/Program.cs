namespace RaceGame.RaceSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Race race = new Race();

            Console.WriteLine("Welcome to the Race Game!");

            race.RunRace();

            race.ChooseDistance();
            race.ChooseRaceType();
            race.RegisterTransport(race.Type);
           
        }
    }
}