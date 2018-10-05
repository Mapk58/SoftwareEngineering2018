using SEHometaskOneTaskTwo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEHomeTaskOneTaskTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            getNewCommand();
        }
        private static void getNewCommand()
        {
            Console.WriteLine("Для создания турина введите \"create\". \n" +
                "Для продвижения по турниру введите \"next\". \n" +
                "Для выхода введите \"exit\" \n");
            string command = Console.ReadLine();
            commandManager(command);
        }
        public static void commandManager(string command)
        {
            switch (command)
            {
                case "create":
                    Console.WriteLine("Введите название создаваемого турнира");
                    string creatingTournamentName = Console.ReadLine();
                    Console.WriteLine("Введите имена участников через пробел");
                    var arrayWithPlayers = Console.ReadLine().Split(' ').ToList();
                    CreateTournament.createTournament(creatingTournamentName, arrayWithPlayers);
                    getNewCommand();
                    break;
                case "next":
                    Console.WriteLine("Введите название турнира");
                    string updatingTournamentName = Console.ReadLine();
                    Console.WriteLine("Введите имя победителя");
                    string winnerName = Console.ReadLine();
                    NextTour.goToTheNextTour(updatingTournamentName, winnerName);
                    getNewCommand();
                    break;
                case "exit":
                    break;
                default:
                    Console.WriteLine("Ошибка. Несуществующая программа");
                    break;
            }
        }


    }





}
