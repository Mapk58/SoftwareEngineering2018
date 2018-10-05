using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleApp47
{
    public class Program
    {
        
        static void Main(string[] args)
        {
             string command = args[0];
             string path = args[1];
            List<string> data = GetData(path);
             

            switch (command)
            {
                case "GetCount":
                   Console.WriteLine(GetCount(data));
                    break;
                case "GetDormPeople":
                     WriteToConsole(GetDormPeople(data));
                    break;
                case "GetCours":
                    WriteToConsole(GetCours(data));
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
           
        }

        public static List<string> GetData(string path)
        {
            List<string> data = new List<string>(File.ReadAllLines(path));
            data.RemoveAt(0);
            return data;
        }
        public static int GetCount(List<string> data)
        {
            return data.Count;
        }
        public static List<string> GetDormPeople(List<string> data)
        {
            List<string> names = new List<string>();
            foreach(string el in data)
            {
                string[] pol = el.Split(';');
                if (pol[4] == "Да") names.Add(pol[1]);
                
            }
            
            return names;
        }
        public static int[] GetCours(List<string> data)
        {
            int[] cours = new int[4];
            foreach(string el in data)
            {
                string[] pol = el.Split(';');
                string a = pol[2];
                cours[int.Parse(char.ToString(a[0])) - 1]++;                
            }
            return cours;
        }

        
        static void WriteToConsole(int[] arr)
        {
            foreach (int el in arr) Console.WriteLine(el);
        }
        static void WriteToConsole(List<string> list)
        {
            foreach (string el in list) Console.WriteLine(el);
        }
    }
}
