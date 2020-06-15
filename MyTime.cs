using System;

namespace lab3
{
    public struct MyTime
    {
        public const int SEC_PER_DAY = 60 * 60 * 24;
        public const int S_M = 60;
        public const int S_H = 3600;
        public const int M_H = 60;

        public MyTime(int h, int m, int s)
        {
            int sec = h * S_H + m * S_M + s;
            sec = (sec % SEC_PER_DAY + SEC_PER_DAY) % SEC_PER_DAY;
            Hours = sec / S_H;
            Minutes = (sec / S_M) % S_M;
            Seconds = sec % S_M;
        }

        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }


        public override string ToString()
        {
            return $"{Hours}:{(Minutes < 10 ? "0" : "")}{Minutes}:{(Seconds < 10 ? "0" : "")}{Seconds}";
        }
    }
}