using AdventOfCode2022Library;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day25
    {
        [TestMethod]
        public void GetNumber()
        {
            using Parser parser = new("TestInputs\\Day25.txt");
            ICollection<SNAFU> list = parser.ReadContent<SNAFU>();

            Assert.AreEqual(4890, list.Sum(x => x.Int));
            Assert.AreEqual("2=-1=0", new SNAFU() { Int = list.Sum(x => x.Int) }.Snafu);
        }

        [TestMethod]
        public void GetNumberRealData()
        {
            using Parser parser = new("Inputs\\Day25.txt");
            ICollection<SNAFU> list = parser.ReadContent<SNAFU>();

            Assert.AreEqual(34168440432447, list.Sum(x => x.Int));
            Assert.AreEqual("2-0-0=1-0=2====20=-2", new SNAFU() { Int = list.Sum(x => x.Int) }.Snafu);
        }
    }
}
