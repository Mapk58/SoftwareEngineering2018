using System;
using System.IO;

namespace LigaApplies_Homework
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string FileName = "/Users/odmen/Projects/LigaApplies_Homework/Тестирование.csv";
            while (true)
            {
                Console.WriteLine("Enter Command: ");
                string command = Console.ReadLine();

                switch (command)
                {
                    case ("applies"):
                        Console.WriteLine(CountApplies(FileName));
                        break;

                    case ("residence"):
                        CountDormers(FileName);
                        break;

                    case ("statistics"):
                        DisplayStatistics(FileName);
                        break;

                    default:
                        Console.WriteLine("Wrong command, try again...");
                        break;
                }
            }
        }

        private static string[] GetData(string FileName)
        {
            string[] lines = File.ReadAllLines(FileName);
            return lines;
        }

        private static int CountApplies(string FileName)
        {
            return GetData(FileName).Length-1;
        }

        private static void CountDormers(string FileName)
        {
            string[] arrayOfLine = new string[5];
            foreach (var line in GetData(FileName))
            {
                arrayOfLine = line.Split(';');
                if (arrayOfLine[4].Contains("Да"))
                {
                    Console.WriteLine(arrayOfLine[1]);
                }
            }
        }

        private static int[] GradeStatistics(string FileName)
        {
            int[] courseArray = new int[4];
            string[] arrayOfLine = new string[5];
            foreach (var line in GetData(FileName))
            {
                arrayOfLine = line.Split(';');
                if (arrayOfLine[2].Contains("1")) courseArray[0]++;
                if (arrayOfLine[2].Contains("2")) courseArray[1]++;
                if (arrayOfLine[2].Contains("3")) courseArray[2]++;
                if (arrayOfLine[2].Contains("4")) courseArray[3]++;
            }
            return courseArray;
        }
        private static void DisplayStatistics(string FileName)
        {
            int[] courseArray = GradeStatistics(FileName);

            for (int i = 1; i < 5; i++)
            {
                Console.WriteLine($"Applicants of {i} grade are {courseArray[i - 1]}");
            }
        }
    }
}