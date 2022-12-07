using AdventOfCode2022Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            Assert.IsTrue(cleaningPair.Count(x => x.DoesOneContainAnother) == 2);
        }

        [TestMethod]
        public void CountCleaningPairsOverlaping()
        {
            using Parser parser = new("TestInputs\\Day4.txt");
            List<CleaningPair> cleaningPair = parser.ReadContent<CleaningPair>().ToList();

            Assert.IsTrue(cleaningPair.Count(x => x.Overlap) == 4);
        }

        [TestMethod]
        public void CountCleaningPairsContainingEachOtherRealData()
        {
            using Parser parser = new("Inputs\\Day4.txt");
            List<CleaningPair> cleaningPair = parser.ReadContent<CleaningPair>().ToList();

            Assert.IsTrue(cleaningPair.Count(x => x.DoesOneContainAnother) == 496);
        }

        [TestMethod]
        public void CountCleaningPairsOverlapingRealData()
        {
            using Parser parser = new("Inputs\\Day4.txt");
            List<CleaningPair> cleaningPair = parser.ReadContent<CleaningPair>().ToList();

            Assert.IsTrue(cleaningPair.Count(x => x.Overlap) == 847);
        }
    }
}
