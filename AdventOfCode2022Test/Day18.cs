using AdventOfCode2022Library;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day18
    {
        [TestMethod]
        public void MagmaSides()
        {
            using Parser parser = new("TestInputs\\Day18.txt");
            Cube cube = parser.ReadMultilineContent<Cube>().First();

            Assert.AreEqual(64, cube.Sides);
        }

        [TestMethod]
        public void MagmaSidesOpenSides()
        {
            using Parser parser = new("TestInputs\\Day18.txt");
            Cube cube = parser.ReadMultilineContent<Cube>().First();

            Assert.AreEqual(58, cube.Sides - cube.Droplets());
        }

        [TestMethod]
        public void MagmaSidesRealData()
        {
            using Parser parser = new("Inputs\\Day18.txt");
            Cube cube = parser.ReadMultilineContent<Cube>().First();

            Assert.AreEqual(4320, cube.Sides);
        }

        [TestMethod]
        public void MagmaSidesOpenSidesRealData()
        {
            using Parser parser = new("Inputs\\Day18.txt");
            Cube cube = parser.ReadMultilineContent<Cube>().First();

            Assert.AreEqual(2456, cube.Sides - cube.Droplets());
        }
    }
}
