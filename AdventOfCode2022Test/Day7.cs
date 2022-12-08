using AdventOfCode2022Library;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day7
    {
        [TestMethod]
        public void CountDirSize()
        {
            using Parser parser = new("TestInputs\\Day7.txt");
            Dirs directory = parser.ReadMultilineContent<Dirs>().First();

            int size = directory.CountSizeOfSmallDirs(100000);

            Assert.AreEqual(48381165, directory.size);
            Assert.AreEqual(95437, size);
        }

        [TestMethod]
        public void FindSmallestSizeToDelete()
        {
            using Parser parser = new("TestInputs\\Day7.txt");
            Dirs directory = parser.ReadMultilineContent<Dirs>().First();

            Assert.AreEqual(24933642, directory.FindSmallestSizeToDelete(directory.size - 40000000));
        }

        [TestMethod]
        public void CountDirSizeRealData()
        {
            using Parser parser = new("Inputs\\Day7.txt");
            Dirs directory = parser.ReadMultilineContent<Dirs>().First();

            int size = directory.CountSizeOfSmallDirs(100000);

            Assert.AreEqual(1581595, size);
        }

        [TestMethod]
        public void FindSmallestSizeToDeleteRealData()
        {
            using Parser parser = new("Inputs\\Day7.txt");
            Dirs directory = parser.ReadMultilineContent<Dirs>().First();

            Assert.AreEqual(1544176, directory.FindSmallestSizeToDelete(directory.size - 40000000));
        }
    }
}
