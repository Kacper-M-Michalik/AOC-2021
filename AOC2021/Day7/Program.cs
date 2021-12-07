using System;
using System.Collections.Generic;

namespace Day7
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
            string[] Input = System.IO.File.ReadAllLines("Data.txt")[0].Split(',');
            int[] Crabs = new int[Input.Length];

            int HighestValue = 0;
            for (int i = 0; i < Input.Length; i++)
            {
                Crabs[i] = Convert.ToInt32(Input[i]);
                if (Crabs[i] > HighestValue) HighestValue = Crabs[i];
            }

            int LowestFuel = int.MaxValue;
            for (int i = 0; i < HighestValue; i++)
            {
                int TotalFuel = 0;
                for (int j = 0; j < Crabs.Length; j++)
                {
                    TotalFuel += Math.Abs(Crabs[j] - i);
                }
                if (TotalFuel < LowestFuel) LowestFuel = TotalFuel;
            }

            Console.WriteLine(LowestFuel);
            Console.ReadLine();

        }

        static void Part2()
        {
            string[] Input = System.IO.File.ReadAllLines("Data.txt")[0].Split(',');
            int[] Crabs = new int[Input.Length];

            int HighestValue = 0;
            for (int i = 0; i < Input.Length; i++)
            {
                Crabs[i] = Convert.ToInt32(Input[i]);
                if (Crabs[i] > HighestValue) HighestValue = Crabs[i];
            }

            int LowestFuel = int.MaxValue;
            for (int i = 0; i < HighestValue; i++)
            {
                int TotalFuel = 0;
                for (int j = 0; j < Crabs.Length; j++)
                { 
                    int Val = Math.Abs(Crabs[j] - i);
                    TotalFuel += (Val*(Val+1))/2;
                }
                if (TotalFuel < LowestFuel) LowestFuel = TotalFuel;
            }

            Console.WriteLine(LowestFuel);
            Console.ReadLine();
        }

        
    }
}
