namespace AdventOfCode2022Library
{
    public class Sequence: IMyParsable<Sequence>
    {
        public List<int> Seq = new();

        public LinkedList<Dummy> LinkedList = new();

        public List<Dummy> List = new();

        public static Sequence Parse(string s)
        {
            List<int> seq = new();
            string[] numbers = s.Split('\n');
            foreach(string number in numbers)
            {
                seq.Add(int.Parse(number));
            }
            return new() { Seq = seq };
        }

        public void Init(long modifier = 1)
        {
            List.Clear();
            LinkedList.Clear();
            foreach(int elem in Seq)
            {
                Dummy dummy = new() { Value = elem * modifier };
                List.Add(dummy);
                LinkedList.AddLast(dummy);
                dummy.node = LinkedList.Last!;
            }
        }

        public void Calculate(int times = 1)
        {
            for (int j = 0; j < times; j++)
            {
                foreach (Dummy dummy in List)
                {
                    LinkedListNode<Dummy>? temp = dummy.node;
                    if (dummy.Value % (Seq.Count - 1) == 0)
                    {
                        continue;
                    }
                    else if (dummy.Value > 0)
                    {
                        for (long i = 0; i < dummy.Value % (Seq.Count - 1); i++)
                        {
                            temp = temp!.Next;
                            if (temp == null)
                            {
                                temp = LinkedList.First!;
                            }
                        }
                        LinkedList.Remove(dummy.node!);
                        dummy.node = LinkedList.AddAfter(temp!, dummy);
                    }
                    else if (dummy.Value < 0)
                    {
                        for (long i = 0; i > dummy.Value % (Seq.Count - 1); i--)
                        {
                            temp = temp!.Previous;
                            if (temp == null)
                            {
                                temp = LinkedList.Last!;
                            }
                        }
                        LinkedList.Remove(dummy.node!);
                        dummy.node = LinkedList.AddBefore(temp!, dummy);
                    }
                }
            }
        }

        public long GetValues()
        {
            List<Dummy> l = LinkedList.ToList();
            int i = l.FindIndex(x => x.Value == 0);
            return (new List<int>() { 1000 + i, 2000 + i, 3000 + i}).Sum(x => l[x % l.Count].Value);
        }

        public long Run()
        {
            Init();
            Calculate();
            return GetValues();
        }

        public long RunLonger()
        {
            Init(811589153);
            Calculate(10);
            return GetValues();
        }
    }

    public class Dummy
    {
        public long Value { get; set; }

        public LinkedListNode<Dummy>? node { get; set; }
    }
}

