using System;
using System.Collections.Generic;

namespace Day10
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
            List<string> Data = new List<string>(System.IO.File.ReadAllLines("Data.txt"));
            Dictionary<char, int> ErrorValueLookup = new Dictionary<char, int>() { 
                {')', 3},
                {']', 57},
                {'}', 1197},
                {'>', 25137}
            };

            int ErrorScore = 0;
            for (int i = 0; i < Data.Count; i++)
            {
                bool ErrorReached = false;
                bool WasRemoved = true;
                while (!ErrorReached && WasRemoved)
                {
                    WasRemoved = false;
                    for (int j = 0; j < Data[i].Length - 1; j++)
                    {
                        InverseResult Comparison = IsInverse(Data[i][j], Data[i][j + 1]);
                        
                        if (Comparison.Result)
                        {
                            WasRemoved = true;
                            Data[i] = Data[i].Remove(j, 2);
                        }
                        else if (Comparison.PossiblePair)
                        {
                            ErrorReached = true;
                            ErrorScore += ErrorValueLookup[Data[i][j+1]];
                        }
                    }
                }
            }
            Console.WriteLine(ErrorScore);
            Console.ReadKey();
        }

        static InverseResult IsInverse(char Left, char Right)
        {
            switch (Left)
            {
                case '(':
                    return new InverseResult(Right == ')', Right == ')' || Right == ']' || Right == '}' || Right == '>');
                case '[':
                    return new InverseResult(Right == ']', Right == ')' || Right == ']' || Right == '}' || Right == '>');
                case '{':
                    return new InverseResult(Right == '}', Right == ')' || Right == ']' || Right == '}' || Right == '>');
                case '<':
                    return new InverseResult(Right == '>', Right == ')' || Right == ']' || Right == '}' || Right == '>');
                case ')':
                    return new InverseResult(false, false);
                case ']':
                    return new InverseResult(false, false);
                case '}':
                    return new InverseResult(false, false);
                case '>':
                    return new InverseResult(false, false);
                default:
                    throw new Exception();
            }
        }

        public class InverseResult
        {
            public bool Result;
            public bool PossiblePair;
            public InverseResult(bool NewResult, bool NewError)
            {
                Result = NewResult;
                PossiblePair = NewError;
            }
        }

        static void Part2()
        {
            List<string> Data = new List<string>(System.IO.File.ReadAllLines("Data.txt"));
            Dictionary<char, int> AutoCompleteScoreLookup = new Dictionary<char, int>() {
                {'(', 1},
                {'[', 2},
                {'{', 3},
                {'<', 4}
            };

            List<string> Incomplete = new List<string>();
            for (int i = 0; i < Data.Count; i++)
            {
                bool ErrorReached = false;
                bool WasRemoved = true;
                while (!ErrorReached && WasRemoved)
                {
                    WasRemoved = false;
                    for (int j = 0; j < Data[i].Length - 1; j++)
                    {
                        InverseResult Comparison = IsInverse(Data[i][j], Data[i][j + 1]);

                        if (Comparison.Result)
                        {
                            WasRemoved = true;
                            Data[i] = Data[i].Remove(j, 2);
                        }
                        else if (Comparison.PossiblePair)
                        {
                            ErrorReached = true;
                        }
                    }
                }
                if (!ErrorReached)
                {
                    Incomplete.Add(Data[i]);
                }
            }

            List<long> Scores = new List<long>();
            for (int i = 0; i < Incomplete.Count; i++)
            {
                long AutoCompleteScore = 0;               

                for (int j = Incomplete[i].Length-1; j > -1; j--)
                {
                    AutoCompleteScore *= 5;
                    AutoCompleteScore += AutoCompleteScoreLookup[Incomplete[i][j]];
                }
                Scores.Add(AutoCompleteScore);
            }
            Scores.Sort();
            Console.WriteLine(Scores[ (int)Math.Floor(Scores.Count * 0.5f) ]);
            Console.ReadKey();

        }
    }
}
