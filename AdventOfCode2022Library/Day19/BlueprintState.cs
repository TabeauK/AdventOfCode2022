namespace AdventOfCode2022Library
{
    public class BlueprintState
    {
        public int Time = 24;
        public List<int> RobotInventory = new() { 1, 0, 0, 0, 0 };
        public List<int> OreInventory = new() { 0, 0, 0, 0 };
        public (bool, List<int>) Prev = (false, new());

        public BlueprintState Clone()
        {
            return new()
            {
                Time = Time,
                RobotInventory = RobotInventory.Select(x => x).ToList(),
                OreInventory = OreInventory.Select(x => x).ToList()
            };
        }
    }
}
