using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022Library
{
    public interface IMyParsable<TSelf> where TSelf : IMyParsable<TSelf>?
    {
        static abstract TSelf Parse(string s);
    }
}
