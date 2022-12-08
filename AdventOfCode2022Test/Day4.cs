using AdventOfCode2022Library;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day4
    {
        [TestMethod]
        public void CountCleaningPairsContainingEachOther()
        {
            using Parser parser = new("TestInputs\\Day4.txt");
            List<CleaningPair> cleaningPair = parser.ReadContent<CleaningPair>().ToList();

            Assert.AreEqual(2, cleaningPair.Count(x => x.DoesOneContainAnother));
        }

        [TestMethod]
        public void CountCleaningPairsOverlaping()
        {
            using Parser parser = new("TestInputs\\Day4.txt");
            List<CleaningPair> cleaningPair = parser.ReadContent<CleaningPair>().ToList();

            Assert.AreEqual(4, cleaningPair.Count(x => x.Overlap));
        }

        [TestMethod]
        public void CountCleaningPairsContainingEachOtherRealData()
        {
            using Parser parser = new("Inputs\\Day4.txt");
            List<CleaningPair> cleaningPair = parser.ReadContent<CleaningPair>().ToList();

            Assert.AreEqual(496, cleaningPair.Count(x => x.DoesOneContainAnother));
        }

        [TestMethod]
        public void CountCleaningPairsOverlapingRealData()
        {
            using Parser parser = new("Inputs\\Day4.txt");
            List<CleaningPair> cleaningPair = parser.ReadContent<CleaningPair>().ToList();

            Assert.AreEqual(847, cleaningPair.Count(x => x.Overlap));
        }
    }
}
