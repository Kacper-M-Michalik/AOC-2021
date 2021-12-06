using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
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

            List<long> CycleDayToFish = new List<long>() {0,0,0,0,0,0,0,0,0};

            for (int i = 0; i < Input.Length; i++)
            {
                int Days = Convert.ToInt32(Input[i]);
                CycleDayToFish[Days] += 1;
            }

            for (int i = 0; i < 80; i++)
            {
                long CarryOver = CycleDayToFish[8];
                for (int j = 8; j > 0; j--)
                {
                    long Temp = CycleDayToFish[j - 1];
                    CycleDayToFish[j - 1] = CarryOver;
                    CarryOver = Temp;
                }
                CycleDayToFish[8] = CarryOver;
                CycleDayToFish[6] += CarryOver;
            }

            long Total = 0;
            for (int i = 0; i < CycleDayToFish.Count; i++)
            {
                Total += CycleDayToFish[i];
            }

            Console.WriteLine(Total);
            Console.ReadKey();
        }

        static void Part2()
        {
            string[] Input = System.IO.File.ReadAllLines("Data.txt")[0].Split(',');

            List<long> CycleDayToFish = new List<long>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < Input.Length; i++)
            {
                int Days = Convert.ToInt32(Input[i]);
                CycleDayToFish[Days] += 1;
            }

            for (int i = 0; i < 256; i++)
            {
                long CarryOver = CycleDayToFish[8];
                for (int j = 8; j > 0; j--)
                {
                    long Temp = CycleDayToFish[j - 1];
                    CycleDayToFish[j - 1] = CarryOver;
                    CarryOver = Temp;
                }
                CycleDayToFish[8] = CarryOver;
                CycleDayToFish[6] += CarryOver;
            }

            long Total = 0;
            for (int i = 0; i < CycleDayToFish.Count; i++)
            {
                Total += CycleDayToFish[i];
            }

            Console.WriteLine(Total);
            Console.ReadKey();
        }

    }
}
