using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LOD_hometask_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = args[0];
            string fileDirectory = args[1];
            string[] fileWithProfiles = getFile(fileDirectory);
            string errorMassage = "Не удалось получить доступ к файлу, проверьте правильность указанного пути. " +
                "Возможно он является пустым";
            if (fileWithProfiles != null)
                commandManager(command, fileWithProfiles);
            else
                Outputs.output(errorMassage);
            Console.ReadKey();
            
        }

        public static void commandManager(string command, string[] fileWithProfiles)
        {
            switch (command)
            {
                case "count":
                    Outputs.output(profilesCounter(fileWithProfiles));
                    break;
                case "inDorm":
                    Outputs.output(liveInDorm(fileWithProfiles));
                    break;
                case "statistics":
                    Outputs.output(courseStatistics(fileWithProfiles));
                    break;
                default:
                    Outputs.output("Несуществующая команда");
                    break;
            }
        }

        public static string[] getFile(string fileDirectory)
        {
            try
            {
                return File.ReadAllLines(fileDirectory).Skip(1).ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static int profilesCounter(string[] fileWithProfiles)
        {
            return fileWithProfiles.Length;
        }

        public static List<string> liveInDorm(string[] fileWithProfiles)
        {
            List<string> inDormPersons = new List<string>();
            foreach(string currentString in fileWithProfiles)
            {
                var separatedLine = currentString.Split(';');
                if (separatedLine[4] == "Да")
                    inDormPersons.Add(separatedLine[1]);
            }
            return inDormPersons;
        }
        public static int[] courseStatistics(string[] fileWithProfiles)
        {
            int[] counterArray = new int[4];
            foreach(string currentString in fileWithProfiles)
            {
                var separatedLine = currentString.Split(';');
                switch (separatedLine[2][0])
                {
                    case '1':
                        counterArray[0]++;
                        break;
                    case '2':
                        counterArray[1]++;
                        break;
                    case '3':
                        counterArray[2]++;
                        break;
                    case '4':
                        counterArray[3]++;
                        break;
                }
            }
            return counterArray;
        }
    }
}
