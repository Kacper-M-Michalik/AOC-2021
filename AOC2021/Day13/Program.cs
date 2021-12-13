using System;
using System.Collections.Generic;

namespace Day13
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

            int HighestX = 0;
            int HighestY = 0;
            List<(int, int)> Positions = new List<(int, int)>();

            int FoldIndex = 0;
            for (int i = 0; i < Lines.Length; i++)
            {
                string[] Position = Lines[i].Split(',');

                if (Position.Length != 2)
                {
                    FoldIndex = i + 1;
                    break;
                }

                Positions.Add((Convert.ToInt32(Position[0]), Convert.ToInt32(Position[1])));

                if (Positions[i].Item1 > HighestX) HighestX = Positions[i].Item1;
                if (Positions[i].Item2 > HighestY) HighestY = Positions[i].Item2;
            }

            bool[,] Paper = new bool[HighestX + 1, HighestY + 1];

            for (int i = 0; i < Positions.Count; i++)
            {
                Paper[Positions[i].Item1, Positions[i].Item2] = true;
            }

            string[] FoldData = Lines[FoldIndex].Remove(0, 11).Split('=');
            if (FoldData[0] == "y")
            {
                bool[,] Temp = new bool[Paper.GetLength(0), (int)Math.Ceiling(Paper.GetLength(1) * 0.5f)];
                for (int y = 0; y < Temp.GetLength(1); y++)
                {
                    for (int x = 0; x < Temp.GetLength(0); x++)
                    {
                        if (Paper[x, y] || Paper[x, Paper.GetLength(1) - (1 + y)])
                        {
                            Temp[x, y] = true;
                        }
                    }
                }
                Paper = Temp;
            }
            else
            {
                bool[,] Temp = new bool[(int)Math.Ceiling(Paper.GetLength(0) * 0.5f), Paper.GetLength(1)];
                for (int x = 0; x < Temp.GetLength(0); x++)
                {
                    for (int y = 0; y < Temp.GetLength(1); y++)
                    {
                        if (Paper[x, y] || Paper[Paper.GetLength(0) - (1 + x), y])
                        {
                            Temp[x, y] = true;
                        }
                    }
                }
                Paper = Temp;
            }

            int Dots = 0;
            for (int y = 0; y < Paper.GetLength(1); y++)
            {
                for (int x = 0; x < Paper.GetLength(0); x++)
                {
                    if (Paper[x, y]) Dots++;
                }
            }
            Console.WriteLine(Dots);
        }
        static void Part2()
        {

            string[] Lines = System.IO.File.ReadAllLines("Data.txt");

            int HighestX = 0;
            int HighestY = 0;
            List<(int, int)> Positions = new List<(int, int)>();

            int FoldIndex = 0;
            for (int i = 0; i < Lines.Length; i++)
            {
                string[] Position = Lines[i].Split(',');

                if (Position.Length != 2)
                {
                    FoldIndex = i + 1;
                    break;
                }

                Positions.Add((Convert.ToInt32(Position[0]), Convert.ToInt32(Position[1])));

                if (Positions[i].Item1 > HighestX) HighestX = Positions[i].Item1;
                if (Positions[i].Item2 > HighestY) HighestY = Positions[i].Item2;
            }

            bool[,] Paper = new bool[HighestX + 1, HighestY + 1];

            for (int i = 0; i < Positions.Count; i++)
            {
                Paper[Positions[i].Item1, Positions[i].Item2] = true;
            }

            for (int i = FoldIndex; i < Lines.Length; i++)
            {
                string[] FoldData = Lines[i].Remove(0, 11).Split('=');
                if (FoldData[0] == "y")
                {
                    bool[,] Temp = new bool[Paper.GetLength(0), (int)Math.Floor(Paper.GetLength(1) * 0.5f)];
                    for (int y = 0; y < Temp.GetLength(1); y++)
                    {
                        for (int x = 0; x < Temp.GetLength(0); x++)
                        {
                            if (Paper[x, y] || Paper[x, Paper.GetLength(1) - (1 + y)])
                            {
                                Temp[x, y] = true;
                            }
                        }
                    }
                    Paper = Temp;
                }
                else
                {
                    bool[,] Temp = new bool[(int)Math.Floor(Paper.GetLength(0) * 0.5f), Paper.GetLength(1)];
                    for (int x = 0; x < Temp.GetLength(0); x++)
                    {
                        for (int y = 0; y < Temp.GetLength(1); y++)
                        {
                            if (Paper[x, y] || Paper[Paper.GetLength(0) - (1 + x), y])
                            {
                                Temp[x, y] = true;
                            }
                        }
                    }
                    Paper = Temp;
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            for (int y = 0; y < Paper.GetLength(1); y++)
            {
                string Line = "";
                for (int x = 0; x < Paper.GetLength(0); x++)
                {
                    if (Paper[x, y]) Line += "#";
                    else
                    {
                        Line += ".";
                    }
                }
                Console.WriteLine(Line);
            }

        }
    }
}
