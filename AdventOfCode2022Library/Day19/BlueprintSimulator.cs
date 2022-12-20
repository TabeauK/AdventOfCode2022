namespace AdventOfCode2022Library
{
    public class BlueprintSimulator
    {
        public List<Blueprint> list = new();

        public int Run()
        {
            return list.AsParallel().Sum(x => x.Id * x.RunSimulation(new()));
        }

        public int RunLonger()
        {
            List<int> result = new() { 1 };
            Parallel.ForEach<Blueprint>(list.Take(Math.Min(3, list.Count)), blueprint =>
            {
                int res = blueprint.RunSimulation(new() { Time = 32 });
                lock(result)
                {
                    result[0] *= res;
                }
            });
            return result[0];
        }
    }
}

