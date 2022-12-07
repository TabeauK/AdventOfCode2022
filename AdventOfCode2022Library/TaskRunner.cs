﻿using AdventOfCode2022Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022Library
{
    public static class TaskRunner
    {
        public static void RunDay(string day)
        {
            Console.WriteLine(day);
            using Parser parser = new($"Inputs\\{day}.txt");
            switch (day)
            {
                case "Day1":
                    RunDay1(parser);
                    break;
                case "Day2":
                    RunDay2(parser);
                    break;
                case "Day3":
                    RunDay3(parser);
                    break;
                case "Day4":
                    RunDay4(parser);
                    break;
                case "Day5":
                    RunDay5(parser);
                    break;
                default:
                    break;
            }
        }

        public static void RunDay1(Parser parser)
        {
            ICollection<Elf> elves = parser.ReadMultilineContent<Elf>();
            if(elves == null || elves.Count == 0) { return; }
            Console.WriteLine("  Max calories: " + elves.ToList().Max()?.SumCalories());

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


        public static void RunDay2(Parser parser)
        {
            ICollection<Game> games = parser.ReadContent<Game>();
            Console.WriteLine("  Sum of points from all games: " + games.Sum(x => x.CountPoints));
            foreach (Game game in games)
            {
                game.SwitchPlayers();
            }
            Console.WriteLine("  Sum of points from all games with known outcome: " + games.Sum(x => x.CountPoints));
        }

        public static void RunDay3(Parser parser)
        {
            List<Rucksack> rucksacks = parser.ReadContent<Rucksack>().ToList();
            Console.WriteLine("  Sum of priorities of wrong item types: " + rucksacks.Sum(x => x.GetWrongItem));
            int count = 0;

            for (int i = 0; i < rucksacks.Count; i += 3)
            {
                count += Rucksack.Compare(rucksacks[i], rucksacks[i + 1], rucksacks[i + 2]);
            }

            Console.WriteLine("  Sum of priorities of badges: " + count);
        }

        public static void RunDay4(Parser parser)
        {
            List<CleaningPair> cleaningPair = parser.ReadContent<CleaningPair>().ToList();
            Console.WriteLine("  Pairs in which one contains another: " + cleaningPair.Count(x => x.DoesOneContainAnother));
            Console.WriteLine("  Pairs that overlap: " + cleaningPair.Count(x => x.Overlap));
        }

        public static void RunDay5(Parser parser)
        {
            Stacks stacks = parser.ReadMultilineContent<Stacks>().First();
            using Parser parser2 = new($"Inputs\\Day5_2.txt");
            stacks.instructions = parser2.ReadContent<Instructions>().ToList();
            stacks.ApplyInstructions();
            Console.WriteLine("  Top containers on stacks: " + stacks.GetResult);
            stacks.Repopulate();
            stacks.ApplyInstructions(CrateMover9001: true);
            Console.WriteLine("  Top containers on stacks with CrateMover9001: " + stacks.GetResult);
        }
    }
}
