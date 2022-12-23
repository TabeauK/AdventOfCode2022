using AdventOfCode2022Library;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day21
    {
        [TestMethod]
        public void Coordinates()
        {
            using Parser parser = new("TestInputs\\Day21.txt");
            parser.ReadContent<MonkeyOperation>();

            Assert.AreEqual(152, MonkeyOperation.Monkeys["root"].Value);
            MonkeyOperation.Monkeys.Clear();
        }

        [TestMethod]
        public void CoordinatesLong()
        {
            using Parser parser = new("TestInputs\\Day21.txt");
            MonkeyOperation.Part2 = true;
            parser.ReadContent<MonkeyOperation>();

            Assert.AreEqual(301, MonkeyOperation.Monkeys["root"].GetValue());
            MonkeyOperation.Part2 = false;
            MonkeyOperation.Monkeys.Clear();

        }

        [TestMethod]
        public void CoordinatesRealData()
        {
            using Parser parser = new("Inputs\\Day21.txt");
            parser.ReadContent<MonkeyOperation>();

            Assert.AreEqual(142707821472432, MonkeyOperation.Monkeys["root"].Value);
            MonkeyOperation.Monkeys.Clear();
        }

        [TestMethod]
        public void CoordinatesLongRealData()
        {
            using Parser parser = new("Inputs\\Day21.txt");
            MonkeyOperation.Part2 = true;
            parser.ReadContent<MonkeyOperation>();

            Assert.AreEqual(3587647562851, MonkeyOperation.Monkeys["root"].GetValue());
            MonkeyOperation.Part2 = false;
            MonkeyOperation.Monkeys.Clear();
        }
    }
}
