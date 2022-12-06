using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022Library.Day2
{
    enum RockPaperScissor
    {
        Rock = 1,
        Paper = 2,
        Scissor = 3,
    }
    public class Game
    {
        RockPaperScissor opponent;
        RockPaperScissor player;
        public Game(string input, bool outcome = false)
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

            if(outcome)
            {
                switch (inputs[1])
                {
                    case "X":
                        player =
                            opponent == RockPaperScissor.Paper ? RockPaperScissor.Rock :
                            opponent == RockPaperScissor.Scissor ? RockPaperScissor.Paper :
                            RockPaperScissor.Scissor;
                        break;
                    case "Y":
                        player = opponent;
                        break;
                    case "Z":
                        player =
                            opponent == RockPaperScissor.Paper ? RockPaperScissor.Scissor :
                            opponent == RockPaperScissor.Scissor ? RockPaperScissor.Rock :
                            RockPaperScissor.Paper;
                        break;
                    default:
                        break;
                }
            }
            else
            {
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
        }

        public bool DidPlayerWin =>
            (opponent == RockPaperScissor.Scissor && player == RockPaperScissor.Rock) ||
            (opponent == RockPaperScissor.Paper && player == RockPaperScissor.Scissor) ||
            (opponent == RockPaperScissor.Rock && player == RockPaperScissor.Paper);

        public bool DidPlayerDraw => opponent == player;

        public int CountPoints =>
            (int)player + (DidPlayerWin ? 6 : DidPlayerDraw ? 3 : 0); 
    }
}
