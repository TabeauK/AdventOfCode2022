using AdventOfCode2022Library;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day12
    {
        [TestMethod]
        public void AStar()
        {
            using Parser parser = new("TestInputs\\Day12.txt");
            TopographicMap map = parser.ReadMultilineContent<TopographicMap>().First();

            List<((int, int), char)> path = map.AStar();
            
            Assert.AreEqual(31, path.Count - 1);
        }

        [TestMethod]
        public void GetShortestAPath()
        {
            using Parser parser = new("TestInputs\\Day12.txt");
            TopographicMap map = parser.ReadMultilineContent<TopographicMap>().First();

            Assert.AreEqual(29, map.GetShortestPathFromA - 1);
        }

        [TestMethod]
        public void AStarRealData()
        {
            using Parser parser = new("Inputs\\Day12.txt");
            TopographicMap map = parser.ReadMultilineContent<TopographicMap>().First();

            List<((int, int), char)> path = map.AStar();

            Assert.AreEqual(361, path.Count - 1);
        }


        [TestMethod]
        public void GetShortestAPathRealData()
        {
            using Parser parser = new("Inputs\\Day12.txt");
            TopographicMap map = parser.ReadMultilineContent<TopographicMap>().First();

            Assert.AreEqual(354, map.GetShortestPathFromA - 1);
        }
    }
}
