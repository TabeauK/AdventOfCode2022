using AdventOfCode2022Library;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day1
    {
        [TestMethod]
        public void CountMaxCalories()
        {
            using Parser parser = new("TestInputs\\Day1.txt");
            ICollection<Elf> elves = parser.ReadMultilineContent<Elf>();

            Assert.AreEqual(4, elves.ToList().Max()?.id);
            Assert.AreEqual(24000 , elves.ToList().Max()?.SumCalories());
        }

        [TestMethod]
        public void CountMaxCaloriesFrom3Elves()
        {
            using Parser parser = new("TestInputs\\Day1.txt");
            ICollection<Elf> elves = parser.ReadMultilineContent<Elf>();
            int iter = 3;
            int count = 0;

            while (iter > 0)
            {
                count += elves.Max().SumCalories();
                elves.Remove(elves.Max());
                iter--;
            }

            Assert.AreEqual(45000, count);
        }

        [TestMethod]
        public void CountMaxCaloriesRealData()
        {
            using Parser parser = new("Inputs\\Day1.txt");
            ICollection<Elf> elves = parser.ReadMultilineContent<Elf>();

            Assert.AreEqual(72240, elves.ToList().Max()?.SumCalories());
        }

        [TestMethod]
        public void CountMaxCaloriesFrom3ElvesRealData()
        {
            using Parser parser = new("Inputs\\Day1.txt");
            ICollection<Elf> elves = parser.ReadMultilineContent<Elf>();
            int iter = 3;
            int count = 0;

            while (iter > 0)
            {
                count += elves.Max().SumCalories();
                elves.Remove(elves.Max());
                iter--;
            }

            Assert.AreEqual(210957, count);
        }
    }
}