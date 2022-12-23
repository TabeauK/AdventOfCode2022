using System.Text.RegularExpressions;

namespace AdventOfCode2022Library
{
    public class ForceField
    {
        public char Sign = '.';

        public ForceField? Up;

        public ForceField? Down;

        public ForceField? Left;

        public ForceField? Right;

        public int UpChangeDirection = 0;

        public int DownChangeDirection = 0;

        public int LeftChangeDirection = 0;

        public int RightChangeDirection = 0;

        public int Column;

        public int Row;
    }
}

