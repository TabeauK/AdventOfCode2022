using System.Security.Cryptography.X509Certificates;
using AdventOfCode2022Library.Day2;

namespace AdventOfCode2022Test
{
    [TestClass]
    public class Day2
    {
        [TestMethod]
        public void CountPoints()
        {
            using Parser parser = new("TestInputs\\Day2.txt");
            ICollection<Game> games = parser.ReadGames();

            Assert.IsTrue(games.Sum(x => x.CountPoints) == 15);
        }

        [TestMethod]
        public void CountPointsWithKnownOutcome()
        {
            using Parser parser = new("TestInputs\\Day2.txt");
            ICollection<Game> games = parser.ReadGames(outcome: true);

            Assert.IsTrue(games.Sum(x => x.CountPoints) == 12);
        }
    }
}