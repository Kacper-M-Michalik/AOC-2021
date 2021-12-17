using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Day16
{
    public class Packet
    {
        string ReadBuffer;
        public int ReadPointerPosition;

        public Packet(string Data)
        {
            ReadPointerPosition = 0;
            ReadBuffer = "";

            for (int i = 0; i < Data.Length; i++)
            {
                ReadBuffer += Convert.ToString(Convert.ToInt32(Data[i].ToString(), 16), 2).PadLeft(4,'0');
            }
        }

        public long ReadInt3(bool MovePointer = true)
        {
            long Result = Convert.ToInt64(ReadBuffer.Substring(ReadPointerPosition, 3), 2);
            if (MovePointer) ReadPointerPosition += 3;
            return Result;
        }

        public long ReadIntCustom(int Length, bool MovePointer = true)
        {
            long Result = Convert.ToInt64(ReadBuffer.Substring(ReadPointerPosition, Length), 2);
            if (MovePointer) ReadPointerPosition += Length;
            return Result;
        }

        public string ReadStringCustom(int Length, bool MovePointer = true)
        {
            string Result = ReadBuffer.Substring(ReadPointerPosition, Length);
            if (MovePointer) ReadPointerPosition += Length;
            return Result;
        }

        public long ReadLiteral()
        {
            string Result = "";
            bool EndReached = false;
            while (!EndReached)
            {
                string CurrentChunk = ReadStringCustom(5);
                Result += CurrentChunk.Substring(1);
                if (CurrentChunk[0] == '0') EndReached = true;
            }
            return Convert.ToInt64(Result, 2);
        }
    }
}
