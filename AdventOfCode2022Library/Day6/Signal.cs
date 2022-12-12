using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022Library
{
    public class Signal : IMyParsable<Signal>
    {
        private string signal = "";
        public static Signal Parse(string s)
        {
            return new Signal()
            {
                signal = s
            };
        }

        private int FindStart(int distinctCount)
        {
            int startBuffor = 0;
            int endBuffor = 0;
            while (endBuffor - startBuffor + 1 < distinctCount && endBuffor < signal.Length - 1)
            {
                int index = signal
                    .Substring(startBuffor, endBuffor - startBuffor + 1)
                    .ToList()
                    .FindIndex(x => x == signal[endBuffor + 1]);
                if (index >= 0)
                {
                    startBuffor += index + 1;
                }
                endBuffor++;
            }
            return endBuffor + 1;
        }

        public int FindStartSignal => FindStart(4);

        public int FindStartMessage => FindStart(14);

    }
}
