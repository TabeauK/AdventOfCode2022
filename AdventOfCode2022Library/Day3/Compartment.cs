namespace AdventOfCode2022Library
{
    public class Compartment: MaskComparable
    {
        string text;

        public Compartment(string items)
        {
            Array.Clear(Mask, 0, Mask.Length);
            this.text = items;
            foreach (char c in items)
            {
                if(char.IsUpper(c))
                {
                    Mask[c - 'A' + 27]++;
                }
                else
                {
                    Mask[c - 'a' + 1]++;
                }
            }
        }
    }
}
