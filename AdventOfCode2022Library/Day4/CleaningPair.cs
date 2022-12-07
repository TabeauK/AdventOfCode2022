using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022Library
{
    public class CleaningPair: IMyParsable<CleaningPair>
    {
        public (int min, int max) Elf1;
        public (int min, int max) Elf2;

        public static CleaningPair Parse(string s)
        {
            string[] elfs = s.Split(',');
            return new CleaningPair()
            {
                Elf1 = (int.Parse(elfs[0].Split('-')[0]), int.Parse(elfs[0].Split('-')[1])),
                Elf2 = (int.Parse(elfs[1].Split('-')[0]), int.Parse(elfs[1].Split('-')[1]))
            };
        }

        public bool DoesOneContainAnother => (Elf1.min <= Elf2.min && Elf1.max >= Elf2.max) ||
                                             (Elf1.min >= Elf2.min && Elf1.max <= Elf2.max);

        public bool Overlap => (Elf1.min >= Elf2.min && Elf1.min <= Elf2.max) ||
                               (Elf1.max >= Elf2.min && Elf1.max <= Elf2.max) || DoesOneContainAnother;
    }
}
