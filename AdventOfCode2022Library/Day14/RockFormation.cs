namespace AdventOfCode2022Library
{
    public class RockFormation: IMyParsable<RockFormation>
    { 
        public HashSet<(int, int)> IsTaken = new();

        public HashSet<(int, int)> SandPlace = new();

        public int Max = 0;

        public (int, int) SandStart = (500, 0); 

        public static RockFormation Parse(string s)
        {
            HashSet<(int, int)> isTaken = new();
            int max = 0;
            for (int i = 0; i < s.Split("->").Length - 1; i++)
            {
                int X1 = int.Parse(s.Split("->")[i].Split(',')[0]);
                int Y1 = int.Parse(s.Split("->")[i].Split(',')[1]);
                int X2 = int.Parse(s.Split("->")[i + 1].Split(',')[0]);
                int Y2 = int.Parse(s.Split("->")[i + 1].Split(',')[1]);
                if(X2 < X1)
                {
                    int temp = X1;
                    X1 = X2;
                    X2 = temp;
                }
                if (Y2 < Y1)
                {
                    int temp = Y1;
                    Y1 = Y2;
                    Y2 = temp;
                }
                for (int j = X1; j <= X2; j++)
                {
                    for (int k = Y1; k <= Y2; k++)
                    {
                        isTaken.Add((j, k));
                    }
                    max = Y1 > max ? Y1 : Y2 > max ? Y2 : max;
                }
            }

            return new RockFormation()
            {
                IsTaken = isTaken,
                Max = max,
            };
        }

        public static RockFormation Combine(ICollection<RockFormation> list)
        {
            HashSet<(int, int)> isTaken = new();
            int max = 0;

            foreach(RockFormation formation in list)
            {
                isTaken.UnionWith(formation.IsTaken);
                max = Math.Max(max, formation.Max);
            }

            return new RockFormation()
            {
                IsTaken = isTaken,
                Max = max,
            };
        }

        public void AddFloor()
        {
            for(int i = SandStart.Item1 - Max - 5; i <= SandStart.Item1 + Max + 5; i++)
            {
                IsTaken.Add((i, Max + 2));
            }
            Max += 5;
        }

        public void FillWithSand()
        {
            bool full = false;
            while(!full)
            {
                full = MoveDown(SandStart);
            }
        }

        public bool MoveDown((int column, int row) currentPosition)
        {
            if (IsTaken.Contains(currentPosition) ||
                SandPlace.Contains(currentPosition) ||
                currentPosition.row >= Max)
            {
                return true;
            }
            if (!IsTaken.Contains((currentPosition.column, currentPosition.row + 1)) &&
                !SandPlace.Contains((currentPosition.column, currentPosition.row + 1)))
            {
                return MoveDown((currentPosition.column, currentPosition.row + 1));
            }
            else if (!IsTaken.Contains((currentPosition.column - 1, currentPosition.row + 1)) &&
                     !SandPlace.Contains((currentPosition.column - 1, currentPosition.row + 1)))
            {
                return MoveDown((currentPosition.column - 1, currentPosition.row + 1));
            }
            else if (!IsTaken.Contains((currentPosition.column + 1, currentPosition.row + 1)) &&
                     !SandPlace.Contains((currentPosition.column + 1, currentPosition.row + 1)))
            {
                return MoveDown((currentPosition.column + 1, currentPosition.row + 1));
            }
            else
            {
                SandPlace.Add(currentPosition);
                return false;
            }
        }
    }
}

