using System;
using System.Collections.Generic;

namespace Day16
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        public class IntPointer
        {
            public long Value;
            public IntPointer(long NewValue)
            {
                Value = NewValue;
            }
        }

        static void Part1()
        {
            string[] Lines = System.IO.File.ReadAllLines("Data.txt");
            Packet Data = new Packet(Lines[0]);

            void ReadPacket(IntPointer ResultPointer)
            {
                long PacketVersion = Data.ReadInt3();
                long PacketType = Data.ReadInt3();
                ResultPointer.Value += PacketVersion;

                if (PacketType != 4)
                {
                    long LengthID = Data.ReadIntCustom(1);
                    if (LengthID == 0)
                    {
                        long SubPacketsBitCount = Data.ReadIntCustom(15);
                        long CurrentPointer = Data.ReadPointerPosition;
                        while (Data.ReadPointerPosition < CurrentPointer + SubPacketsBitCount)
                        {
                            ReadPacket(ResultPointer);
                        }
                    }
                    else
                    {
                        long SubPacketCount = Data.ReadIntCustom(11);
                        for (int i = 0; i < SubPacketCount; i++)
                        {
                            ReadPacket(ResultPointer);
                        }
                    }
                }
                else
                {
                    Data.ReadLiteral();
                }
            }

            IntPointer Pointer = new IntPointer(0);
            ReadPacket(Pointer);
            Console.WriteLine(Pointer.Value);
        }

        static void Part2()
        {
            string[] Lines = System.IO.File.ReadAllLines("Data.txt");
            Packet Data = new Packet(Lines[0]);

            long ReadPacket()
            {
                long PacketVersion = Data.ReadInt3();
                long PacketType = Data.ReadInt3();

                if (PacketType != 4)
                {
                    long LengthID = Data.ReadIntCustom(1);
                    long TotalSubPacketResult = 0;
                    if (PacketType == 2) TotalSubPacketResult = long.MaxValue;
                    else if (PacketType == 3 || PacketType == 1) TotalSubPacketResult = long.MinValue;

                    if (LengthID == 0)
                    {
                        long SubPacketsBitCount = Data.ReadIntCustom(15);
                        long CurrentPointer = Data.ReadPointerPosition;

                        if (PacketType == 5 || PacketType == 6 || PacketType == 7)
                        {
                            TotalSubPacketResult = PacketBooleanOperation(PacketType, ReadPacket(), ReadPacket());
                        }
                        else
                        {
                            while (Data.ReadPointerPosition < CurrentPointer + SubPacketsBitCount)
                            {
                                TotalSubPacketResult = PacketMathOperation(PacketType, TotalSubPacketResult, ReadPacket());
                            }
                        }
                        
                    }
                    else
                    {
                        int SubPacketCount = (int)Data.ReadIntCustom(11);
                        if (PacketType == 5 || PacketType == 6 || PacketType == 7)
                        {
                            TotalSubPacketResult = PacketBooleanOperation(PacketType, ReadPacket(), ReadPacket());
                        }
                        else
                        {
                            for (int i = 0; i < SubPacketCount; i++)
                            {
                                TotalSubPacketResult = PacketMathOperation(PacketType, TotalSubPacketResult, ReadPacket());
                            }                        
                        }
                    }
                    return TotalSubPacketResult;
                }
                else
                {
                    return Data.ReadLiteral();
                }
            }

            long PacketMathOperation(long PacketType, long CalculatedValue, long Value)
            {
                switch (PacketType)
                {
                    case 0:
                        CalculatedValue += Value;
                        break;
                    case 1:
                        if (CalculatedValue == long.MinValue) CalculatedValue = Value;
                        else CalculatedValue *= Value;
                        break;
                    case 2:
                        if (Value < CalculatedValue) CalculatedValue = Value;
                        break;
                    case 3:
                        if (Value > CalculatedValue) CalculatedValue = Value;
                        break;                    
                    default:
                        throw new Exception();

                }
                return CalculatedValue;
            }
            long PacketBooleanOperation(long PacketType, long Left, long Right)
            {
                switch (PacketType)
                {
                    case 5:
                        if (Left > Right) return 1;
                        break;
                    case 6:
                        if (Left < Right) return 1;
                        break;
                    case 7:
                        if (Left == Right) return 1;
                        break;
                    default:
                        throw new Exception();

                }
                return 0;
            }

            long Result = ReadPacket();
            Console.WriteLine(Result);
        }
    }
}
