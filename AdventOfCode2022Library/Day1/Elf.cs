namespace AdventOfCode2022Library.Day1
{
    public class Elf : IComparable<Elf>
    {
        public int id;
        public List<Food> foodList;
        public Elf(int id)
        {
            this.id = id;
            foodList = new List<Food>();
        }

        public Elf(int id, params Food[] foods)
        {
            this.id = id;
            foodList = foods.ToList();
        }

        public int SumCalories()
        {
            return foodList.Sum(x => x.Calories);
        }

        public int CompareTo(Elf? other)
        {
            if (other == null)
            {
                return -1;
            }
            return SumCalories() - other.SumCalories();
        }

    }
}