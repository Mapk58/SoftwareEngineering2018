using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEHometaskOneTaskTwo
{
    public class NextTour
    {
        public static void goToTheNextTour(string tournamentName, string winnerName)
        {
            var path = Files.pathWithTournaments + tournamentName;
            if (File.Exists(path))
            {
                var tournamentInfo = Files.getFile(tournamentName);
                var updatedTournamentInfo = promotePlayer(winnerName, tournamentInfo);
                if (updatedTournamentInfo != null)
                {
                    updatedTournamentInfo = tryToPromoteWinnersToNextTour(updatedTournamentInfo);
                    if (updatedTournamentInfo.Count == 1)
                        Console.WriteLine("В турнире " + tournamentName + " победил " + winnerName);
                    Files.saveFile(tournamentName, updatedTournamentInfo);
                }
                else
                {
                    Console.WriteLine("Ошибка. Проверьте правильность введенного имени.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка. Несуществующий турнир");
            }

        }
        public static List<List<string>> promotePlayer(string winnerName, List<List<string>> tournamentInfo)
        {
            int pairWithWinnerIndex = 0;
            var arrayWithWinnerName = new List<string>();
            arrayWithWinnerName.Add(winnerName);
            bool flag = false;
            foreach (List<string> currentPair in tournamentInfo)
            {
                if (currentPair.Count == 2 && currentPair.Contains(winnerName))
                {
                    flag = true;
                    pairWithWinnerIndex = tournamentInfo.IndexOf(currentPair);
                }
            }

            if (flag)
            {
                tournamentInfo[pairWithWinnerIndex] = arrayWithWinnerName;
                return tournamentInfo;
            }
            else
                return null;
        }
        public static List<List<string>> tryToPromoteWinnersToNextTour(List<List<string>> tournamentInfo)
        {
            int readyForNextTour = 0;
            foreach (List<string> currantPair in tournamentInfo)
            {
                if (currantPair.Count == 1)
                    readyForNextTour++;
            }

            return (readyForNextTour == tournamentInfo.Count) ?
                formRandomPairs(
                    tournamentInfo.Aggregate(
                        (accumulator, currentValue) => accumulator.Concat(currentValue).ToList())) :
                tournamentInfo;
        }

        public static List<List<string>> formRandomPairs(List<string> arrayWithPlayers)
        {
            int playersCount = arrayWithPlayers.Count;
            int pairsCount = playersCount / 2;
            var random = new Random();
            int randomNumber = random.Next(playersCount);
            var formedPairs = new List<List<string>>();
            var onePair = new List<string>();
            for (int i = 0; i < pairsCount; ++i)
            {
                onePair.Add(arrayWithPlayers[randomNumber]);
                arrayWithPlayers.RemoveAt(randomNumber);

                playersCount = arrayWithPlayers.Count;
                randomNumber = random.Next(playersCount);

                onePair.Add(arrayWithPlayers[randomNumber]);
                arrayWithPlayers.RemoveAt(randomNumber);

                playersCount = arrayWithPlayers.Count;
                randomNumber = random.Next(playersCount);

                formedPairs.Add(onePair.ToList());
                onePair.Clear();
            }
            return formedPairs;
        }
    }
}
