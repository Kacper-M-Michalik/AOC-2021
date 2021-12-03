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

        static void Part2() 
        {

            static string CalculateGamma(string[] Lines)
            {
                int BinaryLength = 12;
                string Gamma = "";

                for (int i = 0; i < BinaryLength; i++)
                {
                    int Ones = 0;
                    int Zeroes = 0;

                    for (int j = 0; j < Lines.Length; j++)
                    {
                        if (Lines[j][i] == '1') Ones++;
                        else Zeroes++;
                    }

                    if (Ones > Zeroes || Ones == Zeroes)
                    {
                        Gamma += "1";
                    }
                    else if (Zeroes > Ones)
                    {
                        Gamma += "0";
                    }
                }
                return Gamma;
            }
            static string CalculateEpsilon(string[] Lines)
            {
                int BinaryLength = 12;
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

                    if (Ones > Zeroes || Ones == Zeroes)
                    {
                        Epsilon += "0";
                    }
                    else if (Zeroes > Ones)
                    {
                        Epsilon += "1";
                    }
                }
                return Epsilon;
            }

            string[] Lines = System.IO.File.ReadAllLines("Data.txt");

            string Gamma = CalculateGamma(Lines);

            int SearchIndex = 0;
            List<string> PossibleValuesPrev = new List<string>(Lines);
            List<string> PossibleValuesNew = new List<string>();

            while (PossibleValuesPrev.Count != 1)
            {
                for (int i = 0; i < PossibleValuesPrev.Count; i++)
                {
                    if (PossibleValuesPrev[i][SearchIndex] == Gamma[SearchIndex]) PossibleValuesNew.Add(PossibleValuesPrev[i]);
                }
                PossibleValuesPrev = PossibleValuesNew;
                PossibleValuesNew = new List<string>();
                SearchIndex++;
                Gamma = CalculateGamma(PossibleValuesPrev.ToArray());
            }
            int OxygenValue = Convert.ToInt32(PossibleValuesPrev[0], 2);

            string Epsilon = CalculateEpsilon(Lines);
            SearchIndex = 0;
            PossibleValuesPrev = new List<string>(Lines);
            PossibleValuesNew = new List<string>();

            while (PossibleValuesPrev.Count != 1)
            {
                for (int i = 0; i < PossibleValuesPrev.Count; i++)
                {
                    if (PossibleValuesPrev[i][SearchIndex] == Epsilon[SearchIndex]) PossibleValuesNew.Add(PossibleValuesPrev[i]);
                }
                PossibleValuesPrev = PossibleValuesNew;
                PossibleValuesNew = new List<string>();
                SearchIndex++;
                Epsilon = CalculateEpsilon(PossibleValuesPrev.ToArray());
            }
            int CarbonValue = Convert.ToInt32(PossibleValuesPrev[0], 2);


            Console.WriteLine(OxygenValue*CarbonValue);
            Console.ReadKey();




        }


    }
}
