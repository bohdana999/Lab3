using System;

namespace lab3
{
    class Program
    {
        private const int PAIR_LENGTH = 4800;
        private const int BREAK_LENGTH = 20 * 60;
        private const int SMALL_BREAK_LENGTH = 10 * 60;
        private const int PAIR_START = 28800;
        private const int FIRST_PAIR = PAIR_START + PAIR_LENGTH;
        private const int FIRST_BREAK = FIRST_PAIR + BREAK_LENGTH;
        private const int SECOND_PAIR = FIRST_BREAK + PAIR_LENGTH;
        private const int SECOND_BREAK = SECOND_PAIR + BREAK_LENGTH;
        private const int THIRD_PAIR = SECOND_BREAK + PAIR_LENGTH;
        private const int THIRD_BREAK = THIRD_PAIR + BREAK_LENGTH;
        private const int FOURTH_PAIR = THIRD_BREAK + PAIR_LENGTH;
        private const int FOURTH_BREAK = FOURTH_PAIR + BREAK_LENGTH;
        private const int FIFTH_PAIR = FOURTH_BREAK + PAIR_LENGTH;
        private const int FIFTH_BREAK = FIFTH_PAIR + SMALL_BREAK_LENGTH;
        private const int SIXTH_PAIR = FIFTH_BREAK + PAIR_LENGTH;
        private const string TOO_EARLY = "пари ще не почалися";
        private const string TOO_LATE = "пари вже скінчилися";


        static void Main(string[] args)
        {
            var t1 = new MyTime(0, 0, 65);
            var t2 = new MyTime(0, 0, 3601);
            var t3 = new MyTime(0, 62, 3601);
            var t4 = new MyTime(15, 62, 3601);
            var t5 = new MyTime(23, 62, 3601);
            var t6 = new MyTime(49, 62, 3601);

            MyTime t = new MyTime(16, 25, 56);

            var s = TimeSinceMidnight(new MyTime(8, 0, 0));

            var sec = AddOneSecond(t);
            var min = AddOneMinute(t);
            var hour = AddOneHour(t);
            var seconds = AddSeconds(t, -3600 * 17);

            var diff = Difference(t, t4);
            var diff1 = Difference(t, t5);

            var l = WhatLesson(new MyTime(7, 59, 25));
            var l2 = WhatLesson(new MyTime(8, 0, 0));
            var l3 = WhatLesson(new MyTime(9, 33, 46));
            var l4 = WhatLesson(new MyTime(10, 52, 78));
            var l5 = WhatLesson(new MyTime(11, 16,  17));
            var l6 = WhatLesson(new MyTime(12, 0, 54));
            var l7 = WhatLesson(new MyTime(12, 55, 4));
            var l8 = WhatLesson(new MyTime(13, 49, 29));
            var l9 = WhatLesson(new MyTime(14, 20, 00));
            var l10 = WhatLesson(new MyTime(15, 0, 34));
            var l11 = WhatLesson(new MyTime(16, 05, 11));
            var l12 = WhatLesson(new MyTime(17, 26, 48));
            var l13 = WhatLesson(new MyTime(20, 11, 21));
        }

        static int TimeSinceMidnight(MyTime t)
        {
            return t.Hours * MyTime.S_H + t.Minutes * MyTime.S_M + t.Seconds;
        }

        static MyTime TimeSinceMidnight(int seconds)
        {
            return new MyTime(0, 0, seconds);
        }

        static MyTime AddOneSecond(MyTime t)
        {
            return new MyTime(t.Hours, t.Minutes, t.Seconds + 1);
        }

        static MyTime AddOneMinute(MyTime t)
        {
            return new MyTime(t.Hours, t.Minutes + 1, t.Seconds);
        }

        static MyTime AddOneHour(MyTime t)
        {
            return new MyTime(t.Hours + 1, t.Minutes, t.Seconds);
        }

        static MyTime AddSeconds(MyTime t, int seconds)
        {
            return new MyTime(t.Hours, t.Minutes, t.Seconds + seconds);
        }

        static int Difference(MyTime mt1, MyTime mt2)
        {
            return TimeSinceMidnight(mt1) - TimeSinceMidnight(mt2);
        }

        static string WhatLesson(MyTime mt)
        {
            int sec = TimeSinceMidnight(mt);

            if (sec < PAIR_START)
                return TOO_EARLY;

            if (sec >= PAIR_START && sec < FIRST_PAIR)
                return GeneratePairName(1);
            if (sec >= FIRST_PAIR && sec < FIRST_BREAK)
                return GenerateBreakName(1);

            if (sec >= FIRST_BREAK && sec < SECOND_PAIR)
                return GeneratePairName(2);
            if (sec >= SECOND_PAIR && sec < SECOND_BREAK)
                return GenerateBreakName(2);

            if (sec >= SECOND_BREAK && sec < THIRD_PAIR)
                return GeneratePairName(3);
            if (sec >= THIRD_PAIR && sec < THIRD_BREAK)
                return GenerateBreakName(3);

            if (sec >= THIRD_BREAK && sec < FOURTH_PAIR)
                return GeneratePairName(4);
            if (sec >= FOURTH_PAIR && sec < FOURTH_BREAK)
                return GenerateBreakName(4);

            if (sec >= FOURTH_BREAK && sec < FIFTH_PAIR)
                return GeneratePairName(5);
            if (sec >= FIFTH_PAIR && sec < FIFTH_BREAK)
                return GenerateBreakName(5);

            if (sec >= FIFTH_BREAK && sec < SIXTH_PAIR)
                return GeneratePairName(6);

            return TOO_LATE;
        }

        static string GeneratePairName(int num)
        {
            return num + "-" + (num == 3 ? "я" : "а") + " пара";
        }

        static string GenerateBreakName(int pair)
        {
            return $"перерва між {pair}-ю та {++pair}-ю парами";
        }
    }
}