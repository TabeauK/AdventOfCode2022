using AdventOfCode2022Library;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day15
    {
        [TestMethod]
        public void LineCoverage()
        {
            using Parser parser = new("TestInputs\\Day15.txt");
            ICollection<Sensor> list = parser.ReadContent<Sensor>();

            Assert.AreEqual(26, Sensor.GetAllLineCoverage(list, 10));
        }

        [TestMethod]
        public void AreaCoverage()
        {
            using Parser parser = new("TestInputs\\Day15.txt");
            ICollection<Sensor> list = parser.ReadContent<Sensor>();

                
            Assert.AreEqual((14, 11), Sensor.GetPointNotCovered(list, 20));
        }

        [TestMethod]
        public void LineCoverageRealData()
        {
            using Parser parser = new("Inputs\\Day15.txt");
            ICollection<Sensor> list = parser.ReadContent<Sensor>();

            Assert.AreEqual(4793062, Sensor.GetAllLineCoverage(list, 2000000));
        }

        [TestMethod]
        public void AreaCoverageRealData()
        {
            using Parser parser = new("Inputs\\Day15.txt");
            ICollection<Sensor> list = parser.ReadContent<Sensor>();

            (int, int) v = Sensor.GetPointNotCovered(list, 4000000);

            Assert.AreEqual((2706598, 3253551), v);
            Assert.AreEqual(10826395253551,
                v.Item1 * (long)4000000 + v.Item2);
        }
    }
}
