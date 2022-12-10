using System.Text;

namespace AdventOfCode2022Library
{
    public class Processor
    {
        public List<Command> commands = new();

        public List<int> registerX = new() { 1 };

        public void ExecuteCommands()
        {
            foreach (Command command in commands)
            {
                for (int i = 0; i < command.Cycles - 1; i++)
                {
                    registerX.Add(registerX.Last());
                }
                registerX.Add(registerX.Last() + command.AddValue);
            }
        }

        public int GetRegisterStrengthInKeyMoments(List<int> moments)
        {
            return moments.Sum(x => registerX[x - 1] * x);
        }

        public List<string> GetPattern()
        {
            List<string> pattern = new();
            for(int i = 0; i < 6; i++)
            {
                StringBuilder sb = new();
                for(int j = 0; j < 40; j++)
                {
                    sb.Append(Math.Abs(registerX[i * 40 + j] - j) <= 1 ?
                        '#' : '.');
                }
                pattern.Add(sb.ToString());
            }
            return pattern;
        }
    }
}
