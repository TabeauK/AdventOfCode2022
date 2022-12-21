using AdventOfCode2022Library;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day20
    {
        [TestMethod]
        public void Coordinates()
        {
            using Parser parser = new("TestInputs\\Day20.txt");
            Sequence sequence = parser.ReadMultilineContent<Sequence>().First();

            Assert.AreEqual(3, sequence.Run());
        }

        [TestMethod]
        public void CoordinatesLong()
        {
            using Parser parser = new("TestInputs\\Day20.txt");
            Sequence sequence = parser.ReadMultilineContent<Sequence>().First();

            Assert.AreEqual(1623178306, sequence.RunLonger());
        }

        [TestMethod]
        public void CoordinatesRealData()
        {
            using Parser parser = new("Inputs\\Day20.txt");
            Sequence sequence = parser.ReadMultilineContent<Sequence>().First();

            Assert.AreEqual(3346, sequence.Run());
        }

        [TestMethod]
        public void CoordinatesLongRealData()
        {
            using Parser parser = new("Inputs\\Day20.txt");
            Sequence sequence = parser.ReadMultilineContent<Sequence>().First();

            Assert.AreEqual(4265712588168, sequence.RunLonger());
        }
    }
}
