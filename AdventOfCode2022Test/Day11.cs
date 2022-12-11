using AdventOfCode2022Library;
using System.Numerics;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day11
    {
        [TestMethod]
        public void PlayMonkeyRounds()
        {
            using Parser parser = new("TestInputs\\Day11.txt");
            Monkey.Clear();
            List<Monkey> monkeys = parser.ReadMultilineContent<Monkey>().ToList();

            Monkey.PlayRounds(20);
            monkeys.Sort((x, y) => x.ItemsInspected - y.ItemsInspected);

            Assert.AreEqual(10605, monkeys[^1].ItemsInspected * monkeys[^2].ItemsInspected);
        }

        [TestMethod]
        public void PlayMonkeyRoundsNoRelief()
        {
            using Parser parser = new("TestInputs\\Day11.txt");
            Monkey.Clear();
            List<Monkey> monkeys = parser.ReadMultilineContent<Monkey>().ToList();

            Monkey.PlayRounds(10000, relief: false);
            monkeys.Sort((x, y) => x.ItemsInspected - y.ItemsInspected);

             Assert.AreEqual(2713310158, monkeys[^1].ItemsInspected * (long)monkeys[^2].ItemsInspected);
        }

        [TestMethod]
        public void PlayMonkeyRoundsRealData()
        {
            using Parser parser = new("Inputs\\Day11.txt");
            Monkey.Clear();
            List<Monkey> monkeys = parser.ReadMultilineContent<Monkey>().ToList();

            Monkey.PlayRounds(20);
            monkeys.Sort((x, y) => x.ItemsInspected - y.ItemsInspected);

            Assert.AreEqual(76728, monkeys[^1].ItemsInspected * monkeys[^2].ItemsInspected);
        }


        [TestMethod]
        public void PlayMonkeyRoundsNoReliefRealData()
        {
            using Parser parser = new("Inputs\\Day11.txt");
            Monkey.Clear();
            List<Monkey> monkeys = parser.ReadMultilineContent<Monkey>().ToList();

            Monkey.PlayRounds(10000, relief: false);
            monkeys.Sort((x, y) => x.ItemsInspected - y.ItemsInspected);

            Assert.AreEqual(21553910156, monkeys[^1].ItemsInspected * (long)monkeys[^2].ItemsInspected);
        }
    }
}
