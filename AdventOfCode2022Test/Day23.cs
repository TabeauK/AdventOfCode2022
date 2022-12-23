using AdventOfCode2022Library;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day22
    {
        [TestMethod]
        public void ForceFieldFinalPassword()
        {
            using Parser parser = new("TestInputs\\Day22_2.txt");
            using Parser parser2 = new("TestInputs\\Day22.txt");
            ForceFieldPath path = parser.ReadContent<ForceFieldPath>().First();
            path.map = parser2.ReadMultilineContent<ForceFieldPlainMap>().First();

            Assert.AreEqual(6032, path.Walk());
        }

        [TestMethod]
        public void ForceFieldCubeFinalPassword()
        {
            using Parser parser = new("TestInputs\\Day22_2.txt");
            using Parser parser2 = new("TestInputs\\Day22.txt");
            ForceFieldPath path = parser.ReadContent<ForceFieldPath>().First();
            ForceFieldCubeMap.SetUseCase(test: true);
            path.map = parser2.ReadMultilineContent<ForceFieldCubeMap>().First();

            Assert.AreEqual(5031, path.Walk());
        }

        [TestMethod]
        public void ForceFieldFinalPasswordRealData()
        {
            using Parser parser = new("Inputs\\Day22_2.txt");
            using Parser parser2 = new("Inputs\\Day22.txt");
            ForceFieldPath path = parser.ReadContent<ForceFieldPath>().First();
            path.map = parser2.ReadMultilineContent<ForceFieldPlainMap>().First();

            Assert.AreEqual(136054, path.Walk());
        }

        [TestMethod]
        public void ForceFieldCubeFinalPasswordRealData()
        {
            using Parser parser = new("Inputs\\Day22_2.txt");
            using Parser parser2 = new("Inputs\\Day22.txt");
            ForceFieldPath path = parser.ReadContent<ForceFieldPath>().First();
            ForceFieldCubeMap.SetUseCase(test: false);
            path.map = parser2.ReadMultilineContent<ForceFieldCubeMap>().First();

            Assert.AreEqual(122153, path.Walk());
        }
    }
}
