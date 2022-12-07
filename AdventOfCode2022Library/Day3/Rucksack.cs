namespace AdventOfCode2022Library
{
    public class Rucksack: MaskComparable, IMyParsable<Rucksack>
    {
        public Compartment left;
        public Compartment right;

        public Rucksack(string items) 
        {
            left = new Compartment(items.Substring(0, items.Length / 2));
            right = new Compartment(items.Substring(items.Length / 2, items.Length / 2));
            for (int i = 1; i < 53; i++)
            {
                Mask[i] = left[i] + right[i];
            }
        }

        public int GetWrongItem => Compare(left, right);

        public static Rucksack Parse(string s)
        {
            return new Rucksack(s);
        }
    }
}
