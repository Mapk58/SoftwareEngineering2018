using System;
using System.IO;
using System.Linq;
using System.Collections;

namespace SEapplicants
{
    public class Program
    {
        public static void Main()
        {
            var applicantsStrs = File.ReadAllLines("./src/applicants.txt").Skip(1).ToArray();
            string[][] applicants = new string[applicantsStrs.Length][];

            for (var i = 0; i < applicants.Length; i++)
            {
                applicants[i] = applicantsStrs[i].Split(";", StringSplitOptions.RemoveEmptyEntries);
            }


            Console.WriteLine(GetTotalNumber(applicants));
            Console.WriteLine(string.Join("; ", GetCampusList(applicants)));
            Console.WriteLine(string.Join("; ", GetApplicantsByYear(applicants)));



            Console.ReadLine();
        }

        public static int GetTotalNumber(string[][] people)
        {
            return people.Length;
        }

        public static string[] GetCampusList(string[][] people)
        {
            ArrayList CampusList = new ArrayList();

            foreach (string[] person in people)
            {
                if (person[4] == "Да")
                {
                    CampusList.Add(person[1]);
                }
            }
            string[] StringList = new string[CampusList.Count];

            CampusList.CopyTo(StringList);

            return StringList;
        }

        public static int[] GetApplicantsByYear(string[][] people)
        {
            int[] ans = { 0, 0, 0 };

            foreach (string[] person in people)
            {
                //{...;...;"2 bachelor";....}
                int year = int.Parse(person[2].Split(" ")[0]);
                ans[year - 1]++;
            }
            return ans;
        }

    }
}
