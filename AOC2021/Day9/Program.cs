using System;
using System.Collections.Generic;

namespace Day9
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
            int[,] Vents = new int[Data[0].Length, Data.Length];

            for (int i = 0; i < Data.Length; i++)
            {
                for (int j = 0; j < Data[i].Length; j++)
                {
                    Vents[j, i] = Convert.ToInt32(Data[i][j].ToString());
                }
            }

            List<int> LowestValues = new List<int>();
            for (int y = 0; y < Vents.GetLength(1); y++)
            {
                for (int x = 0; x < Vents.GetLength(0); x++)
                {
                    bool IsLowest = true;
                    if (x > 0 && Vents[x - 1, y] <= Vents[x, y]) IsLowest = false;
                    if (y > 0 && Vents[x, y - 1] <= Vents[x, y]) IsLowest = false;
                    if (x < Vents.GetLength(0) - 1 && Vents[x + 1, y] <= Vents[x, y]) IsLowest = false;
                    if (y < Vents.GetLength(1) - 1 && Vents[x, y + 1] <= Vents[x, y]) IsLowest = false;

                    if (IsLowest) LowestValues.Add(Vents[x, y]);
                }
            }

            int Sum = 0;
            for (int i = 0; i < LowestValues.Count; i++)
            {
                Sum += LowestValues[i] + 1;
            }

            Console.WriteLine(Sum);
            Console.ReadLine();
        }

        static void Part2()
        {
            string[] Data = System.IO.File.ReadAllLines("Data.txt");
            int[,] Vents = new int[Data[0].Length, Data.Length];
            bool[,] ActiveData = new bool[Data[0].Length, Data.Length];

            for (int i = 0; i < Data.Length; i++)
            {
                for (int j = 0; j < Data[i].Length; j++)
                {
                    Vents[j, i] = Convert.ToInt32(Data[i][j].ToString());
                    if (Vents[j, i] != 9) ActiveData[j, i] = true;
                    else ActiveData[j, i] = false;
                }
            }

            List<int> BasinList = new List<int>();

            for (int y = 0; y < Vents.GetLength(1); y++)
            {
                for (int x = 0; x < Vents.GetLength(0); x++)
                {
                    if (ActiveData[x, y])
                    {
                        BasinList.Add(FloodFill(x, y, new IntPointer(0)).Value);
                    }
                }
            }

            BasinList.Sort();
            Console.WriteLine(BasinList[BasinList.Count-1]* BasinList[BasinList.Count - 2]* BasinList[BasinList.Count - 3]);
            Console.ReadLine();            

            IntPointer FloodFill(int X, int Y, IntPointer Total)
            {
                Total.Value++;
                ActiveData[X, Y] = false;

                if (X > 0 && ActiveData[X - 1, Y]) FloodFill(X - 1, Y, Total);
                if (Y > 0 && ActiveData[X, Y - 1]) FloodFill(X, Y - 1, Total);
                if (X < Vents.GetLength(0) - 1 && ActiveData[X + 1, Y]) FloodFill(X + 1, Y, Total);
                if (Y < Vents.GetLength(1) - 1 && ActiveData[X, Y + 1]) FloodFill(X, Y + 1, Total);

                return Total;
            }
        }

        public class IntPointer
        {
            public int Value;
            public IntPointer(int NewInt)
            {
                Value = NewInt;
            }
        }
    }
}

