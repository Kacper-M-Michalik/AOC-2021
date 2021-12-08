using System;
using System.Collections.Generic;

namespace Day8
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
            string[] Data = System.IO.File.ReadAllLines("Data.txt");

            int TargetDisplays = 0;

            for (int i = 0; i < Data.Length; i++)
            {
                string[] Input = Data[i].Split("| ")[1].Split(' ');
                for (int j = 0; j < Input.Length; j++)
                {
                    if (Input[j].Length == 2 || Input[j].Length == 4 || Input[j].Length == 3 || Input[j].Length == 7) TargetDisplays++;
                }
            }

            Console.WriteLine(TargetDisplays);
            Console.ReadLine();
        }         

        static void Part2()
        {
            /*
            Dictionary<char, int> Top = new Dictionary<char, int>() { { 'a', 0 }, { 'b', 0 }, { 'c', 0 }, { 'd', 0 }, { 'e', 0 }, { 'f', 0 }, { 'g', 0 } };
            int TopLeft
            int TopRight
            int Middle
            int BottomLeft
            int BottomRight
            int Bottom 
            
            //dab

            string[] Data = System.IO.File.ReadAllLines("Data.txt");


            // a 
            //b c
            // d
            //e f
            // g

            Dictionary<int, List<char>> Positions = new Dictionary<int, List<char>>() { {2, new List<char>(){'c','f'}}, { 3, new List<char>() { 'a', 'c', 'f' } }, { 4, new List<char>() { 'b', 'c', 'd', 'f' } }, {5, new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g' }}, {6, new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g' } }, {7, new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g' }}};

            //for (int i -)

            int Total = 0;
            for (int i = 0; i < Data.Length; i++)
            {
                Dictionary<char, List<string>> Combinations = new Dictionary<char, List<string>>() { { 'a', new List<string>() }, { 'b', new List<string>() }, { 'c', new List<string>() }, { 'd', new List<string>() }, { 'e', new List<string>() }, { 'f', new List<string>() }, { 'g', new List<string>() } };
                string[] Input = Data[i].Split(" | ")[0].Split(' ');
                for (int j = 0; j < Input.Length; j++)
                {
                    List<char> PossiblePositions = Positions[Input[j].Length];
                    for (int k = 0; k < PossiblePositions.Count; k++)
                    {
                        Combinations[PossiblePositions[k]].Add(Input[j]);
                    }
                }

                

            }

            Console.WriteLine(Total);
            Console.ReadLine();
            */


            string[] Data = System.IO.File.ReadAllLines("Data.txt");

            string TopBar = "";
            string TopLeft = "";
            string TopRight = "";
            string MiddleBar = "";
            string BottomLeft = "";
            string BottomRight = "";
            string BottomBar = "";

            string DisplayLookup(string Value)
            {
                if (Value.Contains(TopBar) && Value.Contains(TopLeft) && Value.Contains(TopRight) && Value.Contains(MiddleBar) && Value.Contains(BottomLeft) && Value.Contains(BottomRight) && Value.Contains(BottomBar)) 
                {
                    return "8";
                }
                if (Value.Contains(TopBar) && Value.Contains(TopLeft) && Value.Contains(TopRight) && Value.Contains(MiddleBar) && Value.Contains(BottomRight) && Value.Contains(BottomBar))
                {
                    return "9";
                }
                if (Value.Contains(TopBar) && Value.Contains(TopLeft) && Value.Contains(MiddleBar) && Value.Contains(BottomLeft) && Value.Contains(BottomRight) && Value.Contains(BottomBar))
                {
                    return "6";
                }
                if (Value.Contains(TopBar) && Value.Contains(TopLeft) && Value.Contains(TopRight) && Value.Contains(BottomLeft) && Value.Contains(BottomRight) && Value.Contains(BottomBar))
                {
                    return "0";
                }
                if (Value.Contains(TopBar) && Value.Contains(TopRight) && Value.Contains(MiddleBar) && Value.Contains(BottomLeft) && Value.Contains(BottomBar))
                {
                    return "2";
                }
                if (Value.Contains(TopBar) && Value.Contains(TopLeft) && Value.Contains(MiddleBar) && Value.Contains(BottomRight) && Value.Contains(BottomBar))
                {
                    return "5";
                }
                if (Value.Contains(TopBar) && Value.Contains(TopRight) && Value.Contains(MiddleBar) && Value.Contains(BottomRight) && Value.Contains(BottomBar))
                {
                    return "3";
                }
                if (Value.Contains(TopLeft) && Value.Contains(TopRight) && Value.Contains(MiddleBar) && Value.Contains(BottomRight))
                {
                    return "4";
                }
                if (Value.Contains(TopBar) && Value.Contains(TopRight) && Value.Contains(BottomRight))
                {
                    return "7";
                }
                if (Value.Contains(TopRight) && Value.Contains(BottomRight))
                {
                    return "1";
                }
                throw new Exception("Bad Value");
            }

            int TotalSum = 0;
            for (int i = 0; i < Data.Length; i++)
            {
                string[] Input = Data[i].Split(" | ")[0].Split(' ');

                string Seven = "";
                string One = "";
                string Four = "";
                string Eight = "";
                for (int j = 0; j < Input.Length; j++)
                {
                    if (Input[j].Length == 2) One = Input[j];
                    if (Input[j].Length == 3) Seven = Input[j];
                    if (Input[j].Length == 4) Four = Input[j];
                    if (Input[j].Length == 7) Eight = Input[j];
                }
                TopBar = GetDifference(Seven, One)[0].ToString();

                string PseudoNine = Combine(Seven, Four);
                List<char> BBL = GetDifference(Eight, PseudoNine);

                string Nine = "";
                for (int j = 0; j < Input.Length; j++)
                {
                    if (Input[j].Length == 6 && Input[j].Contains(BBL[0]) && !Input[j].Contains(BBL[1]))
                    {
                        Nine = Input[j];
                        j = Input.Length;
                    }
                }

                BottomLeft = GetDifference(Nine, BBL[0].ToString() + BBL[1].ToString()+PseudoNine)[0].ToString();
                if (BBL[0].ToString() != BottomLeft) BottomBar = BBL[0].ToString();
                else BottomBar = BBL[1].ToString();

                string Three = "";
                for (int j = 0; j < Input.Length; j++)
                {
                    if (Input[j].Length == 5 && Input[j].Contains(One[0]) && Input[j].Contains(One[1]))
                    {
                        Three = Input[j];
                        j = Input.Length;
                    }
                }
                MiddleBar = GetDifference(Three, One+TopBar+BottomBar)[0].ToString();
                TopLeft = GetDifference(Four, One+MiddleBar)[0].ToString();

                string Five = "";
                for (int j = 0; j < Input.Length; j++)
                {
                    if (Input[j].Length == 5 && Input[j].Contains(TopLeft))
                    {
                        Five = Input[j];
                        j = Input.Length;
                    }
                }

                TopRight = GetDifference(Five, One + TopBar + TopLeft + MiddleBar + BottomBar)[0].ToString();
                BottomRight = GetDifference(One, TopRight)[0].ToString();

                string[] DisplayInput = Data[i].Split(" | ")[1].Split(' ');
                string Display = "";
                for (int j = 0; j < DisplayInput.Length; j++)
                {
                    Display += DisplayLookup(DisplayInput[j]);
                }

                TotalSum += Convert.ToInt32(Display);
            }

            Console.WriteLine(TotalSum);
            Console.ReadLine();

        }

        static string Combine(string Left, string Right)
        {
            string Result = "";
            for (int i = 0; i < Left.Length; i ++)
            {
                if (!Result.Contains(Left[i])) Result += Left[i];
            }
            for (int i = 0; i < Right.Length; i++)
            {
                if (!Result.Contains(Right[i])) Result += Right[i];
            }
            return Result;
        }

        static List<char> GetDifference(string Left, string Right)
        {
            HashSet<char> Differences = new HashSet<char>();
            for (int i = 0; i < Left.Length; i++)
            {
                if (!Right.Contains(Left[i])) Differences.Add(Left[i]);
            }
            for (int i = 0; i < Right.Length; i++)
            {
                if (!Left.Contains(Right[i])) Differences.Add(Right[i]);
            }

            return new List<char>(Differences);
        }

    }
}
