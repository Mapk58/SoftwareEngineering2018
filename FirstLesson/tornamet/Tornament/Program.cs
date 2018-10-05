using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;


namespace Tornament
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Tornament> Tornaments = new List<Tornament>();
            //string ParticipantsPath = "ParticipantsList.txt";
            //string Name = "MyTornament";

            //string[] Participants = GetParticipantsList(ParticipantsPath);

            //var t = new Tornament(Name, Participants);
            //Console.WriteLine(t.ParticipantsPairs[0, 0]);
            //t.WriteTornament();
            while (true)
            {
                Console.WriteLine("Выберете действие\n1 Создать турнир\n2 Добавить победителя пары в турнире\n3 Создать файл турнира");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Tornaments.Add(CreateT());
                        break;
                    case "2":
                        AddPairWinner(ref Tornaments);
                        break;
                    case "3":
                        WriteTornament(ref Tornaments);
                        break;
                    default:
                        Console.WriteLine("Нет такого действия.\nНажмите любую клавийу для возврата");
                        Console.ReadLine();
                        break;
                }
            }

        }

        public static Tornament CreateT()
        {
            Console.WriteLine("Напишите имя турнира: ");
            string nameT = Console.ReadLine().Trim();
            Console.WriteLine("Напишите путь к файлу");
            string pathT = String.Format(@"{0}", Console.ReadLine());

            if (!File.Exists(pathT))
            {
                Console.WriteLine("Нет файла");
                CreateT();
            }
            string[] participants = GetParticipantsList(pathT);

            return new Tornament(nameT, participants);

        }

        public static string[] GetParticipantsList(string FilePath)
        {
            var separators = new char[] { ',', ';' };
            var FileText = File.ReadAllText(FilePath);
            var People = FileText.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                                 .ToList()
                                 .ConvertAll((string input) => input.Trim())
                                 .ToArray();
            return People;
        }

        public static void AddPairWinner(ref List<Tornament> Tornaments)
        {
            Console.WriteLine("Напишите имя турнира: ");
            string nameT = Console.ReadLine().Trim();
            int id = GetTornamentId(nameT, ref Tornaments);
            if (id == -1)
            {
                Console.WriteLine("Нет такого турнира");
                return;
            }
            Console.WriteLine("Напишите имя участника: ");
            string nameP = Console.ReadLine().Trim();

            Tornaments[id].AddPairWinner(nameP);
        }

        public static void WriteTornament(ref List<Tornament> Tornaments)
        {
            Console.WriteLine("Напишите имя турнира");
            string nameT = Console.ReadLine().Trim();
            int id = GetTornamentId(nameT, ref Tornaments);
            if (id == -1)
            {
                Console.WriteLine("Нет такого турнира");
                return;
            }
            Tornaments[id].WriteTornament();
        }

        public static int GetTornamentId(string TornamentName, ref List<Tornament> Tornaments)
        {
            int curId = -1;
            for (var i = 0; i < Tornaments.Count(); i++)
            {
                if (Tornaments[i].Name == TornamentName)
                {
                    curId = i;
                }
            }
            return curId;
        }

    }



    public class Tornament
    {
        public string Name;// { get; set; }
        public string[,] ParticipantsPairs;
        public string[] CurrentLevelWinners = { };
        public string[] CurrentLevelLoosers = { };


        public Tornament(string name, string[] participants)
        {
            Name = name;
            ParticipantsPairs = Pair(participants);
        }

        public static string[,] Pair(string[] people)
        {
            if ((people.Length == 0) || (people.Length & (people.Length - 1)) != 0)
            {
                throw new ArgumentException("A list of people to pair should have length of power of 2");
            }

            int PairsAmt = people.Length / 2;
            string[,] Pairs = new string[PairsAmt, 2];
            for (var i = 0; i < PairsAmt; i += 1)
            {
                Pairs[i, 0] = people[i * 2];//, people[i + 1]};
                Pairs[i, 1] = people[i * 2 + 1];
            }
            return Pairs;
        }

        public void Evaluate()
        {
            WriteTornament();
            ParticipantsPairs = Pair(CurrentLevelWinners);

            CurrentLevelWinners = new string[] { };
        }

        public void AddPairWinner(string PairWinner)
        {
            if (this.CurrentLevelWinners.Contains(PairWinner))
            {
                Console.WriteLine("Участник уже победитель пары");
            } else if(this.CurrentLevelLoosers.Contains(PairWinner)) {
                Console.WriteLine("Участник уже проиграл в паре");
            }
            else if (CheckPerson(PairWinner))
            {
                CurrentLevelWinners.Append(PairWinner);
                string looser = ParticipantsPairs[GetPersonIndex(PairWinner)[0], Math.Abs(GetPersonIndex(PairWinner)[1] - 1)];
                CurrentLevelLoosers.Append(looser);
            }
            else
            {
                Console.WriteLine("Такого человека нет в списке");
            }
            //если это был последний то переходи на след уровень
            if (CurrentLevelWinners.Length == ParticipantsPairs.GetLength(0))
            {
                Evaluate();
            }
        }

        public int[] GetPersonIndex(string person)
        {
            int[] index = { -1, -1 };
            for (var i = 0; i < this.ParticipantsPairs.GetLength(0); i++)
            {
                if (this.ParticipantsPairs[i, 0] == person)
                {
                    index[0] = i;
                    index[1] = 0;
                    break;
                }
                else if (this.ParticipantsPairs[i, 1] == person)
                {
                    index[0] = i;
                    index[1] = 1;
                    break;
                }
            }
            return index;
        }

        public bool CheckPerson(string person)
        {
            bool inside = false;
            for (var i = 0; i < this.ParticipantsPairs.GetLength(0); i++)
            {
                if (this.ParticipantsPairs[i, 0] == person ||
                    this.ParticipantsPairs[i, 1] == person)
                {
                    inside = true;
                    break;
                }
            }
            return inside;
        }

        public void WriteTornament()
        {
            string[] strPairs = new string[ParticipantsPairs.GetLength(0)];
            for (var i = 0; i < strPairs.Length; i++)
            {
                strPairs[i] = ParticipantsPairs[i, 0] + " и " + ParticipantsPairs[i, 1];
            }


            string pairs = "Пары:\n" + String.Join("\n", strPairs);
            string winners = "\nПобедители этапа:\n" + String.Join("\n", CurrentLevelWinners);
            File.WriteAllText(Name, pairs + winners);
            Console.WriteLine("Файл Был Создан");
        }
    }
}
