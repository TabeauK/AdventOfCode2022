using AdventOfCode2022Library;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day2
    {
        [TestMethod]
        public void CountPoints()
        {
            using Parser parser = new("TestInputs\\Day2.txt");
            ICollection<Game> games = parser.ReadContent<Game>();

            Assert.AreEqual(15, games.Sum(x => x.CountPoints));
        }

        [TestMethod]
        public void CountPointsWithKnownOutcome()
        {
            using Parser parser = new("TestInputs\\Day2.txt");
            ICollection<Game> games = parser.ReadContent<Game>();
            foreach (Game game in games)
            {
                game.SwitchPlayers();
            }
            Assert.AreEqual(12, games.Sum(x => x.CountPoints));
        }

        [TestMethod]
        public void CountPointsRealData()
        {
            using Parser parser = new("Inputs\\Day2.txt");
            ICollection<Game> games = parser.ReadContent<Game>();

            Assert.AreEqual(11063, games.Sum(x => x.CountPoints));
        }

        [TestMethod]
        public void CountPointsWithKnownOutcomeRealData()
        {
            using Parser parser = new("Inputs\\Day2.txt");
            ICollection<Game> games = parser.ReadContent<Game>();
            foreach (Game game in games)
            {
                game.SwitchPlayers();
            }
            Assert.AreEqual(10349, games.Sum(x => x.CountPoints));
        }
    }
}