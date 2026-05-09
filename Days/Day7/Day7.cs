using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode24.Days.Day7
{
    internal class Day7
    {
        public void Run()
        {
            //string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Days", "Day7", "ExampleInput.txt");
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Days", "Day7", "PuzzleInput.txt");
            //string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Days", "Day7", "ManualTesting.txt");

            var inputData = PrepareInput(path);


            Stopwatch sw = new Stopwatch();
            sw.Start();

            SolvePart1(inputData);
            SolvePart2(inputData);

            sw.Stop();
            Console.WriteLine($"Time taken: {sw.Elapsed.TotalSeconds} seconds");
        }

        public string[] PrepareInput(string inputPath)
        {
            string text = File.ReadAllText(inputPath);
            return text.Split(new[] { "\r\n" }, StringSplitOptions.None);

        }

        public void SolvePart1(string[] inputData)
        {
            var lines = inputData.Select(rawLine => new Line(rawLine)).ToList();
            long validTestSum = 0;

            var maxLineNumberLenght = lines.Select(l => l.numbers.Count).Max();
            var options = GenerateAllOperatorOptions(maxLineNumberLenght);

            foreach (var line in lines)
            {
                List<List<char>> lineOptions = (List<List<char>>)options[line.numbers.Count - 1];

                if (ValidateLine(line, lineOptions))
                {
                    Console.WriteLine($"{line.ToString()}");
                    validTestSum += line.test;
                }
            }

            Console.WriteLine($"[Day 7 - Part 1]: Valid test sum: {validTestSum}");

        }
        public void SolvePart2(string[] inputData) { }

        public long Calculate(Line line, char[] operators)
        {
            long currentValue = line.numbers.First();

            for (var operatorIndex = 0; operatorIndex < operators.Length; operatorIndex++)
            {
                switch (operators[operatorIndex])
                {
                    case '+':
                        currentValue = currentValue + line.numbers[operatorIndex + 1];
                        continue;
                    case '*':
                        currentValue = currentValue * line.numbers[operatorIndex + 1];
                        continue;
                    case '|':
                        var a = currentValue.ToString();
                        var b = (line.numbers[operatorIndex + 1]).ToString();
                        var c = currentValue.ToString() + (line.numbers[operatorIndex + 1]).ToString();
                        currentValue = long.Parse(currentValue.ToString() + (line.numbers[operatorIndex + 1]).ToString());
                        continue;
                }

            }

            return currentValue;
        }

        public bool ValidateLine(Line line, List<List<char>> options)
        {
            foreach (var option in options)
            {
                var optionResult = Calculate(line, option.ToArray());
                if (line.test == optionResult)
                {
                    Console.WriteLine($"\t >> [{string.Join(",", option.ToArray())}]");
                    return true;
                }
            }

            return false;
        }

        public Hashtable GenerateAllOperatorOptions(int maxOptionListLength)
        {
            var generatedLevels = new Hashtable();

            var level = 1;
            generatedLevels.Add(level++, new List<List<char>>
            {
                new List<char> { '+' },
                new List<char> { '*' },
                 new List<char> { '|' }
            });

            while (generatedLevels.Count < maxOptionListLength)
            {
                List<List<char>> prevList = (List<List<char>>)generatedLevels[level - 1];
                var expansionPlus = prevList.Select(o => new List<char>(o) { '+' }).ToList();
                var expansionMult = prevList.Select(o => new List<char>(o) { '*' }).ToList();
                var expansionConc = prevList.Select(o => new List<char>(o) { '|' }).ToList();

                generatedLevels.Add(level++, expansionMult.Union(expansionPlus).Union(expansionConc).ToList());
            }

            return generatedLevels;

        }

    }

    internal class Line
    {
        public long test { get; }

        public List<int> numbers { get; }

        public Line(string rawLine)
        {
            string[] s;
            try
            {
                s = rawLine.Split(':');
                test = long.Parse(s[0]);
                numbers = s[1].Trim().Split(' ').Select(x => int.Parse(x)).ToList();
            }
            catch (Exception ex)
            {
                var t = 0;
            }
        }

        public string ToString()
        {
            return ($"{test}: [{string.Join(",", numbers.ToArray())}]");
        }


    }
}
