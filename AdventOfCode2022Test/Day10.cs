using AdventOfCode2022Library;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day10
    {
        [TestMethod]
        public void GetSignalStrengthForKeyPositions()
        {
            using Parser parser = new("TestInputs\\Day10.txt");
            Processor proc = new()
            {
                commands = parser.ReadContent<Command>().ToList()
            };
            proc.ExecuteCommands();

            Assert.AreEqual(13140, proc.GetRegisterStrengthInKeyMoments(new() { 20, 60, 100, 140, 180, 220 }));
        }

        [TestMethod]
        public void DrawPattern()
        {
            using Parser parser = new("TestInputs\\Day10.txt");
            List<string> pattern = new()
            {
                "##..##..##..##..##..##..##..##..##..##..",
                "###...###...###...###...###...###...###.",
                "####....####....####....####....####....",
                "#####.....#####.....#####.....#####.....",
                "######......######......######......####",
                "#######.......#######.......#######....."
            };

            Processor proc = new()
            {
                commands = parser.ReadContent<Command>().ToList()
            };
            proc.ExecuteCommands();
            List<string> newPatten = proc.GetPattern();

            for(int i = 0; i < pattern.Count; i++)
            {
                Assert.AreEqual(pattern[i], newPatten[i]);
            }
        }

        [TestMethod]
        public void GetSignalStrengthForKeyPositionsRealData()
        {
            using Parser parser = new("Inputs\\Day10.txt");
            Processor proc = new()
            {
                commands = parser.ReadContent<Command>().ToList()
            };
            proc.ExecuteCommands();

            Assert.AreEqual(14860, proc.GetRegisterStrengthInKeyMoments(new() { 20, 60, 100, 140, 180, 220 }));
        }

        [TestMethod]
        public void DrawPatternRealData()
        {
            using Parser parser = new("Inputs\\Day10.txt");
            List<string> pattern = new()
            {
                "###...##..####.####.#..#.#..#.###..#..#.",
                "#..#.#..#....#.#....#..#.#..#.#..#.#.#..",
                "#..#.#......#..###..####.#..#.#..#.##...",
                "###..#.##..#...#....#..#.#..#.###..#.#..",
                "#.#..#..#.#....#....#..#.#..#.#.#..#.#..",
                "#..#..###.####.####.#..#..##..#..#.#..#."
            };

            Processor proc = new()
            {
                commands = parser.ReadContent<Command>().ToList()
            };
            proc.ExecuteCommands();
            List<string> newPatten = proc.GetPattern();

            for (int i = 0; i < pattern.Count; i++)
            {
                Assert.AreEqual(pattern[i], newPatten[i]);
            }
        }
    }
}
