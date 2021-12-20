using System;
using System.Collections;
using System.Collections.Generic;

namespace Day15
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

            int[,] Map = new int[Lines[0].Length, Lines.Length];

            for (int y = 0; y < Lines.Length; y++)
            {
                for (int x = 0; x < Lines[y].Length; x++)
                {
                    Map[x, y] = Convert.ToInt32(Lines[y][x].ToString());
                }
            }

            DateTime StartTime = DateTime.UtcNow;
            Position Start = new Position(0, 0);
            Position Target = new Position(Lines[0].Length - 1, Lines.Length - 1);
            DisjkstraResult Result = Dijsktras(Map, Start, Target);

            Stack<Position> Positions = new Stack<Position>();
            if (Result.PreviousLookup[Target] != null)
            {
                while (Target != null)
                {
                    Positions.Push(Target);
                    Target = Result.PreviousLookup[Target];
                }
            }
            DateTime End = DateTime.UtcNow;
            Console.WriteLine("MS: " + (End.Millisecond - StartTime.Millisecond).ToString());

            long TotalRisk = 0;
            foreach (Position Pos in Positions)
            {
                if (!Pos.Equals(Start))
                {
                    TotalRisk += Map[Pos.X, Pos.Y];
                }
            }
            Console.WriteLine(TotalRisk);
        }

        static void Part2()
        {
            string[] Lines = System.IO.File.ReadAllLines("Data.txt");

            int BaseWidth = Lines[0].Length;
            int BaseHeight = Lines.Length;

            int[,] Map = new int[BaseWidth * 5, BaseHeight * 5];

            for (int y = 0; y < Lines.Length; y++)
            {
                for (int x = 0; x < Lines[y].Length; x++)
                {
                    int BaseValue = Convert.ToInt32(Lines[y][x].ToString());

                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            int ClampedValue = BaseValue + i + j;
                            if (ClampedValue > 9) ClampedValue -= 9;
                            Map[x + j * BaseWidth, y + i * BaseHeight] = ClampedValue;
                        }
                    }

                }
            }

            DateTime StartTime = DateTime.UtcNow;
            Position Start = new Position(0, 0);
            Position Target = new Position(Map.GetLength(0) - 1, Map.GetLength(1) - 1);
            DisjkstraResult Result = Dijsktras(Map, Start, Target);

            Stack<Position> Positions = new Stack<Position>();
            if (Result.PreviousLookup[Target] != null)
            {
                while (Target != null)
                {
                    Positions.Push(Target);
                    Target = Result.PreviousLookup[Target];
                }
            }
            DateTime End = DateTime.UtcNow;
            Console.WriteLine("S: " + (End.Second - StartTime.Second).ToString());

            long TotalRisk = 0;
            foreach (Position Pos in Positions)
            {
                if (!Pos.Equals(Start))
                {
                    TotalRisk += Map[Pos.X, Pos.Y];
                }
            }
            Console.WriteLine(TotalRisk);
        }

        public class Position : IEquatable<Position>
        {
            public int X;
            public int Y;
            public Position(int NewX, int NewY)
            {
                X = NewX;
                Y = NewY;
            }

            public bool Equals(Position Other)
            {
                return (Other.X == X) && (Other.Y == Y);
            }
            public override int GetHashCode()
            {
                int Calculation = X * X + Y * Y + X - Y;
                return Calculation.GetHashCode();
            }
        }

        public class DisjkstraResult
        {
            public Dictionary<Position, float> DistanceLookup;
            public Dictionary<Position, Position> PreviousLookup;

            public DisjkstraResult(Dictionary<Position, float> NewDL, Dictionary<Position, Position> NewPL)
            {
                DistanceLookup = NewDL;
                PreviousLookup = NewPL;
            }
        }

        static DisjkstraResult Dijsktras(int[,] Map, Position Start, Position End)
        {
            Dictionary<Position, float> Distance = new Dictionary<Position, float>();
            Dictionary<Position, Position> PreviousNode = new Dictionary<Position, Position>();
            HashSet<Position> UnvisitedNodes = new HashSet<Position>();

            for (int y = 0; y < Map.GetLength(1); y++)
            {
                for (int x = 0; x < Map.GetLength(0); x++)
                {
                    Distance.Add(new Position(x, y), float.PositiveInfinity);
                    PreviousNode.Add(new Position(x, y), null);
                }
            }

            Distance[Start] = 0;
            UnvisitedNodes.Add(Start);

            while (UnvisitedNodes.Count != 0)
            {
                Position Current = null;

                foreach (Position Pos in UnvisitedNodes)
                {
                    if (Current == null) Current = Pos;
                    else if (Distance[Pos] < Distance[Current]) Current = Pos;
                }

                UnvisitedNodes.Remove(Current);

                if (Current != End)
                {
                    Position NeighbourRight = new Position(Current.X + 1, Current.Y);
                    Position NeighbourUp = new Position(Current.X, Current.Y + 1);
                    Position NeighbourLeft = new Position(Current.X - 1, Current.Y);
                    Position NeighbourBottom = new Position(Current.X, Current.Y - 1);
                    int AltDistance = 0;

                    if (NeighbourRight.X < Map.GetLength(0))
                    {
                        AltDistance = (int)Math.Round(Distance[Current] + Map[NeighbourRight.X, NeighbourRight.Y]);
                        if (AltDistance < Distance[NeighbourRight])
                        {
                            Distance[NeighbourRight] = AltDistance;
                            PreviousNode[NeighbourRight] = Current;
                            UnvisitedNodes.Add(NeighbourRight);
                        }
                    }
                    if (NeighbourUp.Y < Map.GetLength(1))
                    {
                        AltDistance = (int)Math.Round(Distance[Current] + Map[NeighbourUp.X, NeighbourUp.Y]);
                        if (AltDistance < Distance[NeighbourUp])
                        {
                            Distance[NeighbourUp] = AltDistance;
                            PreviousNode[NeighbourUp] = Current;
                            UnvisitedNodes.Add(NeighbourUp);
                        }
                    }
                    if (NeighbourLeft.X >= 0)
                    {
                        AltDistance = (int)Math.Round(Distance[Current] + Map[NeighbourLeft.X, NeighbourLeft.Y]);
                        if (AltDistance < Distance[NeighbourLeft])
                        {
                            Distance[NeighbourLeft] = AltDistance;
                            PreviousNode[NeighbourLeft] = Current;
                            UnvisitedNodes.Add(NeighbourLeft);
                        }
                    }
                    if (NeighbourBottom.Y >= 0)
                    {
                        AltDistance = (int)Math.Round(Distance[Current] + Map[NeighbourBottom.X, NeighbourBottom.Y]);
                        if (AltDistance < Distance[NeighbourBottom])
                        {
                            Distance[NeighbourBottom] = AltDistance;
                            PreviousNode[NeighbourBottom] = Current;
                            UnvisitedNodes.Add(NeighbourBottom);
                        }
                    }
                }
                else
                {
                    return new DisjkstraResult(Distance, PreviousNode);
                }
            }

            return new DisjkstraResult(Distance, PreviousNode);
        }
    }
}
