using System.Text;

namespace AdventOfCode2022Library
{
    public class SNAFU: IMyParsable<SNAFU>
    {
        private string? snafu;

        private long? integer;

        public long Int
        {
            get
            {
                if (integer is null)
                {
                    integer = Enumerable
                        .Range(0, snafu!.Length)
                        .Sum(i =>
                            (long)Math.Pow(5, i) * (snafu[^(i + 1)] switch
                            {
                                '=' => -2,
                                '-' => -1,
                                '0' => 0,
                                '1' => 1,
                                '2' => 2,
                                _ => throw new NotSupportedException()
                            }));
                }
                return integer!.Value;
            }
            init
            {
                integer = value;
            }
        }

        public string Snafu
        {
            get
            {
                if (snafu is null)
                {
                    long temp = integer!.Value;
                    StringBuilder builder = new();
                    while(temp > 0)
                    {
                        temp += 2;
                        builder.Append((temp % 5) switch
                        {
                            0 => '=',
                            1 => '-',
                            2 => '0',
                            3 => '1',
                            4 => '2',
                            _ => throw new NotSupportedException(),
                        });
                        temp /= 5;
                    }
                    snafu = new string(builder.ToString().Reverse().ToArray());
                }
                return snafu!;
            }
            init
            {
                snafu = value;
            }
        }

        public static SNAFU Parse(string s)
        {
            return new SNAFU()
            {
                Snafu = s
            };
        }
    }
}

