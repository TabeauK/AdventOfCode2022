using AdventOfCode2022Library;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day9
    {
        [TestMethod]
        public void CountTailPositions()
        {
            using Parser parser = new("TestInputs\\Day9.txt");
            SnakeGrid grid = new(parser.ReadContent<SnakeMove>().ToList());
            grid.ApplyMoves();

            Assert.AreEqual(13, grid.GetTailPositions(1).Distinct().Count());
        }

        [TestMethod]
        public void CountLongTailPositions()
        {
            using Parser parser = new("TestInputs\\Day9_2.txt");
            SnakeGrid grid = new(parser.ReadContent<SnakeMove>().ToList());
            grid.ApplyMoves();

            Assert.AreEqual(36, grid.GetTailPositions(9).Distinct().Count());
        }

        [TestMethod]
        public void CountTailPositionsRealData()
        {
            using Parser parser = new("Inputs\\Day9.txt");
            SnakeGrid grid = new(parser.ReadContent<SnakeMove>().ToList());
            grid.ApplyMoves();

            Assert.AreEqual(6067, grid.GetTailPositions(1).Distinct().Count());
        }

        [TestMethod]
        public void CountLongTailPositionsRealData()
        {
            using Parser parser = new("Inputs\\Day9.txt");
            SnakeGrid grid = new(parser.ReadContent<SnakeMove>().ToList());
            grid.ApplyMoves();

            Assert.AreEqual(0, grid.GetTailPositions(9).Distinct().Count());
        }
    }
}
