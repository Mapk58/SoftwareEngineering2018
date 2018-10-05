using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEHometaskOneTaskTwo
{
    class Files
    {
        public const string pathWithTournaments = @"C:\Users\Давид\source\repos\SEHometaskOneTaskTwo\tournaments\";

        public static List<List<string>> getFile(string tournamentName)
        {
            string path = Files.pathWithTournaments + tournamentName;
            var tournamentInformation = File.ReadAllLines(path)
                .Select(currentString => currentString.Split(',').ToList())
                .ToList();
            return tournamentInformation;
        }
        public static void saveFile(string tournamentName, List<List<string>> arrayWithPlayers)
        {
            string path = Files.pathWithTournaments + tournamentName; 
            var arrayForSave = arrayWithPlayers
                .Select(currentPare =>
                currentPare.Aggregate((string accumulator, string currentValue) =>
                String.Concat(accumulator, ",", currentValue)))
                .ToArray();
            
            File.WriteAllLines(path, arrayForSave);
            
        }
    }
}
