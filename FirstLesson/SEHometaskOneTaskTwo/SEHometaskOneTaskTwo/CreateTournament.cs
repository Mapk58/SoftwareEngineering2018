using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEHometaskOneTaskTwo
{
    class CreateTournament
    {
        public static void createTournament(string tournamentName, List<string> arrayWithPlayers)
        {
            var formedPairs = NextTour.formRandomPairs(arrayWithPlayers);
            Files.saveFile(tournamentName, formedPairs);
        }
    }
}
