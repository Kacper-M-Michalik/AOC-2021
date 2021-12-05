using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        public class Line
        {
            public int X1;
            public int Y1;

            public int X2;
            public int Y2;

            public Line(int NewX1, int NewY1, int NewX2, int NewY2)
            {
                X1 = NewX1;
                Y1 = NewY1;
                X2 = NewX2;
                Y2 = NewY2;
            }

        }

        static void Part1()
        {
            string[] Input = System.IO.File.ReadAllLines("Data.txt");

            List<Line> Lines = new List<Line>();

            for (int i = 0; i < Input.Length; i++)
            {
                string[] Coords = Input[i].Split(" -> ");

                string[] SplitCoord1 = Coords[0].Split(',');
                string[] SplitCoord2 = Coords[1].Split(',');

                Lines.Add(new Line(Convert.ToInt32(SplitCoord1[0]), Convert.ToInt32(SplitCoord1[1]), Convert.ToInt32(SplitCoord2[0]), Convert.ToInt32(SplitCoord2[1])));
            }

            Dictionary<(int, int), int> Coordinates = new Dictionary<(int, int), int>();

            for (int i = 0; i < Lines.Count; i++)
            { 
                if (Lines[i].X1 == Lines[i].X2)
                {
                    int StartY = Lines[i].Y1 < Lines[i].Y2 ? Lines[i].Y1 : Lines[i].Y2;
                    int EndY = Lines[i].Y1 > Lines[i].Y2 ? Lines[i].Y1 : Lines[i].Y2;

                    for (int y = StartY; y < EndY+1; y++)
                    {
                        if (Coordinates.TryGetValue((Lines[i].X1, y), out int Value))
                        {
                            Coordinates[(Lines[i].X1, y)] += 1;
                        }
                        else
                        {
                            Coordinates.Add((Lines[i].X1, y), 1);
                        }
                    }
                }
                else if (Lines[i].Y1 == Lines[i].Y2)
                {
                    int StartX = Lines[i].X1 < Lines[i].X2 ? Lines[i].X1 : Lines[i].X2;
                    int EndX = Lines[i].X1 > Lines[i].X2 ? Lines[i].X1 : Lines[i].X2;

                    for (int x = StartX; x < EndX + 1; x++)
                    {
                        if (Coordinates.TryGetValue((x, Lines[i].Y1), out int Value))
                        {
                            Coordinates[(x, Lines[i].Y1)] += 1;
                        }
                        else
                        {
                            Coordinates.Add((x, Lines[i].Y1), 1);
                        }
                    }
                }
            }

            int Overlaps = 0;
            foreach (KeyValuePair<(int,int), int> Coord in Coordinates)
            {
                if (Coord.Value > 1) Overlaps++;
            }

            Console.WriteLine(Overlaps);
            Console.ReadKey();
        }

        static void Part2()
        {
            string[] Input = System.IO.File.ReadAllLines("Data.txt");

            List<Line> Lines = new List<Line>();

            for (int i = 0; i < Input.Length; i++)
            {
                string[] Coords = Input[i].Split(" -> ");

                string[] SplitCoord1 = Coords[0].Split(',');
                string[] SplitCoord2 = Coords[1].Split(',');

                Lines.Add(new Line(Convert.ToInt32(SplitCoord1[0]), Convert.ToInt32(SplitCoord1[1]), Convert.ToInt32(SplitCoord2[0]), Convert.ToInt32(SplitCoord2[1])));
            }

            Dictionary<(int, int), int> Coordinates = new Dictionary<(int, int), int>();

            for (int i = 0; i < Lines.Count; i++)
            {
                if (Lines[i].X1 == Lines[i].X2)
                {
                    int StartY = Lines[i].Y1 < Lines[i].Y2 ? Lines[i].Y1 : Lines[i].Y2;
                    int EndY = Lines[i].Y1 > Lines[i].Y2 ? Lines[i].Y1 : Lines[i].Y2;

                    for (int y = StartY; y < EndY + 1; y++)
                    {
                        if (Coordinates.TryGetValue((Lines[i].X1, y), out int Value))
                        {
                            Coordinates[(Lines[i].X1, y)] += 1;
                        }
                        else
                        {
                            Coordinates.Add((Lines[i].X1, y), 1);
                        }
                    }
                }
                else if (Lines[i].Y1 == Lines[i].Y2)
                {
                    int StartX = Lines[i].X1 < Lines[i].X2 ? Lines[i].X1 : Lines[i].X2;
                    int EndX = Lines[i].X1 > Lines[i].X2 ? Lines[i].X1 : Lines[i].X2;

                    for (int x = StartX; x < EndX + 1; x++)
                    {
                        if (Coordinates.TryGetValue((x, Lines[i].Y1), out int Value))
                        {
                            Coordinates[(x, Lines[i].Y1)] += 1;
                        }
                        else
                        {
                            Coordinates.Add((x, Lines[i].Y1), 1);
                        }
                    }
                }
                else
                {
                    int StartX;
                    int EndX;
                    int Change;
                    int y;
                    if (Lines[i].X1 < Lines[i].X2)
                    {
                        StartX = Lines[i].X1;
                        EndX = Lines[i].X2;
                        Change = Lines[i].Y1 < Lines[i].Y2 ? 1 : -1;
                        y = Lines[i].Y1; 
                    }                  
                    else
                    {
                        StartX = Lines[i].X2;
                        EndX = Lines[i].X1;
                        Change = Lines[i].Y2 < Lines[i].Y1 ? 1 : -1;
                        y = Lines[i].Y2;
                    }                   

                    for (int x = StartX; x < EndX + 1; x++)
                    {
                        if (Coordinates.TryGetValue((x, y), out int Value))
                        {
                            Coordinates[(x, y)] += 1;
                        }
                        else
                        {
                            Coordinates.Add((x, y), 1);
                        }
                        y += Change;
                    }
                }
            }

            int Overlaps = 0;
            foreach (KeyValuePair<(int, int), int> Coord in Coordinates)
            {
                if (Coord.Value > 1) Overlaps++;
            }

            Console.WriteLine(Overlaps);
            Console.ReadKey();
        }
    }
}
