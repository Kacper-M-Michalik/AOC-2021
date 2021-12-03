using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
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

            int BinaryLength = 12;
            string Gamma = "";
            string Epsilon = "";

            for (int i = 0; i < BinaryLength; i++)
            {
                int Ones = 0;
                int Zeroes = 0;

                for (int j = 0; j < Lines.Length; j++)
                {
                    if (Lines[j][i] == '1') Ones++;
                    else Zeroes++;
                }

                if (Ones > Zeroes)
                {
                    Gamma += "1";
                    Epsilon += "0";
                }
                else
                {
                    Gamma += "0";
                    Epsilon += "1";
                }
            }

            Console.WriteLine(Convert.ToInt32(Epsilon,2)*Convert.ToInt32(Gamma,2));
            Console.ReadKey();
        }

        static void Part2() { }


    }
}
