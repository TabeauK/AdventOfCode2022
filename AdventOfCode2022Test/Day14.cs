using AdventOfCode2022Library;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day14
    {
        [TestMethod]
        public void FillFormationWithSand()
        {
            using Parser parser = new("TestInputs\\Day14.txt");
            RockFormation formation = RockFormation.Combine(parser.ReadContent<RockFormation>());

            formation.FillWithSand();

            Assert.AreEqual(24, formation.SandPlace.Count);
        }

        [TestMethod]
        public void FillFormationWithSandAndFloor()
        {
            using Parser parser = new("TestInputs\\Day14.txt");
            RockFormation formation = RockFormation.Combine(parser.ReadContent<RockFormation>());

            formation.AddFloor();
            formation.FillWithSand();

            Assert.AreEqual(93, formation.SandPlace.Count);
        }

        [TestMethod]
        public void FillFormationWithSandRealData()
        {
            using Parser parser = new("Inputs\\Day14.txt");
            RockFormation formation = RockFormation.Combine(parser.ReadContent<RockFormation>());

            formation.FillWithSand();

            Assert.AreEqual(655, formation.SandPlace.Count);
        }


        [TestMethod]
        public void FillFormationWithSandAndFloorRealData()
        {
            using Parser parser = new("Inputs\\Day14.txt");
            RockFormation formation = RockFormation.Combine(parser.ReadContent<RockFormation>());

            formation.AddFloor();
            formation.FillWithSand();

            Assert.AreEqual(26484, formation.SandPlace.Count);
        }
    }
}
