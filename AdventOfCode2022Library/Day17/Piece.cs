namespace AdventOfCode2022Library
{
    public abstract class Piece
    {
        public List<(int, int)> VectorList = new();
    }

    public class L : Piece
    {
        public L()
        {
            VectorList = new List<(int, int)>()
            {
                (0 ,0),
                (0, 1),
                (0, 2),
                (1, 2),
                (2, 2)
            };
        }
    }

    public class Plus : Piece
    {
        public Plus()
        {
            VectorList = new List<(int, int)>()
            {
                (1 ,0),
                (0, 1),
                (1, 1),
                (1, 2),
                (2, 1)
            };
        }
    }

    public class VerticalWall : Piece
    {
        public VerticalWall()
        {
            VectorList = new List<(int, int)>()
            {
                (0 ,0),
                (1, 0),
                (2, 0),
                (3, 0)
            };
        }
    }

    public class HorizontalWall : Piece
    {
        public HorizontalWall()
        {
            VectorList = new List<(int, int)>()
            {
                (0 ,0),
                (0, 1),
                (0, 2),
                (0, 3)
            };
        }
    }

    public class Square : Piece
    {
        public Square()
        {
            VectorList = new List<(int, int)>()
            {
                (0 ,0),
                (0, 1),
                (1, 0),
                (1, 1)
            };
        }
    }
}

