using System.Security.Cryptography.X509Certificates;
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

            Assert.IsTrue(games.Sum(x => x.CountPoints) == 15);
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
            Assert.IsTrue(games.Sum(x => x.CountPoints) == 12);
        }

        [TestMethod]
        public void CountPointsRealData()
        {
            using Parser parser = new("Inputs\\Day2.txt");
            ICollection<Game> games = parser.ReadContent<Game>();

            Assert.IsTrue(games.Sum(x => x.CountPoints) == 11063);
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
            Assert.IsTrue(games.Sum(x => x.CountPoints) == 10349);
        }
    }
}