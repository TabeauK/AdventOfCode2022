using System.Linq;

namespace AdventOfCode2022Library
{
    public class Cube : IMyParsable<Cube>
    {
        public HashSet<int> Points = new();

        public readonly List<int> Directions = new()
        {
            1,
            -1,
            (1 << 5),
            -(1 << 5),
            (1 << 10),
            -(1 << 10),
        };

        public static Cube Parse(string s)
        {
            Cube cube = new();
            foreach (string point in s.Split('\n'))
            {
                int temp = int.Parse(point.Split(',')[0]);
                temp += int.Parse(point.Split(',')[1]) * (1 << 5);
                temp += int.Parse(point.Split(',')[2]) * (1 << 10);
                cube.Points.Add(temp);
            }

            return cube;
        }

        public int Sides => Points.Sum(x => Directions.Where(y => !Points.Contains(y + x)).Count());

        public int Droplets()
        {
            HashSet<int> droplets = new();
            foreach (int point in Points)
            {
                foreach (int potentialDroplet in Directions.Select(x => x + point))
                {
                    if (!Points.Contains(potentialDroplet) &&
                        !droplets.Contains(potentialDroplet) &&
                        Search(potentialDroplet))
                    {
                        droplets.Add(potentialDroplet);
                    }
                }
            }
            int count = 0;
            foreach (int point in droplets)
            {
                foreach (int potentialDroplet in Directions.Select(x => x + point))
                {
                    if(Points.Contains(potentialDroplet))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public bool Search(int pDroplet)
        {
            Stack<int> stack = new();
            HashSet<int> closed = new();
            stack.Push(pDroplet);
            while(stack.Count > 0)
            {
                int temp = stack.Pop();
                closed.Add(temp);
                foreach(int n in Directions
                    .Select(x => x + temp)
                    .Where(x => !Points.Contains(x) && !closed.Contains(x)))
                {
                    if (n % 32 == 0 || n % 32 == 0 ||
                        (n / 32) % 32 == 0 || (n / 32) % 32 == 0 ||
                        (n / 32 / 32) % 32 == 0 || (n / 32 / 32) % 32 == 0)
                    {
                        return false;
                    }
                    stack.Push(n);
                }
            }
            return true;
        }
    }
}

