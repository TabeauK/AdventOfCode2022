namespace AdventOfCode2022Library
{
    public class Stacks : IMyParsable<Stacks>
    {
        public List<Stack<char>> original = new();

        public List<Stack<char>> result = new();

        public List<Instructions> instructions = new();
        public static Stacks Parse(string s)
        {
            Stacks stacks = new();
            string[] rows = s.Split('\n');
            stacks.original.AddRange(from string number in rows[^1].Split(' ').Where(x => !string.IsNullOrEmpty(x))
                                     select new Stack<char>());
            for(int i = rows.Length - 2; i >= 0; i--)
            {
                string[] row = rows[i].Split(' ');
                int whitepsaces = 0;
                int stackIter = 0;
                for (int j = 0; j < row.Length; j++)
                {
                    if (string.IsNullOrEmpty(row[j]))
                    {
                        whitepsaces++;
                    }
                    else
                    {
                        stackIter += whitepsaces / 3;
                        stacks.original[stackIter].Push(row[j][1]);
                        whitepsaces = 0;
                        stackIter++;
                    }
                }
            }

            stacks.Repopulate();
            return stacks;
        }

        public void Repopulate()
        {
            result.Clear();
            result.AddRange(original.Select(x => new Stack<char>(new Stack<char>(x))).ToList());
        }

        public void ApplyInstructions(bool CrateMover9001 = false)
        {
            foreach(Instructions instructions in instructions)
            {
                if (CrateMover9001)
                {
                    Stack<char> temp = new();
                    for (int i = 0; i < instructions.Count; i++)
                    {
                        temp.Push(result[instructions.From - 1].Pop());
                    }
                    for (int i = 0; i < instructions.Count; i++)
                    {
                        result[instructions.To - 1].Push(temp.Pop());
                    }
                } 
                else
                {
                    for (int i = 0; i < instructions.Count; i++)
                    {
                        result[instructions.To - 1].Push(result[instructions.From - 1].Pop());
                    }
                }
            }
        }

        public string GetResult => string.Concat(result.Select(x => x.Peek()));
    }
}
