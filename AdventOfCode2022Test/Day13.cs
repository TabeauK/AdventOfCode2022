using AdventOfCode2022Library;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day13
    {
        [TestMethod]
        public void VerifyDistressSignal()
        {
            using Parser parser = new("TestInputs\\Day13.txt");
            List<DistressSignal> signals = parser.ReadMultilineContent<DistressSignal>().ToList();
            List<int> verify = signals.Select(x => x.Verify).ToList();

            int sum = 0;
            for(int i = 0; i < verify.Count; i++)
            {
                sum += (i + 1) * verify[i]; 
            }
            Assert.AreEqual(13, sum);
        }

        [TestMethod]
        public void DecoderKey()
        {
            using Parser parser = new("TestInputs\\Day13.txt");
            List<DistressSignal> signals = parser.ReadMultilineContent<DistressSignal>().ToList();

            List<dynamic> list = DistressSignal.ListOfAllSignals(signals);
            list.Sort(DistressSignal.Compare);

            Assert.AreEqual(140, 
                (list.FindIndex(x => x is string && x == "[[2]]") + 1) *
                (list.FindIndex(x => x is string && x == "[[6]]") + 1));
        }

        [TestMethod]
        public void VerifyDistressSignalRealData()
        {
            using Parser parser = new("Inputs\\Day13.txt");
            List<DistressSignal> signals = parser.ReadMultilineContent<DistressSignal>().ToList();
            List<int> verify = signals.Select(x => x.Verify).ToList();

            int sum = 0;
            for (int i = 0; i < verify.Count; i++)
            {
                sum += (i + 1) * verify[i];
            }
            Assert.AreEqual(5003, sum);
        }


        [TestMethod]
        public void DecoderKeyRealData()
        {
            using Parser parser = new("Inputs\\Day13.txt");
            List<DistressSignal> signals = parser.ReadMultilineContent<DistressSignal>().ToList();

            List<dynamic> list = DistressSignal.ListOfAllSignals(signals);
            list.Sort(DistressSignal.Compare);

            Assert.AreEqual(20280,
                (list.FindIndex(x => x is string && x == "[[2]]") + 1) *
                (list.FindIndex(x => x is string && x == "[[6]]") + 1));
        }
    }
}
