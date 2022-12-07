using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2022Library
{
    public class Elf : IComparable<Elf>, IMyParsable<Elf>
    {
        public static int freeId = 1;
        public int id;
        public List<int> Calories;
        public Elf()
        {
            id = freeId;
            Calories = new List<int>();
            freeId++;
        }

        public int SumCalories()
        {
            return Calories.Sum();
        }

        public int CompareTo(Elf? other)
        {
            if (other == null)
            {
                return -1;
            }
            return SumCalories() - other.SumCalories();
        }

        public static Elf Parse(string s)
        {
            return new Elf()
            {
                Calories = s.Split(';').Select(x => int.Parse(x)).ToList(),
            };
        }
    }
}