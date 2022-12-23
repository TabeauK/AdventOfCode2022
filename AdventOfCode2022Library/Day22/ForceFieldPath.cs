using System.Text.RegularExpressions;

namespace AdventOfCode2022Library
{
    public partial class ForceFieldPath : IMyParsable<ForceFieldPath>
    {
        public List<(int, int)> Path = new();

        private int Direction = 0;

        private ForceField? Current = null;

        public ForceFieldMap? map;

        public static ForceFieldPath Parse(string s)
        {
            return new ForceFieldPath()
            {
                Path = DirectionRegex()
                .Matches(s)
                .Select(x => x.Value[^1] switch
                    {
                        'L' => (int.Parse(x.Value.Substring(0, x.Value.Length - 1)), -1),
                        'R' => (int.Parse(x.Value.Substring(0, x.Value.Length - 1)), 1),
                        _ => (int.Parse(x.Value), 0)
                    })
                .ToList()
            };
        }

        public int Walk()
        {
            Current = map!.StartField;
            foreach((int steps, int direction) in Path)
            {
                ForceField? next = Direction switch
                {
                    0 => Current!.Right,
                    1 => Current!.Down,
                    2 => Current!.Left,
                    3 => Current!.Up,
                    _ => throw new NotSupportedException()
                };
                for(int i = 0; i < steps && next!.Sign != '#'; i++)
                {
                    if(Current.Column != next.Column &&
                        Current.Row != next.Row)
                    {
                        Direction += Direction switch
                        {
                            0 => Current.RightChangeDirection,
                            1 => Current.DownChangeDirection,
                            2 => Current.LeftChangeDirection,
                            3 => Current.UpChangeDirection,
                            _ => throw new NotSupportedException()
                        };
                        Direction %= 4;
                    }
                    Current = next;
                    next = Direction switch
                    {
                        0 => Current.Right,
                        1 => Current.Down,
                        2 => Current.Left,
                        3 => Current.Up,
                        _ => throw new NotSupportedException()
                    };
                }
                Direction += direction + 4;
                Direction %= 4;
            }

            return Direction + Current!.Column * 4 + Current!.Row * 1000;
        }

        [GeneratedRegex("\\d+[L|R]?")]
        private static partial Regex DirectionRegex();
    }
}

