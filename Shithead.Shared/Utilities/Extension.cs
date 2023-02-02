using System;
using System.Collections.Generic;
using System.Threading;

namespace Shithead.Shared.Utilities
{
    static class Extension
    {
        #region Random

        [ThreadStatic] private static Random Local;

        /// <summary>
        /// Returns a pseudo-random generator based on the number of milliseconds elapsed sinc the system started and
        /// the unique identifier for the current managed thread.
        /// </summary>
        private static Random ThisThreadsRandom => Local ??= new Random(unchecked((Environment.TickCount * 31) + Thread.CurrentThread.ManagedThreadId));

        /// <summary>
        /// Extation class for random shuffling a list.
        /// Algorithm origin: https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
        /// </summary>
        public static void Shuffle<T>(this List<T> list)
        {
            int lc = list.Count;
            while (lc > 1)
            {
                lc--;
                int r = ThisThreadsRandom.Next(lc + 1);
                T value = list[r];
                list[r] = list[lc];
                list[lc] = value;
            }
        }

        #endregion

        /// <summary>
        /// Number to words
        /// Origin: https://stackoverflow.com/a/2730393/6572268
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string NumberToWords(this int number)
        {
            if (number == 0) return "zero";

            if (number < 0) return "minus " + NumberToWords(Math.Abs(number));

            string words = string.Empty;

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "") words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20) words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }
    }
}
