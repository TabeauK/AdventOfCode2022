namespace AdventOfCode2022Library
{
    public class ValveMap
    {
        public Dictionary<string, int> t = new();

        public Dictionary<string, Valve> v = new();

        public int[,] Graph = new int[0, 0];

        public List<string> CurrentValves = new();

        public ValveMap(List<Valve> valves)
        {
            Graph = new int[valves.Count, valves.Count];
            for (int i = 0; i < valves.Count; i++)
            {
                t.Add(valves[i].Name, i);
                v.Add(valves[i].Name, valves[i]);
                if(valves[i].Pressure > 0)
                {
                    CurrentValves.Add(valves[i].Name);
                }
            }
            CreatePaths();
        }

        public void CreatePaths()
        {
            for(int i = 0; i < v.Values.Count; i++)
            {
                for (int j = 0; j < v.Values.Count; j++)
                {
                    Graph[i, j] = int.MaxValue / 4;
                }
                Graph[i, i] = 0;
            }

            foreach (Valve valve in v.Values)
            {
                foreach (string connection in valve.Connections)
                {
                    Graph[t[connection], t[valve.Name]] = 1;
                }
            }

            for (int i = 0; i < v.Values.Count; i++)
            {
                for (int j = 0; j < v.Values.Count; j++)
                {
                    for (int k = 0; k < v.Values.Count; k++)
                    {
                        if (Graph[i, j] > Graph[i, k] + Graph[k, j])
                        {
                            Graph[i, j] = Graph[i, k] + Graph[k, j];
                            Graph[j, i] = Graph[i, k] + Graph[k, j];
                        }
                    }
                }
            }
        }

        public int Calculate(List<string> current,
            bool isElephant = false,
            int time = 30,
            int score = 0,
            string whereIAm = "AA")
            
        {
            if(time < 1)
            {
                return score;
            }
            List<int> results = new();
            foreach (string neighbor in current)
            {
                if(isElephant && whereIAm == "AA")
                {
                    Console.WriteLine("    (" + (current.FindIndex(x => x == neighbor) + "/" + current.Count + ") " + neighbor));
                }
                int newTime = time - 1 - Graph[t[neighbor], t[whereIAm]];
                if (newTime < 0)
                {
                    continue;
                }
                List<string> newCurrents = current.Where(x => x != neighbor).ToList();
                int newScore = score + (v[neighbor].Pressure * newTime);
                results.Add(Calculate(newCurrents, isElephant, newTime, newScore, neighbor));
                if (isElephant)
                {
                    results.Add(Calculate(current, false, 26, score, "AA"));
                }
            }
            return results.Count > 0 ? results.Max() : score;
        }
    }
}

