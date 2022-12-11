using System.Numerics;
using System.Security.Cryptography;

namespace AdventOfCode2022Library
{
    public class Monkey : IMyParsable<Monkey>
    {
        public static Dictionary<int, Monkey> monkeys = new();

        public static long Divider = 1;

        public int Id;

        public List<long> Items = new();

        public int ItemsInspected = 0;

        public char OP = '+';

        public int? FirstValue = null;

        public int? SecondValue = null;

        public int Compare = 1;

        public int Goto1 = 0;

        public int Goto2 = 0;

        public static void Clear()
        {
            monkeys.Clear();
            Divider = 1;
        }
        public static Monkey Parse(string s)
        {
            string[] lines = s.Split(';');
            Monkey monkey = new()
            {
                Id = int.Parse(
                    lines[0]
                        .Split(' ')[1]
                        .Split(':')[0]),
                Items = lines[1]
                    .Split(':')[1]
                    .Split(',')
                    .Select(x =>
                        long.Parse(x.Trim())
                    ).ToList(),
                Compare = int.Parse(lines[3].Split(' ')[^1]),
                Goto1 = int.Parse(lines[4].Split(' ')[^1]),
                Goto2 = int.Parse(lines[5].Split(' ')[^1])

            };

            if (lines[2].Split('=')[1].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList()[1] == "*")
            {
                monkey.OP = '*';
            }

            if (lines[2].Split('=')[1].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList()[0] != "old")
            {
                monkey.FirstValue = int.Parse(lines[2].Split('=')[1].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList()[0]);
            }

            if (lines[2].Split('=')[1].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList()[2] != "old")
            {
                monkey.SecondValue = int.Parse(lines[2].Split('=')[1].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList()[2]);
            }

            monkeys.Add(monkey.Id, monkey);

            Divider *= monkey.Compare;

            return monkey;
        }

        public long ConstructOperation(long old)
        {

            long firstValue;
            if (FirstValue.HasValue)
            {
                firstValue = FirstValue.Value;
            }
            else
            {
                firstValue = old;
            }

            long secondValue;
            if (SecondValue.HasValue)
            {
                secondValue = SecondValue.Value;
            }
            else
            {
                secondValue = old;
            }

            if (OP == '+')
            {
                return firstValue + secondValue;
            }
            else
            {
                return firstValue * secondValue;
            }
        }

        public static void PlayRounds(int count, bool relief = true)
        {
            for (int i = 0; i < count; i++)
            {
                foreach (Monkey monkey in Monkey.monkeys.Values)
                {
                    monkey.MakeRound(relief);
                }
            }
        }

        public void MakeRound(bool relief)
        {
            ItemsInspected += Items.Count;
            foreach (long item in Items)
            {
                long worryLevel = ConstructOperation(item);
                worryLevel %= Divider;
                if (relief)
                {
                    worryLevel /= 3;
                }
                if (worryLevel % Compare == 0)
                {
                    monkeys[Goto1].Items.Add(worryLevel);
                }
                else
                {
                    monkeys[Goto2].Items.Add(worryLevel);
                }
            }
            Items.Clear();
        }
    }
}
