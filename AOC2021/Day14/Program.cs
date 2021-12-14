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

            Dictionary<string, long> PairCount = new Dictionary<string, long>();
            Dictionary<string, List<string>> PairLookup = new Dictionary<string, List<string>>();
            Dictionary<char, long> CharacterDuplicates = new Dictionary<char, long>();

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

                if (i != 0)
                {
                    if (CharacterDuplicates.ContainsKey(Lines[0][i]))
                    {
                        CharacterDuplicates[Lines[0][i]]++;
                    }
                    else
                    {
                        CharacterDuplicates.Add(Lines[0][i], 1);
                    }
                }
            }
            if (!CharacterDuplicates.ContainsKey(Lines[0][Lines[0].Length - 1])) CharacterDuplicates.Add(Lines[0][Lines[0].Length - 1], 0);

            for (int i = 2; i < Lines.Length; i++)
            {
                string[] PairData = Lines[i].Split(" -> ");
                PairLookup.Add(PairData[0], new List<string>() { PairData[0][0].ToString() + PairData[1], PairData[1] + PairData[0][1].ToString() });
            }

            for (int i = 0; i < 10; i++)
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
                    if (CharacterDuplicates.ContainsKey(NewPairsList[0][1]))
                    {
                        CharacterDuplicates[NewPairsList[0][1]] += Pair.Value;
                    }
                    else
                    {
                        CharacterDuplicates.Add(NewPairsList[0][1], Pair.Value);
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

            foreach (KeyValuePair<char, long> Pair in CharCount)
            {
                long TrueCount = Pair.Value - CharacterDuplicates[Pair.Key];

                if (TrueCount > LargestCount) LargestCount = TrueCount;
                if (TrueCount < SmallestCount) SmallestCount = TrueCount;
            }

            Console.WriteLine(LargestCount - SmallestCount);
        }

        static void Part2()
        {
            DateTime Start = DateTime.UtcNow;
            string[] Lines = System.IO.File.ReadAllLines("Data.txt");

            Dictionary<string, long> PairCount = new Dictionary<string, long>();
            Dictionary<string, List<string>> PairLookup = new Dictionary<string, List<string>>();
            Dictionary<char, long> CharacterDuplicates = new Dictionary<char, long>();

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

                if (i != 0)
                {
                    if (CharacterDuplicates.ContainsKey(Lines[0][i]))
                    {
                        CharacterDuplicates[Lines[0][i]]++;
                    }
                    else
                    {
                        CharacterDuplicates.Add(Lines[0][i], 1);
                    }
                }
            }
            if (!CharacterDuplicates.ContainsKey(Lines[0][Lines[0].Length - 1])) CharacterDuplicates.Add(Lines[0][Lines[0].Length - 1], 0);

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
                    if (CharacterDuplicates.ContainsKey(NewPairsList[0][1]))
                    {
                        CharacterDuplicates[NewPairsList[0][1]] += Pair.Value;
                    }
                    else
                    {
                        CharacterDuplicates.Add(NewPairsList[0][1], Pair.Value);
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

            foreach (KeyValuePair<char, long> Pair in CharCount)
            {
                long TrueCount = Pair.Value - CharacterDuplicates[Pair.Key];

                if (TrueCount > LargestCount) LargestCount = TrueCount;
                if (TrueCount < SmallestCount) SmallestCount = TrueCount;
            }

            DateTime End = DateTime.UtcNow;
            Console.WriteLine(LargestCount - SmallestCount);
            Console.WriteLine("MS: "+(End.Millisecond - Start.Millisecond).ToString());
        }
    }
}
