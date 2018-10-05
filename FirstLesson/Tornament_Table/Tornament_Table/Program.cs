using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tournament_Table
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            string FilePath = "/Users/odmen/Projects/Tornament_Table/";

            Console.WriteLine("Enter the name of the tournament and its participants via space..");

            var startInfo = Console.ReadLine();

            List<string> NameAndMembers = startInfo.Split(' ').ToList();

            var extent = ChekforExtentOfTwo(NameAndMembers);

            if (extent > 0)
            {
                string TournamentName = $"{NameAndMembers[0]}.txt";
                NameAndMembers.RemoveAt(0);

                NameAndMembers = ShufflingOfTable(NameAndMembers);
                InputInFile(FilePath, TournamentName, NameAndMembers);

                for (int i = 0; i < extent; i++)
                {
                    DisplayPairs(NameAndMembers);
                    WhoWonAsk(NameAndMembers);
                }
                Console.WriteLine($"And Winner is {NameAndMembers[0]}!!!");
            }
        }

        static double ChekforExtentOfTwo(List<string> NameAndMembers)
        {
            var Extent = Math.Log(NameAndMembers.Count - 1, 2);
            if (Extent == Math.Truncate(Extent))
                return Extent;
            else
            {
                Console.WriteLine("The amount of players should be extent of 2!!");
                return 0;
            }
        }



        static void InputInFile(string FilePath, string TournamentName, List<string> NameAndMembers)
        {
            if (NameAndMembers.Count >= 2)
            {
                File.WriteAllLines($"{FilePath}{TournamentName}", NameAndMembers);

            }
            else Console.WriteLine("An odd number of players, try again..");
        }

        public static List<string> ShufflingOfTable(List<string> NameAndMembers)
        {
            Random rand = new Random();
            var result = NameAndMembers.OrderBy(item => rand.Next()).ToList();
            return result;
        }

        static void DisplayPairs(List<string> NameAndMembers)
        {
            int restOfPlayers = NameAndMembers.Count;

            if (restOfPlayers == 4)
                Console.WriteLine("SEMI-FINAL!!");
            else if (restOfPlayers == 2)
                Console.WriteLine("FINAL!!!!");

            for (int i = 0; i < restOfPlayers; i += 2)
            {
                Console.WriteLine((i / 2 + 1) + " Pair is:");

                Console.WriteLine(NameAndMembers[i] + "\n" + NameAndMembers[i + 1] + "\n");
            }
        }

        static void WhoWonAsk(List<string> NameAndMembers)
        {
            int count = 0;
            bool _true = true;

            for (int i = 0; i < NameAndMembers.Count / 2; i++)
            {
                while (_true)
                {
                    Console.WriteLine($"Who won in {i + 1} pair?..");
                    var winner = Console.ReadLine();

                    if (NameAndMembers.Contains(winner))
                    {
                        NameAndMembers[i] = winner;
                        _true = false;
                    }

                    else Console.WriteLine("That player not found, try again..");
                }
                count++;
                _true = true;
            }
            NameAndMembers.RemoveRange(count, (NameAndMembers.Count - count));
            //Volley Marat Gay Holle joki harrold genry Igor LEON
        }
    }
}
