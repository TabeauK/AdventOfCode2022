namespace AdventOfCode2022Library
{
    enum RockPaperScissor
    {
        Rock = 1,
        Paper = 2,
        Scissor = 3,
    }
    public class Game : IMyParsable<Game>
    {
        RockPaperScissor opponent;
        RockPaperScissor player;
        RockPaperScissor player2;
        public Game(string input)
        {
            string[] inputs = input.Split(' ');
            switch (inputs[0])
            {
                case "A":
                    opponent = RockPaperScissor.Rock;
                    break;
                case "B":
                    opponent = RockPaperScissor.Paper;
                    break;
                case "C":
                    opponent = RockPaperScissor.Scissor;
                    break;
                default:
                    break;
            }


            switch (inputs[1])
            {
                case "X":
                    player2 =
                        opponent == RockPaperScissor.Paper ? RockPaperScissor.Rock :
                        opponent == RockPaperScissor.Scissor ? RockPaperScissor.Paper :
                        RockPaperScissor.Scissor;
                    break;
                case "Y":
                    player2 = opponent;
                    break;
                case "Z":
                    player2 =
                        opponent == RockPaperScissor.Paper ? RockPaperScissor.Scissor :
                        opponent == RockPaperScissor.Scissor ? RockPaperScissor.Rock :
                        RockPaperScissor.Paper;
                    break;
                default:
                    break;
            }

            switch (inputs[1])
            {
                case "X":
                    player = RockPaperScissor.Rock;
                    break;
                case "Y":
                    player = RockPaperScissor.Paper;
                    break;
                case "Z":
                    player = RockPaperScissor.Scissor;
                    break;
                default:
                    break;
            }
        }

        public void SwitchPlayers()
        {
            RockPaperScissor temp = player2;
            player2 = player;
            player = temp;
        }

        public bool DidPlayerWin =>
            (opponent == RockPaperScissor.Scissor && player == RockPaperScissor.Rock) ||
            (opponent == RockPaperScissor.Paper && player == RockPaperScissor.Scissor) ||
            (opponent == RockPaperScissor.Rock && player == RockPaperScissor.Paper);

        public bool DidPlayerDraw => opponent == player;

        public int CountPoints =>
            (int)player + (DidPlayerWin ? 6 : DidPlayerDraw ? 3 : 0);

        public static Game Parse(string s)
        {
            return new Game(s);
        }
    }
}
