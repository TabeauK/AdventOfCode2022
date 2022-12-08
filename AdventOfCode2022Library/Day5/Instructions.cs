namespace AdventOfCode2022Library
{
    public class Instructions : IMyParsable<Instructions>
    {
        public int From;
        public int To;
        public int Count;
        public static Instructions Parse(string s)
        {
            return new Instructions()
            {
                To = int.Parse(s.Split(' ')[5]),
                From = int.Parse(s.Split(' ')[3]),
                Count = int.Parse(s.Split(' ')[1])
            };
        }
    }
}
