using AdventOfCode2022Library;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day24
    {
        [TestMethod]
        public void FindShortestPath()
        {
            using Parser parser = new("TestInputs\\Day24.txt");
            Valley valley = parser.ReadMultilineContent<Valley>().First();

            Assert.AreEqual(18, valley.Run());
        }

        [TestMethod]
        public void FindShortestPathWithSnacks()
        {
            using Parser parser = new("TestInputs\\Day24.txt");
            Valley valley = parser.ReadMultilineContent<Valley>().First();

            Assert.AreEqual(54, valley.Run(valley.Run(valley.Run(), true)));
        }

        [TestMethod]
        public void FindShortestPathRealData()
        {
            using Parser parser = new("Inputs\\Day24.txt");
            Valley valley = parser.ReadMultilineContent<Valley>().First();

            Assert.AreEqual(299, valley.Run());
        }

        [TestMethod]
        public void FindShortestPathWithSnacksRealData()
        {
            using Parser parser = new("Inputs\\Day24.txt");
            Valley valley = parser.ReadMultilineContent<Valley>().First();

            Assert.AreEqual(899, valley.Run(valley.Run(valley.Run(), true)));
        }
    }
}
