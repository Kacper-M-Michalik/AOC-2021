using System;
using System.Collections.Generic;

namespace Day14
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

            Dictionary<string, int> PairCount = new Dictionary<string, int>();
            Dictionary<string, List<string>> PairLookup = new Dictionary<string, List<string>>();

            for (int i = 0; i < Lines[0].Length-1; i++)
            {
                string Pair = Lines[0][i].ToString() + Lines[0][i+1].ToString();
                if (PairCount.ContainsKey(Pair))
                {
                    PairCount[Pair]++;
                }
                else
                {
                    PairCount.Add(Pair, 1);
                }
            }

            for (int i = 2; i < Lines.Length; i++)
            {
                string[] PairData = Lines[i].Split(" -> ");
                PairLookup.Add(PairData[0], new List<string>() { PairData[0][0].ToString() + PairData[1], PairData[1] + PairData[0][1].ToString()});
            }

            for (int i = 0; i < 10; i++)
            {
                Dictionary<string, int> NewPairCount = new Dictionary<string, int>();
                foreach (KeyValuePair<string, int> Pair in PairCount)
                {
                    List<string> NewPairsList = PairLookup[Pair.Key];
                    for (int j = 0; j < NewPairsList.Count; j++)
                    {
                        if (NewPairCount.ContainsKey(NewPairsList[j]))
                        {
                            NewPairCount[NewPairsList[j]] += Pair.Value;
                        }
                        else
                        {
                            NewPairCount.Add(NewPairsList[j], Pair.Value);
                        }
                    }
                }
                PairCount = NewPairCount;                
            }

            int LargestCount = 0;
            int SmallestCount = int.MaxValue;
            Dictionary<char, int> CharCount = new Dictionary<char, int>();
            foreach (KeyValuePair<string, int> Pair in PairCount)
            {
                if (CharCount.ContainsKey(Pair.Key[0]))
                {
                    CharCount[Pair.Key[0]] += Pair.Value;
                }
                else
                {
                    CharCount.Add(Pair.Key[0], Pair.Value);
                }
                if (CharCount.ContainsKey(Pair.Key[1]))
                {
                    CharCount[Pair.Key[1]] += Pair.Value;
                }
                else
                {
                    CharCount.Add(Pair.Key[1], Pair.Value);
                }
            }

            foreach (KeyValuePair<char, int> Pair in CharCount)
            {
                if (Pair.Value > LargestCount) LargestCount = Pair.Value;
                if (Pair.Value < SmallestCount) SmallestCount = Pair.Value;
            }
            //WE havent taken into account that pairs overlap - as such halfing and taking away 1 gave right anwer but this was pure luck, have yet to figure out which pairs are overcounted.
            Console.WriteLine(Math.Ceiling((LargestCount-SmallestCount)*0.5f));
        }
        static void Part2()
        {
            string[] Lines = System.IO.File.ReadAllLines("Data.txt");

            Dictionary<string, long> PairCount = new Dictionary<string, long>();
            Dictionary<string, List<string>> PairLookup = new Dictionary<string, List<string>>();

            for (int i = 0; i < Lines[0].Length - 1; i++)
            {
                string Pair = Lines[0][i].ToString() + Lines[0][i + 1].ToString();
                if (PairCount.ContainsKey(Pair))
                {
                    PairCount[Pair]++;
                }
                else
                {
                    PairCount.Add(Pair, 1);
                }
            }

            for (int i = 2; i < Lines.Length; i++)
            {
                string[] PairData = Lines[i].Split(" -> ");
                PairLookup.Add(PairData[0], new List<string>() { PairData[0][0].ToString() + PairData[1], PairData[1] + PairData[0][1].ToString() });
            }

            for (int i = 0; i < 40; i++)
            {
                Dictionary<string, long> NewPairCount = new Dictionary<string, long>();
                foreach (KeyValuePair<string, long> Pair in PairCount)
                {
                    List<string> NewPairsList = PairLookup[Pair.Key];
                    for (int j = 0; j < NewPairsList.Count; j++)
                    {
                        if (NewPairCount.ContainsKey(NewPairsList[j]))
                        {
                            NewPairCount[NewPairsList[j]] += Pair.Value;
                        }
                        else
                        {
                            NewPairCount.Add(NewPairsList[j], Pair.Value);
                        }
                    }
                }
                PairCount = NewPairCount;
            }

            long LargestCount = 0;
            long SmallestCount = long.MaxValue;
            Dictionary<char, long> CharCount = new Dictionary<char, long>();
            foreach (KeyValuePair<string, long> Pair in PairCount)
            {
                if (CharCount.ContainsKey(Pair.Key[0]))
                {
                    CharCount[Pair.Key[0]] += Pair.Value;
                }
                else
                {
                    CharCount.Add(Pair.Key[0], Pair.Value);
                }
                if (CharCount.ContainsKey(Pair.Key[1]))
                {
                    CharCount[Pair.Key[1]] += Pair.Value;
                }
                else
                {
                    CharCount.Add(Pair.Key[1], Pair.Value);
                }
            }

            CharCount[Lines[0][0]]++;
            CharCount[Lines[0][Lines[0].Length - 1]]++;

            foreach (KeyValuePair<char, long> Pair in CharCount)
            {
                CharCount[Pair.Key] = (long)(CharCount[Pair.Key]*0.5f);
            }

            foreach (KeyValuePair<char, long> Pair in CharCount)
            {
                if (Pair.Value > LargestCount) LargestCount = Pair.Value;
                if (Pair.Value < SmallestCount) SmallestCount = Pair.Value;
            }

            Console.WriteLine(LargestCount-SmallestCount);
        }
    }
}
