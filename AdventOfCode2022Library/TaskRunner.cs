using System;
using System.IO;

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
                case "Day6":
                    RunDay6(parser);
                    break;
                case "Day7":
                    RunDay7(parser);
                    break;
                case "Day8":
                    RunDay8(parser);
                    break;
                case "Day9":
                    RunDay9(parser);
                    break;
                case "Day10":
                    RunDay10(parser);
                    break;
                case "Day11":
                    RunDay11(parser);
                    break;
                case "Day12":
                    RunDay12(parser);
                    break;
                case "Day13":
                    RunDay13(parser);
                    break;
                case "Day14":
                    RunDay14(parser);
                    break;
                case "Day15":
                    RunDay15(parser);
                    break;
                case "Day16":
                    RunDay16(parser);
                    break;
                case "Day17":
                    RunDay17(parser);
                    break;
                case "Day18":
                    RunDay18(parser);
                    break;
                case "Day19":
                    RunDay19(parser);
                    break;
                case "Day20":
                    RunDay20(parser);
                    break;
                case "Day21":
                    RunDay21(parser);
                    break;
                case "Day22":
                    RunDay22(parser);
                    break;
                case "Day23":
                    RunDay23(parser);
                    break;
                case "Day24":
                    RunDay24(parser);
                    break;
                case "Day25":
                    RunDay25(parser);
                    break;
                default:
                    break;
            }
        }

        public static void RunDay1(Parser parser)
        {
            ICollection<Elf> elves = parser.ReadMultilineContent<Elf>();
            if (elves == null || elves.Count == 0) { return; }
            Console.WriteLine("  Max calories: " + elves.ToList().Max()?.SumCalories());

            int iter = 3;
            int count = 0;

            while (iter > 0)
            {
                count += elves.Max()!.SumCalories();
                elves.Remove(elves.Max()!);
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

        public static void RunDay6(Parser parser)
        {
            Signal signal = parser.ReadContent<Signal>().First();
            Console.WriteLine("  Transmission start: " + signal.FindStartSignal);
            Console.WriteLine("  Message start: " + signal.FindStartMessage);
        }

        public static void RunDay7(Parser parser)
        {
            Dirs directory = parser.ReadMultilineContent<Dirs>().First();
            int size = directory.CountSizeOfSmallDirs(100000);

            Console.WriteLine("  Sum of sizes of directories with sizes less than a 100000: " + size);
            Console.WriteLine("  Size of the smallest directory to delete: " + directory.FindSmallestSizeToDelete(directory.size - 40000000));
        }

        public static void RunDay8(Parser parser)
        {
            TreeGrid treeGrid = parser.ReadMultilineContent<TreeGrid>().First();
            treeGrid.CheckVisibilty();

            Console.WriteLine("  Visible trees in grid: " + treeGrid.CountVisible());
            Console.WriteLine("  Visible trees from treehouse: " + treeGrid.BiggestScore());
        }

        public static void RunDay9(Parser parser)
        {
            SnakeGrid grid = new(parser.ReadContent<SnakeMove>().ToList());
            grid.ApplyMoves();

            Console.WriteLine("  Number of tail positions: " + grid.GetTailPositions(1).Distinct().Count());
            Console.WriteLine("  Number of long tail positions: " + grid.GetTailPositions(9).Distinct().Count());
        }

        public static void RunDay10(Parser parser)
        {
            Processor proc = new()
            {
                commands = parser.ReadContent<Command>().ToList()
            };
            proc.ExecuteCommands();


            Console.WriteLine("  Number of tail positions: " + proc.GetRegisterStrengthInKeyMoments(new() { 20, 60, 100, 140, 180, 220 }));
            List<string> pattern = proc.GetPattern();
            Console.WriteLine("  Pattern:");
            foreach (string pat in pattern)
            {
                Console.WriteLine("    " + pat);
            }
        }

        public static void RunDay11(Parser parser)
        {
            Monkey.Clear();
            List<Monkey> monkeys = parser.ReadMultilineContent<Monkey>().ToList();

            Monkey.PlayRounds(20);
            monkeys.Sort((x, y) => x.ItemsInspected - y.ItemsInspected);

            Console.WriteLine("  Level of monkey business (20 rounds): " + monkeys[^1].ItemsInspected * (long)monkeys[^2].ItemsInspected);

            parser = new($"Inputs\\Day11.txt");
            Monkey.Clear();
            monkeys = parser.ReadMultilineContent<Monkey>().ToList();

            Monkey.PlayRounds(10000, relief: false);
            monkeys.Sort((x, y) => x.ItemsInspected - y.ItemsInspected);

            Console.WriteLine("  Level of monkey business (10000 rounds) with no relief: " + (monkeys[^1].ItemsInspected * (long)monkeys[^2].ItemsInspected).ToString());
        }

        public static void RunDay12(Parser parser)
        {
            TopographicMap map = parser.ReadMultilineContent<TopographicMap>().First();

            List<((int, int), char)> path = map.AStar();

            Console.WriteLine("  Shortest path from 'S' to 'E': " + (path.Count - 1));
            Console.WriteLine("  Shortest path from any 'a' to 'E': " + (map.GetShortestPathFromA - 1));
        }

        public static void RunDay13(Parser parser)
        {
            List<DistressSignal> signals = parser.ReadMultilineContent<DistressSignal>().ToList();
            List<int> verify = signals.Select(x => x.Verify).ToList();

            int sum = 0;
            for (int i = 0; i < verify.Count; i++)
            {
                sum += (i + 1) * verify[i];
            }

            List<DistressSignal.SignalType> list = DistressSignal.ListOfAllSignals(signals);
            list.Sort(DistressSignal.Compare);

            Console.WriteLine("  Verification of right signal order: " + sum);
            Console.WriteLine("  Decoder key for the distress signal: " + 
                (list.FindIndex(x => x.List?.FirstOrDefault()?.List?.FirstOrDefault()?.Value == 2) + 1) *
                (list.FindIndex(x => x.List?.FirstOrDefault()?.List?.FirstOrDefault()?.Value == 6) + 1));
        }

        public static void RunDay14(Parser parser)
        {
            RockFormation formation = RockFormation.Combine(parser.ReadContent<RockFormation>());

            formation.FillWithSand();

            Console.WriteLine("  Sand in bottomless formation: " + formation.SandPlace.Count);

            formation.SandPlace.Clear();
            formation.AddFloor();
            formation.FillWithSand();

            Console.WriteLine("  Sand in formation with the floor: " + formation.SandPlace.Count);
        }

        public static void RunDay15(Parser parser)
        {
            ICollection<Sensor> list = parser.ReadContent<Sensor>();

            (int, int) v = Sensor.GetPointNotCovered(list, 4000000);

            Console.WriteLine("  Positions not containing beacons in row 2000000: " + Sensor.GetAllLineCoverage(list, 2000000));
            Console.WriteLine("  Tunning frequency of distress beacon: " + v.Item1 * (long)4000000 + v.Item2);
        }

        public static void RunDay16(Parser parser)
        {
            ValveMap walker = new ValveMap(parser.ReadContent<Valve>().ToList());

            Console.WriteLine("  Pressure released in 30 minutes: " + walker.Calculate(walker.CurrentValves));
            Console.WriteLine("  Pressure released with elephant: " + walker.Calculate(walker.CurrentValves, true, 26));
        }

        public static void RunDay17(Parser parser)
        {
            using Parser parser2 = new("Inputs\\Day17.txt");
            Chamber chamber = parser.ReadContent<Chamber>().First();
            Chamber chamber2 = parser2.ReadContent<Chamber>().First();

            chamber2.RunSimulation(1000000000000);
            chamber.RunSimulation(2022);


            Console.WriteLine("  Height of rock tower after 2022 pieces: " + chamber.Height);
            Console.WriteLine("  Height of rock tower after 10e12 pieces: " + chamber2.Height);
        }

        public static void RunDay18(Parser parser)
        {
            Cube cube = parser.ReadMultilineContent<Cube>().First();

            Console.WriteLine("  Open sides of magma piece: " + cube.Sides);
            Console.WriteLine("  Open sides without internal droplets: " + (cube.Sides - cube.Droplets()));
        }

        public static void RunDay19(Parser parser)
        {
            BlueprintSimulator simulator = new()
            {
               list = parser.ReadContent<Blueprint>().ToList()
            };

            Console.WriteLine("  Quality of blueprints: " + simulator.Run());
            Console.WriteLine("  Largest number of geodes: " + simulator.RunLonger());
        }

        public static void RunDay20(Parser parser)
        {
            Sequence sequence = parser.ReadMultilineContent<Sequence>().First();

            Console.WriteLine("  Grove coordinates: " + sequence.Run());
            Console.WriteLine("  True grove coordinates: " + sequence.RunLonger());
        }

        public static void RunDay21(Parser parser)
        {
            parser.ReadContent<MonkeyOperation>();

            Console.WriteLine("  Result of monkey riddle: " + MonkeyOperation.Monkeys["root"].Value);

            MonkeyOperation.Monkeys.Clear();

            using Parser parser2 = new("Inputs\\Day21.txt");
            MonkeyOperation.Part2 = true;
            parser2.ReadContent<MonkeyOperation>();

            Console.WriteLine("  Human input in monkey riddle: " + MonkeyOperation.Monkeys["root"].GetValue());

            MonkeyOperation.Part2 = false;
            MonkeyOperation.Monkeys.Clear();
        }

        public static void RunDay22(Parser parser)
        {
            using Parser parser2 = new("Inputs\\Day22_2.txt");
            using Parser parser3 = new("Inputs\\Day22.txt");
            ForceFieldPath path = parser2.ReadContent<ForceFieldPath>().First();

            path.map = parser.ReadMultilineContent<ForceFieldPlainMap>().First();
            Console.WriteLine("  Force field password on plain map: " + path.Walk());

            ForceFieldCubeMap.SetUseCase(test: false);
            path.map = parser3.ReadMultilineContent<ForceFieldCubeMap>().First();
            Console.WriteLine("  Force field password on cubic map: " + path.Walk());
        }

        public static void RunDay23(Parser parser)
        {
            FieldOfElves field = parser.ReadMultilineContent<FieldOfElves>().First();

            field.Run();

            Console.WriteLine("  Get number of empty places in rectangular: " + field.GetArea);

            using Parser parser2 = new("Inputs\\Day23.txt");
            FieldOfElves field2 = parser2.ReadMultilineContent<FieldOfElves>().First();

            Console.WriteLine("  Get number of rounds elves need: " + field2.Run(int.MaxValue));
        }

        public static void RunDay24(Parser parser)
        {
            Valley valley = parser.ReadMultilineContent<Valley>().First();

            Console.WriteLine("  Shortest time to get across the valley: " + valley.Run());
            Console.WriteLine("  Shortest time to get across then come back and go across again: " + valley.Run(valley.Run(valley.Run(), true)));
        }

        public static void RunDay25(Parser parser)
        {
            ICollection<SNAFU> list = parser.ReadContent<SNAFU>();

            Console.WriteLine("  SNAFU number to input into console: " + new SNAFU() { Int = list.Sum(x => x.Int) }.Snafu);
        }
    }
}
