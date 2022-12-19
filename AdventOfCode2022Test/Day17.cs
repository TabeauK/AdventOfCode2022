using AdventOfCode2022Library;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day17
    {
        [TestMethod]
        public void RockTowerHeight()
        {
            using Parser parser = new("TestInputs\\Day17.txt");
            Chamber chamber = parser.ReadContent<Chamber>().First();

            chamber.RunSimulation(2022);

            Assert.AreEqual(3068, chamber.Height);
        }

        [TestMethod]
        public void HighRockTowerHeight()
        {
            using Parser parser = new("TestInputs\\Day17.txt");
            Chamber chamber = parser.ReadContent<Chamber>().First();

            chamber.RunSimulation(1000000000000);

            Assert.AreEqual(1514285714288, chamber.Height);
        }

        [TestMethod]
        public void RockTowerHeightRealData()
        {
            using Parser parser = new("Inputs\\Day17.txt");
            Chamber chamber = parser.ReadContent<Chamber>().First();

            chamber.RunSimulation(2022);

            Assert.AreEqual(3171, chamber.Height);
        }

        [TestMethod]
        public void HighRockTowerHeightRealData()
        {
            using Parser parser = new("Inputs\\Day17.txt");
            Chamber chamber = parser.ReadContent<Chamber>().First();

            chamber.RunSimulation(1000000000000);

            Assert.AreEqual(1586627906921, chamber.Height);
        }
    }
}
