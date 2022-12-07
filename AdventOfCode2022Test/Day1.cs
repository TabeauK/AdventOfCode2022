using System.Security.Cryptography.X509Certificates;
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

            Assert.IsTrue(elves.ToList().Max()?.id == 4);
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

            Assert.IsTrue(count == 45000);
        }

        [TestMethod]
        public void CountMaxCaloriesRealData()
        {
            using Parser parser = new("Inputs\\Day1.txt");
            ICollection<Elf> elves = parser.ReadMultilineContent<Elf>();

            Assert.IsTrue(elves.ToList().Max()?.id == 497);
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

            Assert.IsTrue(count == 210957);
        }
    }
}