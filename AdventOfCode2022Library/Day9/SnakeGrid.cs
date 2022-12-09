namespace AdventOfCode2022Library
{
    public class SnakeGrid
    {

        public string moves = "";

        public SnakeGrid(List<SnakeMove> moves)
        {
            this.moves = string.Join(null, moves.Select(x => x.moves));
            snakePositions.Add(new());
            for (int i = 0; i < 10; i++)
            {
                snakePositions[0].Add((1,1));
            }

        }

        public List<List<(int r, int c)>> snakePositions = new();

        public List<(int r, int c)> GetTailPositions(int i) => snakePositions.Select(x => (x[i].r, x[i].c)).ToList();

        public void ApplyMoves()
        {
            for (int i = 0; i < moves.Length; i++)
            {
                snakePositions.Add(MoveSnake(snakePositions.Last(), i));
            }
        }

        public List<(int r, int c)> MoveSnake(List<(int r, int c)> pos, int iter)
        {
            List<(int r, int c)> snakePosition = new();
            (int r, int c) Head = (pos[0].r, pos[0].c);
            ApplyMove(ref Head, iter);
            snakePosition.Add(Head);
            for (int i = 1; i < pos.Count; i++)
            {
                Head = (pos[i].r, pos[i].c);
                if (i != 0 &&
                    Math.Pow(snakePosition.Last().r - pos[i].r, 2) +
                    Math.Pow(snakePosition.Last().c - pos[i].c, 2) >= 4)
                {
                    Head.r += (snakePosition.Last().r > Head.r ? 1 : 0) - (snakePosition.Last().r < Head.r ? 1 : 0);
                    Head.c += (snakePosition.Last().c > Head.c ? 1 : 0) - (snakePosition.Last().c < Head.c ? 1 : 0);
                }
                snakePosition.Add(Head);
            }
            return snakePosition;
        }

        public void ApplyMove(ref (int r, int c) pos, int i)
        {
            switch (this.moves[i])
            {
                case 'U':
                    pos.c++;
                    break;
                case 'D':
                    pos.c--;
                    break;
                case 'L':
                    pos.r--;
                    break;
                case 'R':
                    pos.r++;
                    break;
                default:
                    break;
            }
        }
    }
}
