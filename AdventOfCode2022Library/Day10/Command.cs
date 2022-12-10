namespace AdventOfCode2022Library
{
    public class Command: IMyParsable<Command>
    {
        public int Cycles = 1;
        public int AddValue = 0;

        public static Command Parse(string s)
        {
            if(s.Split(' ')[0] == "addx")
            {
                return new Command()
                {
                    Cycles = 2,
                    AddValue = int.Parse(s.Split(' ')[1])
                };
            }
            return new Command();
        }
    }
}
