using AdventOfCode2022Library;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day3
    {
        [TestMethod]
        public void CountPrioritiesOfWrongItems()
        {
            using Parser parser = new("TestInputs\\Day3.txt");
            ICollection<Rucksack> rucksacks = parser.ReadContent<Rucksack>();

            Assert.IsTrue(rucksacks.Sum(x => x.GetWrongItem) == 157);
        }

        [TestMethod]
        public void CountBadges()
        {
            using Parser parser = new("TestInputs\\Day3.txt");
            List<Rucksack> rucksacks = parser.ReadContent<Rucksack>().ToList();
            int count = 0;

            for (int i = 0; i < rucksacks.Count; i += 3)
            {
                count += Rucksack.Compare(rucksacks[i], rucksacks[i + 1], rucksacks[i + 2]);
            }

            Assert.IsTrue(count == 70);
        }

        [TestMethod]
        public void CountPrioritiesOfWrongItemsRealData()
        {
            using Parser parser = new("Inputs\\Day3.txt");
            ICollection<Rucksack> rucksacks = parser.ReadContent<Rucksack>();

            Assert.IsTrue(rucksacks.Sum(x => x.GetWrongItem) == 7903);
        }

        [TestMethod]
        public void CountBadgesRealData()
        {
            using Parser parser = new("Inputs\\Day3.txt");
            List<Rucksack> rucksacks = parser.ReadContent<Rucksack>().ToList();
            int count = 0;

            for (int i = 0; i < rucksacks.Count; i += 3)
            {
                count += Rucksack.Compare(rucksacks[i], rucksacks[i + 1], rucksacks[i + 2]);
            }

            Assert.IsTrue(count == 2548);
        }
    }
}