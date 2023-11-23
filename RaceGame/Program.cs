namespace RaceGame.RaceSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание экземпляра класса Race
            Race race = new Race();

            // Выбор дистанции
            race.ChooseDistance();

            // Выбор типа гонки
            race.ChooseRaceType();

            // Регистрация участников
            race.RegisterTransport(race.Type);

            // Запуск гонки
            race.RunRace();
          
        }
    }
}