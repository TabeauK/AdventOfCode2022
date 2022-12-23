using System.Text.RegularExpressions;

namespace AdventOfCode2022Library
{
    public class ForceFieldPlainMap: ForceFieldMap, IMyParsable<ForceFieldPlainMap>
    {
        public static ForceFieldPlainMap Parse(string s)
        {
            ForceFieldPlainMap map = new();
            string[] lines = s.Split('\n');
            Dictionary<int, ForceField> FirstLine = new();
            Dictionary<int, ForceField> PrevLine = new();
            for (int i = 0; i < lines.Length; i++)
            {
                ForceField? first = null, last = null;
                for(int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] != ' ')
                    {
                        ForceField temp = new()
                        {
                            Sign = lines[i][j],
                            Row = i + 1,
                            Column = j + 1,
                        };
                        if(last is null)
                        {
                            first = last = temp;
                            if(i == 0)
                            {
                                map.StartField = temp;
                            }
                        }
                        else
                        {
                            last.Right = temp;
                            temp.Left = last;
                        }
                        last = temp;
                        if (PrevLine.TryGetValue(j, out ForceField? field))
                        {
                            field.Down = temp;
                            temp.Up = field;
                            PrevLine[j] = temp;
                        }
                        else
                        {
                            FirstLine.Add(j, temp);
                            PrevLine.Add(j, temp);
                        }
                    }
                }
                if(first is not null)
                {
                    last!.Right = first;
                    first!.Left = last;
                }
            }
            foreach(var field in PrevLine)
            {
                if (FirstLine.TryGetValue(field.Key, out ForceField? firstField))
                {
                    firstField.Up = field.Value;
                    field.Value.Down = firstField;
                }
            }
            return map;
        }
    }
}

