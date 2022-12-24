using System.Linq;

namespace AdventOfCode2022Library
{
    public class Valley: IMyParsable<Valley>
    {
        Dictionary<int, List<(int start, bool oppositeDirection)>> BlizzardsOnRows = new();

        Dictionary<int, List<(int start, bool oppositeDirection)>> BlizzardsOnColumns = new();

        (int row, int column) StartingPoint;

        (int row, int column) EndingPoint;

        int RowSize;

        int ColumnSize;

        public int Run(int startingMinute = 0, bool switchDirections = false)
        {
            (int, int) startingPoint = StartingPoint;
            (int, int) endingPoint = EndingPoint;
            if(switchDirections)
            {
                startingPoint = EndingPoint;
                endingPoint = StartingPoint;
            }
            Queue<((int, int), int)> queue = new();
            queue.Enqueue((startingPoint, startingMinute));
            while(queue.Count > 0)
            {
                ((int, int) point, int minute) = queue.Dequeue();
                foreach((int, int) nextPoint in NextPossiblePositions(point, minute + 1))
                {
                    if(nextPoint == endingPoint)
                    {
                        return minute + 1;
                    }
                    if (!queue.Contains((nextPoint, minute + 1)))
                    {
                        queue.Enqueue((nextPoint, minute + 1));
                    }
                }
            }
            throw new NotSupportedException();
        }

        List<(int, int)> NextPossiblePositions((int row, int column) current, int minute)
        {
            return new List<(int, int)>()
            {
                (current.row + 1, current.column),
                (current.row, current.column + 1),
                (current.row, current.column),
                (current.row - 1, current.column),
                (current.row, current.column - 1)
            }
            .Where(position =>
            {
                (int row, int column) = position;
                if(position == StartingPoint || position == EndingPoint)
                {
                    return true;
                }
                if (position.Item1 < 1 || position.Item1 > ColumnSize ||
                    position.Item2 < 1 || position.Item2 > RowSize)
                {
                    return false;
                }
                return
                BlizzardsOnColumns[column].All(blizzard =>
                {
                    (int start, bool oppositeDirection) = blizzard;
                    return
                    (oppositeDirection && (start - 1 - (minute % ColumnSize) + ColumnSize) % ColumnSize != row - 1) ||
                    (!oppositeDirection && (start - 1 + minute) % ColumnSize != row - 1);
                })
                &&
                BlizzardsOnRows[row].All(blizzard =>
                {
                    (int start, bool oppositeDirection) = blizzard;
                    return
                    (oppositeDirection && (start - 1 - (minute % RowSize) + RowSize) % RowSize != column - 1) ||
                    (!oppositeDirection && (start - 1 + minute) % RowSize != column - 1);
                });
            })
            .ToList();
        }

        public static Valley Parse(string s)
        {
            Valley valley = new();
            string[] lines = s.Split('\n');
            valley.StartingPoint = (0, lines[0].ToList().FindIndex(x => x == '.'));
            valley.EndingPoint = (lines.Length - 1, lines[lines.Length - 1].ToList().FindIndex(x => x == '.'));
            valley.RowSize = lines[0].Length - 2;
            valley.ColumnSize = lines.Length - 2;
            for (int i = 1; i < lines.Length - 1; i++)
            {
                valley.BlizzardsOnRows.Add(i, new());
            }
            for (int i = 1; i < lines[0].Length - 1; i++)
            {
                valley.BlizzardsOnColumns.Add(i, new());
            }
            for (int i = 1; i < lines.Length - 1; i++)
            {
                for(int j = 1; j < lines[i].Length - 1; j++)
                {
                    if (lines[i][j] == '>')
                    {
                        valley.BlizzardsOnRows[i].Add((j, false));
                    }
                    else if (lines[i][j] == '<')
                    {
                        valley.BlizzardsOnRows[i].Add((j, true));
                    }
                    else if (lines[i][j] == '^')
                    {
                        valley.BlizzardsOnColumns[j].Add((i, true));
                    }
                    else if (lines[i][j] == 'v')
                    {
                        valley.BlizzardsOnColumns[j].Add((i, false));
                    }
                }
            }
            return valley;
        }
    }
}

