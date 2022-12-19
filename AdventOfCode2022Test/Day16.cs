using AdventOfCode2022Library;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day16
    {
        [TestMethod]
        public void FindMaxPressure()
        {
            using Parser parser = new("TestInputs\\Day16.txt");
            ValveMap walker = new ValveMap(parser.ReadContent<Valve>().ToList());

            Assert.AreEqual(1651, walker.Calculate(walker.CurrentValves));
        }

        [TestMethod]
        public void FindMaxPressureWithElephant()
        {
            using Parser parser = new("TestInputs\\Day16.txt");
            ValveMap walker = new ValveMap(parser.ReadContent<Valve>().ToList());

            Assert.AreEqual(1707, walker.Calculate(walker.CurrentValves, true, 26));
        }

        [TestMethod]
        public void FindMaxPressureRealData()
        {
            using Parser parser = new("Inputs\\Day16.txt");
            ValveMap walker = new ValveMap(parser.ReadContent<Valve>().ToList());

            Assert.AreEqual(1737, walker.Calculate(walker.CurrentValves));
        }

        [TestMethod]
        public void FindMaxPressureWithElephantRealData()
        {
            using Parser parser = new("Inputs\\Day16.txt");
            ValveMap walker = new ValveMap(parser.ReadContent<Valve>().ToList());

            Assert.AreEqual(2216, walker.Calculate(walker.CurrentValves, true, 26));
        }
    }
}
