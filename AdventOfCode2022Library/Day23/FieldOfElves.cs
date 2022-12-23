using System.Data.Common;
using System.Diagnostics;

namespace AdventOfCode2022Library
{
    public class FieldOfElves : IMyParsable<FieldOfElves>
    {
        readonly List<(long row, long column)> Elves = new();

        private long NMost = 0;

        private long SMost = 0;

        private long WMost = 0;

        private long EMost = 0;

        public long GetArea => (SMost - NMost + 1) * (EMost - WMost + 1) - Elves.Count;

        private bool CheckN(ref long toRow, long toColumn)
        {
            if (!Elves.Contains((toRow - 1, toColumn)) &&
                       !Elves.Contains((toRow - 1, toColumn + 1)) &&
                       !Elves.Contains((toRow - 1, toColumn - 1)))
            {
                toRow -= 1;
                return true;
            }
            return false;
        }

        private bool CheckS(ref long toRow, long toColumn)
        {
            if (!Elves.Contains((toRow + 1, toColumn)) &&
                       !Elves.Contains((toRow + 1, toColumn + 1)) &&
                       !Elves.Contains((toRow + 1, toColumn - 1)))
            {
                toRow += 1;
                return true;
            }
            return false;
        }

        private bool CheckW(long toRow, ref long toColumn)
        {
            if (!Elves.Contains((toRow + 1, toColumn - 1)) &&
                       !Elves.Contains((toRow, toColumn - 1)) &&
                       !Elves.Contains((toRow - 1, toColumn - 1)))
            {
                toColumn -= 1;
                return true;
            }
            return false;
        }

        private bool CheckE(long toRow, ref long toColumn)
        {
            if (!Elves.Contains((toRow + 1, toColumn + 1)) &&
                       !Elves.Contains((toRow, toColumn + 1)) &&
                       !Elves.Contains((toRow - 1, toColumn + 1)))
            {
                toColumn += 1;
                return true;
            }
            return false;
        }

        public long Run(long times = long.MaxValue - 1)
        {
            int i = 0;
            for(; i < times; i++)
            {
                Dictionary<(long, long), int> MoveTo = new();
                for(int j = 0; j < Elves.Count; j++)
                {
                    long toColumn = Elves[j].column;
                    long toRow = Elves[j].row;
                    if(!Elves.Contains((toRow - 1, toColumn)) &&
                       !Elves.Contains((toRow + 1, toColumn)) &&
                       !Elves.Contains((toRow, toColumn - 1)) &&
                       !Elves.Contains((toRow, toColumn + 1)) &&
                       !Elves.Contains((toRow - 1, toColumn + 1)) &&
                       !Elves.Contains((toRow - 1, toColumn - 1)) &&
                       !Elves.Contains((toRow + 1, toColumn - 1)) &&
                       !Elves.Contains((toRow + 1, toColumn + 1)))
                    {
                        continue;
                    }
                    for(int k = 0; k < 4; k++)
                    {
                        if(((k + i) % 4) switch
                        {
                            0 => CheckN(ref toRow, toColumn),
                            1 => CheckS(ref toRow, toColumn),
                            2 => CheckW(toRow, ref toColumn),
                            3 => CheckE(toRow, ref toColumn),
                            _ => true
                        })
                        {
                            break;
                        }
                    }
                    if(toColumn != Elves[j].column || toRow != Elves[j].row)
                    {
                        if(MoveTo.ContainsKey((toRow, toColumn)))
                        {
                            MoveTo[(toRow, toColumn)] = -1;
                        }
                        else
                        {
                            MoveTo.Add((toRow, toColumn), j);
                        }
                    }
                }
                if(!MoveTo.Any(x => x.Value != -1))
                {
                    break;
                }
                foreach(var move in MoveTo)
                {
                    if(move.Value != -1)
                    {
                        Elves[move.Value] = move.Key;
                        NMost = Math.Min(NMost, move.Key.Item1);
                        WMost = Math.Min(WMost, move.Key.Item2);
                        SMost = Math.Max(SMost, move.Key.Item1);
                        EMost = Math.Max(EMost, move.Key.Item2);
                    }
                }
                if (Elves.All(x => x.row > NMost)) NMost++;
                if (Elves.All(x => x.column > WMost)) WMost++;
                if (Elves.All(x => x.row < SMost)) SMost--;
                if (Elves.All(x => x.column < EMost)) EMost--;
            }
            return i + 1;
        }

        public static FieldOfElves Parse(string s)
        {
            FieldOfElves field = new();
            string[] lines = s.Split('\n');

            for(int i = 0; i < lines.Length; i++)
            {
                for(int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == '#')
                    {
                        field.Elves.Add((i, j));
                        field.NMost = Math.Min(field.NMost, i);
                        field.WMost = Math.Min(field.WMost, j);
                        field.SMost = Math.Max(field.SMost, i);
                        field.EMost = Math.Max(field.EMost, j);
                    }
                }
            }

            return field;
        }
    }
}

