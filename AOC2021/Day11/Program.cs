using System;

namespace Day11
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

            int[,] Data = new int[Lines[0].Length, Lines.Length]; 

            for (int y = 0; y < Lines.Length; y++)
            {
                for (int x = 0; x < Lines[y].Length; x++)
                {
                    Data[x, y] = Convert.ToInt32(Lines[y][x].ToString());
                }
            }

            long Flashes = 0;
            for (int i = 0; i < 100; i++)
            {
                for (int y = 0; y < Lines.Length; y++)
                {
                    for (int x = 0; x < Lines[y].Length; x++)
                    {
                        Data[x, y]++;
                    }
                }

                bool WasFlash = true;
                while (WasFlash)
                {
                    WasFlash = false;
                    for (int y = 0; y < Lines.Length; y++)
                    {
                        for (int x = 0; x < Lines[y].Length; x++)
                        {
                            if (Data[x,y] > 9)
                            {
                                WasFlash = true;
                                Flashes++;
                                Data[x, y] = -9;

                                if (x > 0) Data[x - 1, y]++;
                                if (y > 0) Data[x, y - 1]++;
                                if (x < Data.GetLength(0) - 1) Data[x + 1, y]++;
                                if (y < Data.GetLength(1) - 1) Data[x, y + 1]++;

                                if (x > 0 && y > 0) Data[x - 1, y - 1]++;
                                if (y > 0 && x < Data.GetLength(0) - 1) Data[x + 1, y - 1]++;
                                if (x > 0 && y < Data.GetLength(1) - 1) Data[x - 1, y + 1]++;
                                if (y < Data.GetLength(1) - 1 && x < Data.GetLength(1) - 1) Data[x + 1, y + 1]++;
                            } 
                        }
                    }
                }

                for (int y = 0; y < Lines.Length; y++)
                {
                    for (int x = 0; x < Lines[y].Length; x++)
                    {
                        if (Data[x, y] < 0) Data[x, y] = 0;
                    }
                }

            }

            Console.WriteLine(Flashes);
            Console.ReadLine();

        }

        static void Part2()
        {
            string[] Lines = System.IO.File.ReadAllLines("Data.txt");

            int[,] Data = new int[Lines[0].Length, Lines.Length];

            for (int y = 0; y < Lines.Length; y++)
            {
                for (int x = 0; x < Lines[y].Length; x++)
                {
                    Data[x, y] = Convert.ToInt32(Lines[y][x].ToString());
                }
            }

            long Flashes = 0;
            int i = 0;
            while (true)
            {
                for (int y = 0; y < Lines.Length; y++)
                {
                    for (int x = 0; x < Lines[y].Length; x++)
                    {
                        Data[x, y]++;
                    }
                }

                bool WasFlash = true;
                while (WasFlash)
                {
                    WasFlash = false;
                    for (int y = 0; y < Lines.Length; y++)
                    {
                        for (int x = 0; x < Lines[y].Length; x++)
                        {
                            if (Data[x, y] > 9)
                            {
                                WasFlash = true;
                                Flashes++;
                                Data[x, y] = -9;

                                if (x > 0) Data[x - 1, y]++;
                                if (y > 0) Data[x, y - 1]++;
                                if (x < Data.GetLength(0) - 1) Data[x + 1, y]++;
                                if (y < Data.GetLength(1) - 1) Data[x, y + 1]++;

                                if (x > 0 && y > 0) Data[x - 1, y - 1]++;
                                if (y > 0 && x < Data.GetLength(0) - 1) Data[x + 1, y - 1]++;
                                if (x > 0 && y < Data.GetLength(1) - 1) Data[x - 1, y + 1]++;
                                if (y < Data.GetLength(1) - 1 && x < Data.GetLength(1) - 1) Data[x + 1, y + 1]++;
                            }
                        }
                    }
                }

                bool NotFlashed = false;
                for (int y = 0; y < Lines.Length; y++)
                {
                    for (int x = 0; x < Lines[y].Length; x++)
                    {
                        if (Data[x, y] < 0) Data[x, y] = 0;
                        else NotFlashed = true;
                    }
                }
                i++;

                if (!NotFlashed)
                {
                    Console.WriteLine(i);
                    return;
                }

            }

            Console.ReadLine();
        }
    }
}
