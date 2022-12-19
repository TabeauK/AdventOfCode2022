using System.Text.RegularExpressions;

namespace AdventOfCode2022Library
{
    public partial class Sensor: IMyParsable<Sensor>
    {
        public (int column, int row) SensorPosition;
        public (int column, int row) BeaconPosition;

        public (int start, int end)? GetRowCoverage(int nr)
        {
            int radius = Math.Abs(SensorPosition.row - BeaconPosition.row) +
                         Math.Abs(SensorPosition.column - BeaconPosition.column);
            int rowDiff = Math.Abs(SensorPosition.row - nr);
            if (rowDiff > radius)
                return null;
            return (SensorPosition.column - radius + rowDiff,
                    SensorPosition.column + radius - rowDiff);
        }

        public static bool DoesOverlap((int start, int end) v1, (int start, int end) v2)
        {
            return v1.start <= v2.start && v1.end >= v2.end ||
                   v1.start >= v2.start && v1.end <= v2.end ||
                   v1.start >= v2.start && v1.start <= v2.end ||
                   v1.end >= v2.start && v1.end <= v2.end ||
                   Math.Abs(v1.end - v2.start) == 1 ||
                   Math.Abs(v1.start - v2.end) == 1;
        }

        private static List<(int start, int end)> GetLine(ICollection<Sensor> list, int nr)
        {
            List<(int start, int end)?> queue = list
                .Select(x => x.GetRowCoverage(nr))
                .Where(x => x.HasValue)
                .ToList();
            List<(int start, int end)> finalList = new();
            while (queue.Count > 0)
            {
                (int start, int end) current = queue.First()!.Value;
                queue.RemoveAt(0);
                (int start, int end)? next = queue.FirstOrDefault(
                    x => DoesOverlap(x!.Value, current), null);
                if (next.HasValue)
                {
                    queue.Remove(next);
                    queue.Add((
                        Math.Min(current.start, next.Value.start),
                        Math.Max(current.end, next.Value.end)));
                }
                else
                {
                    finalList.Add(current);
                }
            }
            return finalList;
        }

        public static int GetAllLineCoverage(ICollection<Sensor> list, int nr)
        {

            return GetLine(list, nr)
                    .Sum(x => x.end - x.start + 1) -
                list.Select(x => x.BeaconPosition)
                    .Where(x => x.row == nr)
                    .Distinct()
                    .Count();
        }

        public static (int, int) GetPointNotCovered(ICollection<Sensor> list, int AreaSize)
        {
            for(int i = 0; i < AreaSize; i++)
            {
                List<(int start, int end)> possible = GetLine(list, i)
                    .Where(x =>
                        x.end < AreaSize && x.end > 0 ||
                        x.start < AreaSize && x.start > 0)
                    .OrderBy(x => x.end)
                    .ToList();
                if (possible.Count == 2)
                {
                    return (possible[0].end + 1, i);
                }
                else if(possible.Count == 1)
                {
                    if(possible.First().start > 0)
                    {
                        return (0, i);
                    }
                    else
                    {
                        return (AreaSize, i);
                    }
                }

            }
            throw new NotSupportedException();
        }

        public static Sensor Parse(string s)
        {
            int[] values = MyRegex()
                .Matches(s)
                .Select(x => int.Parse(x.Value))
                .ToArray();
            return new()
            {
                SensorPosition = (values[0], values[1]),
                BeaconPosition = (values[2], values[3])
            };
        }

        [GeneratedRegex("-?\\d+")]
        private static partial Regex MyRegex();
    }
}

