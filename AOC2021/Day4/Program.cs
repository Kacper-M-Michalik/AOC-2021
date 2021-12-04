using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        public class Board
        {
            public int[,] Values;
            public bool[,] IsGuessed;

            public Board(int[,] NewValues, bool[,] NewIsGuessed)
            {
                Values = NewValues;
                IsGuessed = NewIsGuessed;
            }

            public void Guess(int Number)
            {
                for (int y = 0; y < IsGuessed.GetLength(1); y++)
                {
                    for (int x = 0; x < IsGuessed.GetLength(0); x++)
                    {
                        if (Values[x, y] == Number) IsGuessed[x,y] = true;
                    }
                }
            }

            public int Score(int Multiplier)
            {
                int Sum = 0;
                for (int y = 0; y < IsGuessed.GetLength(1); y++)
                {
                    for (int x = 0; x < IsGuessed.GetLength(0); x++)
                    {
                        if (IsGuessed[x, y] == false) Sum += Values[x, y];
                    }
                }
                return Sum * Multiplier;
            }

            public bool IsBoardComplete()
            {
                for (int y = 0; y < IsGuessed.GetLength(1); y++)
                {
                    bool IsComplete = true;

                    for (int x = 0; x < IsGuessed.GetLength(0); x++)
                    {
                        if (IsGuessed[x, y] == false) IsComplete = false;
                    }

                    if (IsComplete) return true;
                }

                for (int x = 0; x < IsGuessed.GetLength(0); x++)
                {
                    bool IsComplete = true;

                    for (int y = 0; y < IsGuessed.GetLength(1); y++)
                    {
                        if (IsGuessed[x, y] == false) IsComplete = false;
                    }

                    if (IsComplete) return true;
                }

                return false;
            }
        }

        static void Part1()
        {
            string[] Lines = System.IO.File.ReadAllLines("Data.txt");

            string[] DrawnStrings = Lines[0].Split(',');
            List<int> DrawnValues = new List<int>();

            for (int i = 0; i < DrawnStrings.Length; i++)
            {
                DrawnValues.Add(Convert.ToInt32(DrawnStrings[i]));
            }

            List<Board> Boards = new List<Board>();

            int BoardSize = 5;

            for (int i = 2; i < Lines.Length; i+=BoardSize+1)
            {
                Board CurrentBoard = new Board(new int[BoardSize, BoardSize], new bool[BoardSize, BoardSize]);
                for (int y = 0; y < BoardSize; y++)
                {
                    string[] Values = Lines[i+y].Split(' ');
                    int x = 0;

                    for (int k = 0; k < Values.Length; k++)
                    {
                        if (Values[k] != "")
                        {
                            CurrentBoard.Values[x, y] = Convert.ToInt32(Values[k]);
                            CurrentBoard.IsGuessed[x, y] = false;
                            x++;
                        }
                    }
                }
                Boards.Add(CurrentBoard);

            }

            int WinningBoardScore = 0;

            for (int i = 0; i < DrawnValues.Count; i++)
            {
                for (int j = 0; j < Boards.Count; j++)
                {
                    Boards[j].Guess(DrawnValues[i]);
                    if (Boards[j].IsBoardComplete())
                    {
                        WinningBoardScore = Boards[j].Score(DrawnValues[i]);
                        i = DrawnValues.Count;
                        j = Boards.Count;
                    }

                }
            }

            Console.WriteLine(WinningBoardScore);
            Console.ReadKey();
        }
        
        static void Part2()
        {
            string[] Lines = System.IO.File.ReadAllLines("Data.txt");

            string[] DrawnStrings = Lines[0].Split(',');
            List<int> DrawnValues = new List<int>();

            for (int i = 0; i < DrawnStrings.Length; i++)
            {
                DrawnValues.Add(Convert.ToInt32(DrawnStrings[i]));
            }

            List<Board> Boards = new List<Board>();

            int BoardSize = 5;

            for (int i = 2; i < Lines.Length; i += BoardSize + 1)
            {
                Board CurrentBoard = new Board(new int[BoardSize, BoardSize], new bool[BoardSize, BoardSize]);
                for (int y = 0; y < BoardSize; y++)
                {
                    string[] Values = Lines[i + y].Split(' ');
                    int x = 0;

                    for (int k = 0; k < Values.Length; k++)
                    {
                        if (Values[k] != "")
                        {
                            CurrentBoard.Values[x, y] = Convert.ToInt32(Values[k]);
                            CurrentBoard.IsGuessed[x, y] = false;
                            x++;
                        }
                    }
                }
                Boards.Add(CurrentBoard);

            }

            int LastWinningScore = 0;

            for (int i = 0; i < DrawnValues.Count; i++)
            {
                for (int j = 0; j < Boards.Count; j++)
                {
                    Boards[j].Guess(DrawnValues[i]);
                    if (Boards[j].IsBoardComplete())
                    {
                        if (Boards.Count == 1)
                        {
                            LastWinningScore = Boards[j].Score(DrawnValues[i]);
                            i = DrawnValues.Count;
                            j = Boards.Count;
                        }
                        else
                        {
                            Boards.RemoveAt(j);
                            j--;
                        }
                    }

                }
            }


            Console.WriteLine(LastWinningScore);
            Console.ReadKey();
        }
    }
}
