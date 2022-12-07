namespace AdventOfCode2022Library
{
    public class MaskComparable
    {
        internal int[] Mask = new int[53];
        public int this[int i] => this.Mask[i];

        public static int Compare(params MaskComparable[] items)
        {
            for (int i = 1; i < 53; i++)
            {
                int multi = 1;
                foreach(MaskComparable mask in items)
                {
                    multi *= mask[i];
                }
                if (multi > 0)
                {
                    return i;
                }
            }
            throw new NotSupportedException();
        }

    }
}
