namespace AdventOfCode2022Library
{
    public class Chamber: IMyParsable<Chamber>
    {
        public int Width = 7;

        public List<Piece> Pieces = new();

        public string HotAir;

        public HashSet<(long, int)> map = new();

        public long Height = 0;

        public Dictionary<List<long>, (long i, long height)> tops = new();

        public Chamber(string hotAir)
        {
            HotAir = hotAir;
            Pieces.Add(new HorizontalWall());
            Pieces.Add(new Plus());
            Pieces.Add(new L());
            Pieces.Add(new VerticalWall());
            Pieces.Add(new Square());
            map.Add((0, 1));
            map.Add((0, 2));
            map.Add((0, 3));
            map.Add((0, 4));
            map.Add((0, 5));
            map.Add((0, 6));
            map.Add((0, 7));
        }

        public static Chamber Parse(string s)
        {
            return new(s);
        }

        public void RunSimulation(long times)
        {
            long iter = 0;
            for(long i = 0; i < times; i++)
            {
                if(i > 1000)
                {
                    List<long> temp = new();
                    temp.Add(i % Pieces.Count);
                    temp.Add(iter % HotAir.Length);
                    for (int j = 1; j <= Width; j++)
                    {
                        temp.Add(Height - map.Where(x => x.Item2 == j).Max(x => x.Item1));
                    }
                    if (tops.Keys.Where(x => Enumerable.SequenceEqual(x, temp)).ToList().Count > 0)
                    {
                        long h = Height - tops[tops.Keys.Where(x => Enumerable.SequenceEqual(x, temp)).First()].height;
                        long cycleLength = i - tops[tops.Keys.Where(x => Enumerable.SequenceEqual(x, temp)).First()].i;
                        long cycleCount = (times - i) / cycleLength;
                        times -= cycleLength * cycleCount;
                        Height += cycleCount * h;
                        for(int j = 1; j < Width; j++)
                        {
                            map.Add((Height - temp[j + 1], j));
                        }
                        tops.Clear();
                    }
                    else
                    {
                        tops.Add(temp, (i, Height));
                    }
                }
                (long, int) startingPoint = (Height + 4, 3);
                bool isOk = true;
                while (isOk)
                {
                    if (HotAir[(int)(iter % HotAir.Length)] == '>' &&
                        Pieces[(int)(i % Pieces.Count)].VectorList.All(x =>
                            CanMove((startingPoint.Item1 + x.Item1, startingPoint.Item2 + x.Item2 + 1))
                        ))
                    {
                        startingPoint.Item2++;
                    }
                    else if (HotAir[(int)(iter % HotAir.Length)] == '<' &&
                        Pieces[(int)(i % Pieces.Count)].VectorList.All(x =>
                            CanMove((startingPoint.Item1 + x.Item1, startingPoint.Item2 + x.Item2 - 1))
                        ))
                    {
                        startingPoint.Item2--;
                    }
                    iter++;
                    if (Pieces[(int)(i % Pieces.Count)].VectorList.All(x =>
                            CanMove((startingPoint.Item1 + x.Item1 - 1, startingPoint.Item2 + x.Item2))
                       ))
                    {
                        startingPoint.Item1--;
                    }
                    else
                    {
                        foreach((int r, int c) in Pieces[(int)(i % Pieces.Count)].VectorList)
                        {
                            map.Add((startingPoint.Item1 + r, startingPoint.Item2 + c));
                            Height = Math.Max(Height, startingPoint.Item1 + r);
                        }                        isOk = false;
                    }
                }
            }
        }

        public bool CanMove((long, int) NewPlace)
        {
            return !(map.Contains(NewPlace) || NewPlace.Item2 > Width || NewPlace.Item2 <= 0);
        }
    }
}

