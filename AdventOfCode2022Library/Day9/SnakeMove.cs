namespace AdventOfCode2022Library
{
    public class SnakeMove: IMyParsable<SnakeMove>
    {
        public string moves = "";

        public static SnakeMove Parse(string s)
        {
            string move = "";
            string orientation = s.Split(' ')[0];
            for(int i = 0; i < int.Parse(s.Split(' ')[1]); i++)
            {
                move += orientation;
            }

            return new SnakeMove()
            {
                moves = move
            };
        }
    }
}
