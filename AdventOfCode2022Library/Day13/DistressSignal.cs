using System.Text.Json;
namespace AdventOfCode2022Library
{
    public class DistressSignal : IMyParsable<DistressSignal>
    {
        public class SignalType
        {
            public int? Value = null;
            public List<SignalType>? List = null;
        }

        public SignalType Right = new();
        public SignalType Left = new();

        public static DistressSignal Parse(string s)
        {
            return new DistressSignal()
            {
                Left = Decrypt(JsonSerializer.Deserialize<dynamic>(s.Split('\n')[0])!),
                Right = Decrypt(JsonSerializer.Deserialize<dynamic>(s.Split('\n')[1])!),
            };
        }

        public int Verify => Compare(Left, Right) >= 0 ? 0 : 1;

        public static List<SignalType> ListOfAllSignals(List<DistressSignal> list)
        {
            List<SignalType> ReturnList = new()
            {
                new SignalType()
                {
                    List = new List<SignalType>()
                    {
                        new SignalType()
                        {
                            List = new List<SignalType>()
                            {
                                new SignalType
                                {
                                    Value = 2
                                }
                            }
                        }
                    }
                },
                new SignalType()
                {
                    List = new List<SignalType>()
                    {
                        new SignalType()
                        {
                            List = new List<SignalType>()
                            {
                                new SignalType
                                {
                                    Value = 6
                                }
                            }
                        }
                    }
                }
            };
            ReturnList.AddRange(list.Select(x => x.Left));
            ReturnList.AddRange(list.Select(x => x.Right));

            return ReturnList;
        }

        public static SignalType Decrypt(dynamic Encrypted)
        {
            try
            {
                return new SignalType()
                {
                    Value = JsonSerializer.Deserialize<int>(Encrypted)
                };   
            }
            catch (JsonException) { }

            if (JsonSerializer.Deserialize<dynamic[]>(Encrypted) is dynamic[] encrypted)
            {
                return new SignalType()
                {
                    List = encrypted.Select(x => (SignalType)Decrypt(x)).ToList()
                };
            }
            throw new NotSupportedException();
        }

        public static int Compare(SignalType Left, SignalType Right)
        {
            if(Left.Value.HasValue && Right.Value.HasValue)
            {
                return Left.Value!.Value - Right.Value!.Value;
            }
            if (Left.Value.HasValue)
            {
                return Compare(new SignalType() { List = new List<SignalType>() { Left } }, Right);
            }
            if (Right.Value.HasValue)
            {
                return Compare(Left, new SignalType() { List = new List<SignalType>() { Right } });
            }

            if (Left.List is not null &&
                Right.List is not null)
            {
                for (int i = 0; i < Left.List.Count; i++)
                {
                    if (i >= Right.List.Count)
                    {
                        return 1;
                    }
                    int result = Compare(Left.List[i], Right.List[i]);
                    if (result != 0)
                    {
                        return result;
                    }
                }
                return Left.List.Count - Right.List.Count;
            }
            throw new NotSupportedException();
        }
    }
}
