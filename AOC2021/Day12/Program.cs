using System;
using System.Collections.Generic;

namespace Day12
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        static void Part1()
        {
            string[] Lines = System.IO.File.ReadAllLines("Data.txt");
            Dictionary<string, List<string>> CaveConnectionLookup = new Dictionary<string, List<string>>();

            for (int i = 0; i < Lines.Length; i++)
            {
                string[] Connection = Lines[i].Split('-');

                if (CaveConnectionLookup.ContainsKey(Connection[0]))
                {
                    CaveConnectionLookup[Connection[0]].Add(Connection[1]);
                }
                else
                {
                    CaveConnectionLookup.Add(Connection[0], new List<string>() {Connection[1]});
                }

                if (CaveConnectionLookup.ContainsKey(Connection[1]))
                {
                    CaveConnectionLookup[Connection[1]].Add(Connection[0]);
                }
                else
                {
                    CaveConnectionLookup.Add(Connection[1], new List<string>() { Connection[0] });
                }
            }

            int Paths = 0;
            MoveToCave("start", new List<string>());
            Console.WriteLine(Paths);
            Console.ReadLine();

            void MoveToCave(string CurrentCave, List<string> VistedCaves)
            {
                VistedCaves.Add(CurrentCave);

                if (CurrentCave == "end")
                {
                    Paths++;
                    return;
                }

                for (int i = 0; i < CaveConnectionLookup[CurrentCave].Count; i++)
                {
                    if (!char.IsLower(CaveConnectionLookup[CurrentCave][i][0]) || (char.IsLower(CaveConnectionLookup[CurrentCave][i][0]) && !VistedCaves.Contains(CaveConnectionLookup[CurrentCave][i])))
                    {
                        MoveToCave(CaveConnectionLookup[CurrentCave][i], new List<string>(VistedCaves));
                    }
                }
            }
        }
        static void Part2()
        {

        }
    }
}
