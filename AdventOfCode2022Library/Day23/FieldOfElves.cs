namespace AdventOfCode2022Library
{
    public class FieldOfElves : IMyParsable<FieldOfElves>
    {
        List<(long, long)> Elves = new();

        public int NMost = 0;

        public int SMost = 0;

        public int WMost = 0;

        public int EMost = 0;

        public void Run()
        {

        };

        public static FieldOfElves Parse(string s)
        {
            FieldOfElves field = new();
            string[] lines = s.Split('\n');

            for(int i = 0; i < lines; i++)
            {
                for(int j = 0; j < lines[i]; j++)
                {
                    if (lines[i][j] == '#')
                    {
                        field.Elves.Add((i, j));
                        field.NMost = Math.Min(field.NMost, i);
                        field.WMost = Math.Min(field.WMost, j);
                        field.SMost = Math.Max(field.SMost, i);
                        field.EMost = Math.Max(field.EMost, j);
                    }
                }
            }
        }
    }
}

