using System.Text.Json;
using System.Text.Json.Nodes;

namespace AdventOfCode2022Library
{
    public class DistressSignal : IMyParsable<DistressSignal>
    {
        public dynamic Right = 0;
        public dynamic Left = 0;

        public static DistressSignal Parse(string s)
        {
            return new DistressSignal()
            {
                Left = JsonSerializer.Deserialize<dynamic>(s.Split('\n')[0])!,
                Right = JsonSerializer.Deserialize<dynamic>(s.Split('\n')[1])!,
            };
        }

        public int Verify => Compare(Left, Right) >= 0 ? 0 : 1;

        public static List<dynamic> ListOfAllSignals(List<DistressSignal> list)
        {
            List<dynamic> ReturnList = new()
            {
                JsonSerializer.Serialize(new List<List<int>>() { new List<int>() { 2 } }),
                JsonSerializer.Serialize(new List<List<int>>() { new List<int>() { 6 } })
            };
            ReturnList.AddRange(list.Select(x => x.Left));
            ReturnList.AddRange(list.Select(x => x.Right));

            return ReturnList;
        }
        public static int Compare(dynamic Left, dynamic Right)
        {
            try
            {
                return JsonSerializer.Deserialize<int>(Left) - JsonSerializer.Deserialize<int>(Right);
            }
            catch(JsonException) { }
            try
            {
                return Compare(JsonSerializer.Serialize(new List<int>() { JsonSerializer.Deserialize<int>(Left) }), Right);
            }
            catch (JsonException) { }
            try
            {
                return Compare(Left, JsonSerializer.Serialize(new List<int>() { JsonSerializer.Deserialize<int>(Right) }));
            }
            catch (JsonException) { }

            if (JsonSerializer.Deserialize<dynamic[]>(Right) is dynamic[] right &&
                JsonSerializer.Deserialize<dynamic[]>(Left) is dynamic[] left)
            {
                for (int i = 0; i < left.Length; i++)
                {
                    if (i >= right.Length)
                    {
                        return 1;
                    }
                    int result = Compare(left[i], right[i]);
                    if (result != 0)
                    {
                        return result;
                    }
                }
                return left.Length - right.Length;
            }
            throw new NotSupportedException();
        }
    }
}
