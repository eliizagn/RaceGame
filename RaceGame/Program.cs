// See https://aka.ms/new-console-template for more information
using RaceGame.RaceSimulation;


    Race race = new Race();

    race.ChooseDistance(); // Пользователь выбирает дистанцию

    race.ChooseRaceType(); // Пользователь выбирает тип гонки
    race.RegisterTransport(race.Type);
    


