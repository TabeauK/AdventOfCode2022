using AdventOfCode2022Library;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day8
    {
        [TestMethod]
        public void CountTrees()
        {
            using Parser parser = new("TestInputs\\Day8.txt");
            TreeGrid treeGrid = parser.ReadMultilineContent<TreeGrid>().First();
            treeGrid.CheckVisibilty();

            Assert.AreEqual(21, treeGrid.CountVisible());
        }

        [TestMethod]
        public void ContVisibleTrees()
        {
            using Parser parser = new("TestInputs\\Day8.txt");
            TreeGrid treeGrid = parser.ReadMultilineContent<TreeGrid>().First();
            treeGrid.CheckVisibilty();

            Assert.AreEqual(8, treeGrid.BiggestScore());
        }

        [TestMethod]
        public void CountTreesRealData()
        {
            using Parser parser = new("Inputs\\Day8.txt");
            TreeGrid treeGrid = parser.ReadMultilineContent<TreeGrid>().First();
            treeGrid.CheckVisibilty();

            Assert.AreEqual(1688, treeGrid.CountVisible());
        }

        [TestMethod]
        public void ContVisibleTreesRealData()
        {
            using Parser parser = new("Inputs\\Day8.txt");
            TreeGrid treeGrid = parser.ReadMultilineContent<TreeGrid>().First();
            treeGrid.CheckVisibilty();

            Assert.AreEqual(410400, treeGrid.BiggestScore());
        }
    }
}
