﻿Console.WriteLine(new List<string>(){File.ReadAllLines("input.txt").Aggregate("", (acc, it) => acc + it)}.Select(static line => System.Text.RegularExpressions.Regex.Matches(line, @"mul\([0-9]+,[0-9]+\)|do\(\)|don't\(\)").Aggregate((0, true), (acc, match) => match.Value[0] == 'm' ? (acc.Item2 ? match.Value.Split("(")[1].Split(")")[0].Split(",").Aggregate(1, (a, b) => a * int.Parse(b)) + acc.Item1 : acc.Item1, acc.Item2) : (match.Value[2] == '(' ? (acc.Item1, true) : (acc.Item1, false))).Item1).Sum());