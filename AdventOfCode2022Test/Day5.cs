using AdventOfCode2022Library;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day5
    {
        [TestMethod]
        public void StackTops()
        {
            using Parser parser = new("TestInputs\\Day5.txt");
            Stacks stacks = parser.ReadMultilineContent<Stacks>().First();
            using Parser parser2 = new($"TestInputs\\Day5_2.txt");
            stacks.instructions = parser2.ReadContent<Instructions>().ToList();

            stacks.ApplyInstructions();

            Assert.AreEqual("CMZ", stacks.GetResult);
        }

        [TestMethod]
        public void StackTopsCrateMover9001()
        {
            using Parser parser = new("TestInputs\\Day5.txt");
            Stacks stacks = parser.ReadMultilineContent<Stacks>().First();
            using Parser parser2 = new($"TestInputs\\Day5_2.txt");
            stacks.instructions = parser2.ReadContent<Instructions>().ToList();

            stacks.ApplyInstructions(CrateMover9001: true);

            Assert.AreEqual("MCD", stacks.GetResult);
        }

        [TestMethod]
        public void StackTopsRealData()
        {
            using Parser parser = new("Inputs\\Day5.txt");
            Stacks stacks = parser.ReadMultilineContent<Stacks>().First();
            using Parser parser2 = new($"Inputs\\Day5_2.txt");
            stacks.instructions = parser2.ReadContent<Instructions>().ToList();

            stacks.ApplyInstructions();

            Assert.AreEqual("WCZTHTMPS", stacks.GetResult);
        }

        [TestMethod]
        public void StackTopsCrateMover9001RealData()
        {
            using Parser parser = new("Inputs\\Day5.txt");
            Stacks stacks = parser.ReadMultilineContent<Stacks>().First();
            using Parser parser2 = new($"Inputs\\Day5_2.txt");
            stacks.instructions = parser2.ReadContent<Instructions>().ToList();

            stacks.ApplyInstructions(CrateMover9001: true);

            Assert.AreEqual("BLSGJSDTS", stacks.GetResult);
        }
    }
}
