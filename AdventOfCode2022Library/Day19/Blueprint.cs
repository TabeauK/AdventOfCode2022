using System.Text.RegularExpressions;

namespace AdventOfCode2022Library
{
    public partial class Blueprint: IMyParsable<Blueprint>
    {
        public int Id;

        public List<List<int>> RobotCost = new();

        public List<int> MaxCost = new();

        public int BestFind = 0;

        public static Blueprint Parse(string s)
        {
            List<int> numbers = IntRegex().Matches(s).Select(x => int.Parse(x.Value)).ToList();
            return new()
            {
                Id = numbers[0],
                RobotCost = new List<List<int>>()
                {
                   new List<int>()  { numbers[1], 0, 0, 0 },
                   new List<int>()  { numbers[2], 0, 0, 0 },
                   new List<int>()  { numbers[3], numbers[4], 0, 0 },
                   new List<int>()  { numbers[5], 0, numbers[6], 0 },
                   new List<int>()  { 0, 0, 0, 0 }
                },
                MaxCost = new List<int>()
                {
                    (new List<int>()
                    {
                        numbers[1],
                        numbers[2],
                        numbers[3],
                        numbers[5]
                    }).Max(),
                    numbers[4],
                    numbers[6],
                }
            };
        }

        [GeneratedRegex("\\d+")]
        private static partial Regex IntRegex();

        public List<int> CanBuildRobots(BlueprintState state)
        {
            if(Enumerable.Range(0, 4)
                         .All(j => state.OreInventory[j] - RobotCost[3][j] >= 0))
            {
                return new List<int>() { 3 };
            }
            List<int> list = Enumerable
                .Range(0, 3)
                .Where(i =>
                    state.RobotInventory[i] < MaxCost[i] &&
                    (!state.Prev.Item1 || !state.Prev.Item2.Contains(i)) &&
                    Enumerable.Range(0, 4).All(j =>
                        state.OreInventory[j] - RobotCost[i][j] >= 0))
                .ToList();
            list.Add(4);
            return list;
        }

        public int RunSimulation(BlueprintState state)
        {
            if(state.OreInventory[3] > BestFind)
            {
                BestFind = state.OreInventory[3];
            }
            if(state.Time <= 0 ||
                state.Time * (state.Time / 2 + state.RobotInventory[3]) <= BestFind - state.OreInventory[3])
            {
                BestFind = Math.Max(state.OreInventory[3], BestFind);
                return state.OreInventory[3];
            }
            List<int> Robots = CanBuildRobots(state);
            return Robots.Max(Robot => RunSimulation(new()
            {
                Time = state.Time - 1,
                OreInventory = Enumerable.Range(0, 4).Select(i => state.OreInventory[i] + state.RobotInventory[i] - RobotCost[Robot][i]).ToList(),
                RobotInventory = state.RobotInventory.Select((x, index) => index == Robot ? x + 1 : x).ToList(),
                Prev = (Robot == 4, Robots) 
            }));
        }
    }   
}

