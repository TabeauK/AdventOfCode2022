using AdventOfCode2022Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            Assert.IsTrue(stacks.GetResult == "CMZ");
        }

        [TestMethod]
        public void StackTopsCrateMover9001()
        {
            using Parser parser = new("TestInputs\\Day5.txt");
            Stacks stacks = parser.ReadMultilineContent<Stacks>().First();
            using Parser parser2 = new($"TestInputs\\Day5_2.txt");
            stacks.instructions = parser2.ReadContent<Instructions>().ToList();

            stacks.ApplyInstructions(CrateMover9001: true);

            Assert.IsTrue(stacks.GetResult == "MCD");
        }

        [TestMethod]
        public void StackTopsRealData()
        {
            using Parser parser = new("Inputs\\Day5.txt");
            Stacks stacks = parser.ReadMultilineContent<Stacks>().First();
            using Parser parser2 = new($"Inputs\\Day5_2.txt");
            stacks.instructions = parser2.ReadContent<Instructions>().ToList();

            stacks.ApplyInstructions();

            Assert.IsTrue(stacks.GetResult == "WCZTHTMPS");
        }

        [TestMethod]
        public void StackTopsCrateMover9001RealData()
        {
            using Parser parser = new("Inputs\\Day5.txt");
            Stacks stacks = parser.ReadMultilineContent<Stacks>().First();
            using Parser parser2 = new($"Inputs\\Day5_2.txt");
            stacks.instructions = parser2.ReadContent<Instructions>().ToList();

            stacks.ApplyInstructions(CrateMover9001: true);

            Assert.IsTrue(stacks.GetResult == "BLSGJSDTS");
        }
    }
}
