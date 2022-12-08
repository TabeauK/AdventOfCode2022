namespace AdventOfCode2022Library
{
    public interface IMyParsable<TSelf> where TSelf : IMyParsable<TSelf>?
    {
        static abstract TSelf Parse(string s);
    }
}
