using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022Library.Day3
{
    public class Rucksack
    {
        public Compartment left;
        public Compartment right;
        int[] mask = new int[53];

        public Rucksack(string items) 
        {
            left = new Compartment(items.Substring(0, items.Length / 2));
            right = new Compartment(items.Substring(items.Length / 2, items.Length / 2));
            for (int i = 1; i < 53; i++)
            {
                mask[i] = left[i] + right[i];
            }
        }

        public int GetWrongItem => Compartment.Compare(left, right);

        public int this[int i] => this.mask[i];

        public static int Compare(Rucksack rucksack, Rucksack other, Rucksack otherOther)
        {
            for (int i = 1; i < 53; i++)
            {
                if (rucksack[i] * other[i] * otherOther[i] > 0)
                {
                    return i;
                }
            }
            throw new NotSupportedException();
        }
    }
}
