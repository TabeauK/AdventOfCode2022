using AdventOfCode2022Library;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day6
    {
        [TestMethod]
        public void FindStartSignal()
        {
            using Parser parser = new("TestInputs\\Day6.txt");
            List<Signal> signals = parser.ReadContent<Signal>().ToList();

            Assert.AreEqual(5, signals[0].FindStartSignal);
            Assert.AreEqual(6, signals[1].FindStartSignal);
            Assert.AreEqual(10, signals[2].FindStartSignal);
            Assert.AreEqual(11, signals[3].FindStartSignal);
            Assert.AreEqual(7, signals[4].FindStartSignal);
        }

        [TestMethod]
        public void FindStartMessage()
        {
            using Parser parser = new("TestInputs\\Day6.txt");
            List<Signal> signals = parser.ReadContent<Signal>().ToList();

            Assert.AreEqual(23, signals[0].FindStartMessage);
            Assert.AreEqual(23, signals[1].FindStartMessage);
            Assert.AreEqual(29, signals[2].FindStartMessage);
            Assert.AreEqual(26, signals[3].FindStartMessage);
            Assert.AreEqual(19, signals[4].FindStartMessage);
        }

        [TestMethod]
        public void FindStartSignalRealData()
        {
            using Parser parser = new("Inputs\\Day6.txt");
            Signal signal = parser.ReadContent<Signal>().First();

            Assert.AreEqual(1760, signal.FindStartSignal);
        }

        [TestMethod]
        public void FindStartMessageRealData()
        {
            using Parser parser = new("Inputs\\Day6.txt");
            Signal signal = parser.ReadContent<Signal>().First();

            Assert.AreEqual(2974, signal.FindStartMessage);
        }
    }
}
