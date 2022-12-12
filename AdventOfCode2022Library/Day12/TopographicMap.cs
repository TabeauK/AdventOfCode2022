namespace AdventOfCode2022Library
{
    public class TopographicMap: IMyParsable<TopographicMap>
    {
        public Dictionary<(int, int), char> Vericles = new();

        public Dictionary<(int, int), List<(int, int)>> Edges = new();

        public (int, int) Start;

        public List<(int, int)> Starts = new();

        public (int, int) End;

        public static TopographicMap Parse(string s)
        {
            TopographicMap map = new();
            string[] lines = s.Split(';');
            for(int i = 0; i < lines.Length; i++)
            {
                for(int j = 0; j < lines[0].Length; j++)
                {
                    if (lines[i][j] == 'S')
                    {
                        map.Start = (i, j);
                        map.Vericles.Add((i, j), 'a');
                        map.Starts.Add(map.Start);
                    }
                    else if(lines[i][j] == 'E')
                    {
                        map.End = (i, j);
                        map.Vericles.Add((i, j), 'z');
                    }
                    else if (lines[i][j] == 'a')
                    {
                        map.Starts.Add((i, j));
                        map.Vericles.Add((i, j), 'a');
                    }
                    else
                    {
                        map.Vericles.Add((i, j), lines[i][j]);
                    }
                }
            }

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[0].Length; j++)
                {
                    map.Edges.Add((i, j), new());
                    if(i > 0 && map.Vericles[(i - 1, j)] - map.Vericles[(i,j)] < 2)
                    {
                        map.Edges[(i, j)].Add((i - 1, j));
                    }
                    if (i < lines.Length - 1 && map.Vericles[(i + 1, j)] - map.Vericles[(i, j)] < 2)
                    {
                        map.Edges[(i, j)].Add((i + 1, j));
                    }
                    if (j > 0 && map.Vericles[(i, j - 1)] - map.Vericles[(i, j)] < 2)
                    {
                        map.Edges[(i, j)].Add((i, j - 1));
                    }
                    if (j < lines[0].Length - 1 && map.Vericles[(i, j + 1)] - map.Vericles[(i, j)] < 2)
                    {
                        map.Edges[(i, j)].Add((i, j + 1));
                    }
                }
            }

            return map;
        }

        public List<((int, int), char)> AStar((int, int)? s = null)
        {
            (int, int) start = Start;
            if(s.HasValue)
            {
                start = s.Value;
            }
            Dictionary<(int, int), (int, int)?> visited = new();

            Queue<(int, int)> stack = new();
            stack.Enqueue(start);
            visited.Add(start, null);

            while (stack.Count > 0)
            {
                (int, int) fromV = stack.Dequeue();
                foreach((int, int) toV in Edges[fromV].OrderBy(x => Vericles[x]).Reverse())
                {
                    if(visited.ContainsKey(toV))
                    {
                        continue;
                    }
                    else if(toV == End)
                    {
                        visited.Add(toV, fromV);
                        stack.Clear();
                        break;
                    }
                    else
                    {
                        stack.Enqueue(toV);
                        visited.Add(toV, fromV);
                    }
                }
            }

            List<((int, int), char)> path = new();
            (int, int) temp = End;
            if (!visited.ContainsKey(temp))
            {
                return path;
            }
            while (visited[temp].HasValue)
            {
                path.Add((temp, Vericles[temp]));
                temp = visited[temp]!.Value;
            }
            path.Add((start, Vericles[start]));
            path.Reverse();

            return path;
        }

        public int GetShortestPathFromA => Starts.Select(x => AStar(x).Count).Where(x => x != 0).Min();
    }
}
