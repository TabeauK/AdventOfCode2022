namespace AdventOfCode2022Library
{
    public class ForceFieldCubeMap : ForceFieldMap, IMyParsable<ForceFieldCubeMap>
    {
        public static int Size;

        public static List<(int wallFrom, int sideFrom, int wallTo, int sideTo, bool inverted, int directionChange)> Connections = new();

        public static List<(int nr, int rowStart, int columnStart)> WallOnAPlain = new();

        public static void SetUseCase(bool test)
        {
            if(test)
            {
                Size = 4;
                Connections = new()
                {
                    (1, 0, 6, 0, true, 2),
                    (1, 1, 4, 3, false, 0),
                    (1, 2, 3, 3, false, 3),
                    (1, 3, 2, 3, true, 2),
                    (2, 0, 3, 2, false, 0),
                    (2, 2, 6, 1, true, 1),
                    (4, 0, 6, 3, true, 1),
                    (4, 2, 3, 0, false, 0),
                    (5, 0, 6, 2, false, 0),
                    (5, 1, 2, 1, true, 2),
                    (5, 2, 3, 1, true, 1),
                    (5, 3, 4, 1, false, 0),
                };
                WallOnAPlain = new()
                {
                    (1, 0, 2 * Size),
                    (2, Size, 0),
                    (3, Size, Size),
                    (4, Size, 2 * Size),
                    (5, 2 * Size, 2 * Size),
                    (6, 2 * Size, 3 * Size),
                };
            }
            else
            {
                Size = 50;
                Connections = new()
                {
                    (1, 0, 2, 2, false, 0),
                    (1, 1, 3, 3, false, 0),
                    (1, 2, 4, 2, true, 2),
                    (1, 3, 6, 2, false, 1),
                    (2, 1, 3, 0, false, 1),
                    (2, 3, 6, 1, false, 0),
                    (4, 1, 6, 3, false, 0),
                    (4, 3, 3, 2, false, 1),
                    (5, 0, 2, 0, true, 2),
                    (5, 1, 6, 0, false, 1),
                    (5, 2, 4, 0, false, 0),
                    (5, 3, 3, 1, false, 0),
                };
                WallOnAPlain = new()
                {
                    (1, 0, Size),
                    (2, 0, 2 * Size),
                    (3, Size, Size),
                    (4, 2 * Size, 0),
                    (5, 2 * Size, Size),
                    (6, 3 * Size, 0),
                };
            }

        }

        public static void SetConnection(List<List<List<ForceField>>> walls, List<(int, int, int, int, bool, int)> connection)
        {
            foreach ((int wallFrom, int sideFrom, int wallTo, int sideTo, bool inverted, int directionChange) in connection)
            {
                for(int i = 0; i < Size; i++)
                {
                    ForceField from = walls[wallFrom - 1][sideFrom switch
                    {
                        0 => i,
                        1 => Size - 1,
                        2 => i,
                        3 => 0,
                        _ => 0
                    }][sideFrom switch
                    {
                        0 => Size - 1,
                        1 => i,
                        2 => 0,
                        3 => i,
                        _ => 0
                    }];

                    ForceField to = walls[wallTo - 1][sideTo switch
                    {
                        0 => inverted ? Size - 1 - i : i,
                        1 => Size - 1,
                        2 => inverted ? Size - 1 - i : i,
                        3 => 0,
                        _ => 0
                    }][sideTo switch
                    {
                        0 => Size - 1,
                        1 => inverted ? Size - 1 - i : i,
                        2 => 0,
                        3 => inverted ? Size - 1 - i : i,
                        _ => 0
                    }];

                    switch(sideFrom)
                    {
                        case 0:
                            from.Right = to;
                            from.RightChangeDirection = directionChange;
                            break;
                        case 1:
                            from.Down = to;
                            from.DownChangeDirection = directionChange;
                            break;
                        case 2:
                            from.Left = to;
                            from.LeftChangeDirection = directionChange;
                            break;
                        case 3:
                            from.Up = to;
                            from.UpChangeDirection = directionChange;
                            break;
                        default:
                            break;
                    }; 
                }
            }
        }

        public static ForceFieldCubeMap Parse(string s)
        {
            ForceFieldCubeMap cube = new();
            string[] lines = s.Split('\n');
            List<List<List<ForceField>>> walls = new();

            foreach((int nr, int rowStart, int columnStart) in WallOnAPlain)
            {
                walls.Add(new List<List<ForceField>>());
                for(int i = rowStart; i < rowStart + Size; i++)
                {
                    walls[nr - 1].Add(new List<ForceField>());
                    for(int j = columnStart; j < columnStart + Size; j++)
                    {
                        walls[nr - 1][i - rowStart].Add(new ForceField()
                        {
                            Row = i + 1,
                            Column = j + 1,
                            Sign = lines[i][j]
                        });
                    }
                }
            }
            cube.StartField = walls[0][0][0];

            for (int w = 0; w < walls.Count; w++)
            {
                List<List<ForceField>> wall = walls[w];
                for (int i = 0; i < Size; i++)
                {
                    for(int j = 0; j < Size; j++)
                    {
                        if(i != 0)
                        {
                            wall[i][j].Up = wall[i - 1][j];
                        }
                        if(i != Size - 1)
                        {
                            wall[i][j].Down = wall[i + 1][j];
                        }
                        if (j != 0)
                        {
                            wall[i][j].Left = wall[i][j - 1];   
                        }
                        if (j != Size - 1)
                        {
                            wall[i][j].Right = wall[i][j + 1];
                        }
                    }
                }
            }

            SetConnection(walls, Connections);
            SetConnection(walls, Connections
                .Select(x =>
                    (x.Item3, x.Item4, x.Item1, x.Item2, x.Item5, x.Item6 % 2 == 0 ? x.Item6 : (x.Item6 + 2) % 4))
                .ToList());

            return cube;
        }
    }
}
