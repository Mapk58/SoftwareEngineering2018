using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOD_hometask_1
{
    class Outputs
    {
        public static void output (int value)
        {
            Console.WriteLine("Количество заявок: " + value);
        }

        public static void output(string value)
        {
            Console.WriteLine(value);
        }

        public static void output (List<string> array)
        {
            foreach(string currentString in array)
                Console.WriteLine(currentString);
        }

        public static void output (int[] array)
        {
            Console.WriteLine("На 1 курсе учится " + array[0] + " человек");
            Console.WriteLine("На 2 курсе учится " + array[1] + " человек");
            Console.WriteLine("На 3 курсе учится " + array[2] + " человек");
            Console.WriteLine("На 4 курсе учится " + array[3] + " человек");
        }
    }
}
