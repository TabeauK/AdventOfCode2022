using System.Security.Cryptography.X509Certificates;
using AdventOfCode2022Library.Day3;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day3
    {
        [TestMethod]
        public void CountPrioritiesOfWrongItems()
        {
            using Parser parser = new("TestInputs\\Day3.txt");
            ICollection<Rucksack> rucksacks = parser.ReadRucksack();

            Assert.IsTrue(rucksacks.Sum(x => x.GetWrongItem) == 157);
        }

        [TestMethod]
        public void PlaceHolder()
        {
            using Parser parser = new("TestInputs\\Day3.txt");
            List<Rucksack> rucksacks = parser.ReadRucksack().ToList();
            int count = 0;

            for (int i = 0; i < rucksacks.Count; i += 3)
            {
                count += Rucksack.Compare(rucksacks[i], rucksacks[i + 1], rucksacks[i + 2]);
            }

            Assert.IsTrue(count == 70);
        }
    }
}