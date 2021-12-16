using System;
using System.Collections.Generic;

namespace Day16
{
    class Program
    {
        //ReadPacket
           //Read version
           //Read ID
           
        //if literal, calc




        static void Main(string[] args)
        {
            Part1();
        }

        static void Part1()
        {
            string[] Lines = System.IO.File.ReadAllLines("Data.txt");
            Packet Data = new Packet(Lines[0]);

            int SolvePacketVersion()
            {
                int PacketVersion = Data.ReadInt3();
                int PacketType = Data.ReadInt3();

                switch (PacketType)
                {
                    case 4:
                        break;
                    default:
                        int Type = Data.ReadIntCustom(1);
                        if (Type == 0)
                        {
                            int SubLength = Data.ReadIntCustom(15);
                        }
                        else
                        {
                            int SubpacketCount = Data.ReadIntCustom(11);
                        }
                        break;
                }

                return PacketVersion;
            }



            Console.WriteLine(Result);
        }
    }
}
