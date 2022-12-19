using System.Text.RegularExpressions;

namespace AdventOfCode2022Library
{
    public partial class Valve : IMyParsable<Valve>
    {
        public string Name = "";

        public List<string> Connections = new();

        public int Pressure = 0;

        public static Valve Parse(string s)
        {
            MatchCollection collection = MyRegexName().Matches(s);
            return new()
            {
                Name = collection[0].Value,
                Connections = collection.Skip(1).Select(x => x.Value).ToList(),
                Pressure = int.Parse(MyRegexPressure().Match(s).Value)
            };
        }

        public Valve Clone()
        {
            return new Valve()
            {
                Name = this.Name,
                Pressure = this.Pressure,
                Connections = this.Connections,
            };  
        }

        [GeneratedRegex("\\d+")]
        private static partial Regex MyRegexPressure();
        [GeneratedRegex("[A-Z][A-Z]")]
        private static partial Regex MyRegexName();
    }
}

