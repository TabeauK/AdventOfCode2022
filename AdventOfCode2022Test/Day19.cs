using AdventOfCode2022Library;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day19
    {
        [TestMethod]
        public void BlueprintsQuality()
        {
            using Parser parser = new("TestInputs\\Day19.txt");
            BlueprintSimulator simulator = new()
            {
                list = parser.ReadContent<Blueprint>().ToList()
            };

            Assert.AreEqual(33, simulator.Run());
        }

        [TestMethod]
        public void BlueprintsQualityLongerTime()
        {
            using Parser parser = new("TestInputs\\Day19.txt");
            BlueprintSimulator simulator = new()
            {
                list = parser.ReadContent<Blueprint>().ToList()
            };

            Assert.AreEqual(56 * 62, simulator.RunLonger());
        }

        [TestMethod]
        public void BlueprintsQualityRealData()
        {
            using Parser parser = new("Inputs\\Day19.txt");
            BlueprintSimulator simulator = new()
            {
                list = parser.ReadContent<Blueprint>().ToList()
            };

            Assert.AreEqual(1480, simulator.Run());
        }

        [TestMethod]
        public void BlueprintsQualityLongerTimeRealData()
        {
            using Parser parser = new("Inputs\\Day19.txt");
            BlueprintSimulator simulator = new()
            {
                list = parser.ReadContent<Blueprint>().ToList()
            };

            Assert.AreEqual(3168, simulator.RunLonger());
        }
    }
}
