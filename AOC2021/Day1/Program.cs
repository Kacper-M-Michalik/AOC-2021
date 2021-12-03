using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
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

            int Increases = 0;
            for (int i = 0; i < Lines.Length - 1; i++)
            {
                if (Convert.ToInt32(Lines[i + 1]) > Convert.ToInt32(Lines[i])) Increases++;
            }

            Console.WriteLine("1: " + Increases.ToString());
            Console.ReadKey();
        }

        static void Part2()
        {
            string[] Lines = System.IO.File.ReadAllLines("Data.txt");
            List<int> Input = new List<int>();

            for (int i = 0; i < Lines.Length; i++)
            {
                Input.Add(Convert.ToInt32(Lines[i]));
            }

            int Increases = 0;
            int PreviousSum = Input[0] + Input[1] + Input[2];
            for (int i = 1; i < Input.Count - 2; i++)
            {
                int Sum = Input[i] + Input[i + 1] + Input[i + 2];
                if (Sum > PreviousSum) Increases++;
                PreviousSum = Sum;
            }

            Console.WriteLine(Increases);
            Console.ReadKey();
        }

    }
}
