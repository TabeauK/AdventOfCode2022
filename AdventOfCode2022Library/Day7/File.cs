using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2022Library
{
    public class File : IMyParsable<File>
    {
        public int size;

        public string name = "";

        public string extension = "";
        public static File Parse(string s)
        {
            return new File()
            {
                size = int.Parse(s.Split(' ')[0]),
                name = s.Split(' ')[1].Split('.')[0],
                extension = s.Split(' ')[1].Split('.').Length > 1 ? s.Split(' ')[1].Split('.')[1] : ""
            };
        }
    }
}
