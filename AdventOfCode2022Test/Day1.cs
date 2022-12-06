using System.Security.Cryptography.X509Certificates;
using AdventOfCode2022Library.Day1;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day1
    {
        [TestMethod]
        public void CountMaxCalories()
        {
            using Parser parser = new("TestInputs\\Day1.txt");
            ICollection<Elf> elves = parser.ReadElves();

            Assert.IsTrue(elves.ToList().Max()?.id == 4);
        }

        [TestMethod]
        public void CountMaxCaloriesFrom3Elves()
        {
            using Parser parser = new("TestInputs\\Day1.txt");
            ICollection<Elf> elves = parser.ReadElves();
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
    }
}