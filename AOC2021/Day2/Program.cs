using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
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

            int X = 0;
            int Y = 0;

            for (int i = 0; i < Lines.Length; i++)
            {
                string[] Input = Lines[i].Split(' ');
                int MovementFactor = Convert.ToInt32(Input[1]);
                
                if (Input[0] == "forward")
                {
                    X += MovementFactor;
                }
                else if (Input[0] == "down")
                {
                    Y += MovementFactor;
                }
                else //Up 
                {
                    Y -= MovementFactor;
                }
            }

            Console.WriteLine(X*Y);
            Console.ReadKey();
        }

        static void Part2()
        {
            string[] Lines = System.IO.File.ReadAllLines("Data.txt");

            int Aim = 0;
            int X = 0;
            int Y = 0;

            for (int i = 0; i < Lines.Length; i++)
            {
                string[] Input = Lines[i].Split(' ');
                int MovementFactor = Convert.ToInt32(Input[1]);

                if (Input[0] == "forward")
                {
                    X += MovementFactor;
                    Y += Aim * MovementFactor;
                }
                else if (Input[0] == "down")
                {
                    Aim += MovementFactor;
                }
                else //Up 
                {
                    Aim -= MovementFactor;
                }
            }

            Console.WriteLine(X * Y);
            Console.ReadKey();




        }

    }
}
