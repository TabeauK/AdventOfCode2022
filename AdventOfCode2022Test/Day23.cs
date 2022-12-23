using AdventOfCode2022Library;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day23
    {
        [TestMethod]
        public void FieldOfElvesArea()
        {
            using Parser parser = new("TestInputs\\Day23.txt");
            FieldOfElves field = parser.ReadMultilineContent<FieldOfElves>().First();

            field.Run(10);

            Assert.AreEqual(110, field.GetArea);
        }

        [TestMethod]
        public void RoundsOfElvesMovement()
        {
            using Parser parser = new("TestInputs\\Day23.txt");
            FieldOfElves field = parser.ReadMultilineContent<FieldOfElves>().First();

            Assert.AreEqual(20, field.Run(int.MaxValue));
        }

        [TestMethod]
        public void FieldOfElvesAreaRealData()
        {
            using Parser parser = new("Inputs\\Day23.txt");
            FieldOfElves field = parser.ReadMultilineContent<FieldOfElves>().First();

            field.Run(10);

            Assert.AreEqual(3689, field.GetArea);
        }

        [TestMethod]
        public void RoundsOfElvesMovementRealData()
        {
            using Parser parser = new("Inputs\\Day23.txt");
            FieldOfElves field = parser.ReadMultilineContent<FieldOfElves>().First();

            Assert.AreEqual(965, field.Run(int.MaxValue));
        }
    }
}
