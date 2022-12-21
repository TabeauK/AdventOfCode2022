namespace AdventOfCode2022Library
{
    public class MonkeyOperation: IMyParsable<MonkeyOperation>
    {
        public static Dictionary<string, MonkeyOperation> Monkeys = new();

        public static bool Part2 = false;

        public string Name = "";

        public long? Value = null;

        private delegate void EventHandler(object sender, long Value);

        private event EventHandler Event;

        private char Operation = '+';

        private long? FirstValue = null;

        private long? SecondValue = null;

        private string? FirstName = null;

        private string? SecondName = null;

        public bool IsFinished = false;

        protected virtual void RaiseEvent()
        {
            Event?.Invoke(this, Value!.Value);
        }

        private void AssignValue()
        {
            Value = Operation switch
            {
                '+' => FirstValue!.Value + SecondValue!.Value,
                '-' => FirstValue!.Value - SecondValue!.Value,
                '*' => FirstValue!.Value * SecondValue!.Value,
                '/' => FirstValue!.Value / SecondValue!.Value,
                _ => throw new NotSupportedException()
            };
            IsFinished = true;
            RaiseEvent();
        }

        public long GetValue(long number = 0)
        {
            if(Name == "humn")
            {
                return number;
            }
            if(FirstValue.HasValue)
            {
                return Monkeys[SecondName!].GetValue(Operation switch
                {
                    '+' => number - FirstValue!.Value,
                    '-' => FirstValue!.Value - number,
                    '*' => number / FirstValue!.Value,
                    '/' => FirstValue!.Value / number,
                    '=' => FirstValue!.Value,
                    _ => throw new NotSupportedException()
                });
            }
            else if(SecondValue.HasValue)
            {
                return Monkeys[FirstName!].GetValue(Operation switch
                {
                    '+' => number - SecondValue!.Value,
                    '-' => number + SecondValue!.Value,
                    '*' => number / SecondValue!.Value,
                    '/' => number * SecondValue!.Value,
                    '=' => SecondValue!.Value,
                    _ => throw new NotSupportedException()
                });
            }
            throw new NotSupportedException();
        }

        private void MonkeyOperation_Event1(object sender, long value)
        {
            if (sender != this && !IsFinished)
            {
                FirstValue = value;
                if (SecondValue.HasValue)
                {
                    AssignValue();
                }
            }
        }

        private void MonkeyOperation_Event2(object sender, long value)
        {
            if (sender != this && !IsFinished)
            {
                SecondValue = value;
                if (FirstValue.HasValue)
                {
                    AssignValue();
                }
            }
        }

        public static MonkeyOperation Parse(string s)
        { 
            string name = s.Split(':')[0];
            if (!Monkeys.ContainsKey(name))
            {
                Monkeys.Add(name, new() { Name = name });
            }

            if (s.Split(':')[1].Split(' ').Length > 2)
            {
                string firstName = s.Split(':')[1].Split(' ')[1];
                string operation = s.Split(':')[1].Split(' ')[2];
                string secondName = s.Split(':')[1].Split(' ')[3];
                Monkeys[name].FirstName = firstName;
                Monkeys[name].SecondName = secondName;
                Monkeys[name].Operation = operation[0];
                if(Part2 && name == "root")
                {
                    Monkeys[name].Operation = '=';
                }
                if(!Monkeys.ContainsKey(firstName))
                {
                    Monkeys.Add(firstName, new() { Name = firstName });
                }
                if (Monkeys[firstName].IsFinished)
                {
                    Monkeys[name].FirstValue = Monkeys[firstName].Value;
                }
                else
                {
                    Monkeys[firstName].Event += Monkeys[name].MonkeyOperation_Event1;
                }
                if (!Monkeys.ContainsKey(secondName))
                {
                    Monkeys.Add(secondName, new() { Name = secondName });
                }
                if (Monkeys[secondName].IsFinished)
                {
                    Monkeys[name].SecondValue = Monkeys[secondName].Value;
                }
                else
                {
                    Monkeys[secondName].Event += Monkeys[name].MonkeyOperation_Event2;
                }
                if(Monkeys[name].FirstValue.HasValue && Monkeys[name].SecondValue.HasValue)
                {
                    Monkeys[name].AssignValue();
                }
            }
            else
            {
                if (!Part2 || name != "humn")
                {
                    Monkeys[name].Value = int.Parse(s.Split(':')[1].Split(' ')[1]);
                    Monkeys[name].IsFinished = true;
                    Monkeys[name].RaiseEvent();
                }
            }

            return Monkeys[name];
        }
    }
}

