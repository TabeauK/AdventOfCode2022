// See https://aka.ms/new-console-template for more information
using AdventOfCode2022Library.Day1;
using AdventOfCode2022Library.Day2;
using AdventOfCode2022Library.Day3;

//Day1
Console.WriteLine("Day1");
using (AdventOfCode2022Library.Day1.Parser parser = new("Inputs\\Day1.txt"))
{
    ICollection<Elf> elves = parser.ReadElves();
    Console.WriteLine("  Max calories: " + elves.ToList().Max()?.SumCalories());
}

using (AdventOfCode2022Library.Day1.Parser parser = new("Inputs\\Day1.txt"))
{
    ICollection<Elf> elves = parser.ReadElves();
    int iter = 3;
    int count = 0;

    while (iter > 0)
    {
        count += elves.Max().SumCalories();
        elves.Remove(elves.Max());
        iter--;
    }

    Console.WriteLine("  Max calories from 3 elves: " + count);
}

//Day2
Console.WriteLine("Day2");
using (AdventOfCode2022Library.Day2.Parser parser = new("Inputs\\Day2.txt"))
{
    ICollection<Game> games = parser.ReadGames();

    Console.WriteLine("  Sum of points from all games: " + games.Sum(x => x.CountPoints));
}

using (AdventOfCode2022Library.Day2.Parser parser = new("Inputs\\Day2.txt"))
{
    ICollection<Game> games = parser.ReadGames(outcome: true);

    Console.WriteLine("  Sum of points from all games with known outcome: " + games.Sum(x => x.CountPoints));
}

//Day3
Console.WriteLine("Day3");
using (AdventOfCode2022Library.Day3.Parser parser = new("Inputs\\Day3.txt"))
{
    ICollection<Rucksack> rucksacks = parser.ReadRucksack();

    Console.WriteLine("  Sum of priorities of wrong item types: " + rucksacks.Sum(x => x.GetWrongItem));
}

using (AdventOfCode2022Library.Day3.Parser parser = new("Inputs\\Day3.txt"))
{
    List<Rucksack> rucksacks = parser.ReadRucksack().ToList();
    int count = 0;

    for (int i = 0; i < rucksacks.Count; i += 3)
    {
        count += Rucksack.Compare(rucksacks[i], rucksacks[i + 1], rucksacks[i + 2]);
    }

    Console.WriteLine("  Sum of priorities of badges: " + count);
}
