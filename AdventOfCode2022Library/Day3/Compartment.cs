using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode2022Library.Day3
{
    public class Compartment
    {
        string text;
        int[] typesCount = new int[53];

        public Compartment(string items)
        {
            Array.Clear(typesCount, 0, typesCount.Length);
            this.text = items;
            foreach (char c in items)
            {
                if(char.IsUpper(c))
                {
                    typesCount[c - 'A' + 27]++;
                }
                else
                {
                    typesCount[c - 'a' + 1]++;
                }
            }
        }


        public int this[int i] => this.typesCount[i];

        public static int Compare(Compartment compartment, Compartment other)
        {
            for(int i = 1; i < 53; i++) 
            {
                if(compartment[i] * other[i] > 0)
                {
                    return i;
                }
            }
            throw new NotSupportedException();
        }
    }
}
