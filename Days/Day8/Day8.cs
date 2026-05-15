using AdventOfCode24.Structures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
namespace AdventOfCode24.Days.Day8
{
    internal class Day8
    {
        public void Run()
        {
            var cityMap = PrepareInput(InputEnum.FULL);
            cityMap.printMap();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            //SolvePart1(cityMap);
            SolvePart2(cityMap);

            sw.Stop();
            Console.WriteLine($"\n\nTime taken: {sw.Elapsed.TotalSeconds} seconds");
        }

        public Map<ExtendedPoint> PrepareInput(InputEnum input)
        {
            string path = "";
            switch (input)
            {
                case InputEnum.EXAMPLE:
                    path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Days", "Day8", "ExampleInput.txt");
                    break;
                case InputEnum.FULL:
                    path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Days", "Day8", "PuzzleInput.txt");
                    break;
            }

            var data = File.ReadAllText(path).Split(new[] { "\r\n" }, StringSplitOptions.None);
            return new Map<ExtendedPoint>(data, (x, y, c) => new ExtendedPoint(x, y, c));
        }

        public void SolvePart1(Map<ExtendedPoint> cityMap)
        {
            // sort the antennas by frequency
            var frequencyTable = new Hashtable();
            var antennas = cityMap.Points.FindAll(p => p.display != ".").ToList();

            foreach (var antenna in antennas)
            {
                if (frequencyTable.ContainsKey(antenna.display))
                {
                    ((List<ExtendedPoint>)frequencyTable[antenna.display]).Add(antenna);
                }
                else
                {
                    frequencyTable[antenna.display] = new List<ExtendedPoint>() { antenna };
                }
            }

            // generate the offsets between each antenna within a frequency
            var antiNodes = new List<ExtendedPoint>();
            foreach (var frequency in frequencyTable.Keys)
            {
                var currentFrequencyAntennas = ((List<ExtendedPoint>)frequencyTable[frequency]);
                for (int i = 0; i < currentFrequencyAntennas.Count - 1; i++)
                {
                    for (int j = i + 1; j < currentFrequencyAntennas.Count; j++)
                    {
                        var antenna_a = currentFrequencyAntennas[i];
                        var antenna_b = currentFrequencyAntennas[j];

                        var offset_x = (antenna_b.x - antenna_a.x);
                        var offet_y = (antenna_b.y - antenna_a.y);

                        antiNodes.Add(new ExtendedPoint(antenna_a.x - offset_x, antenna_a.y - offet_y, "#"));
                        antiNodes.Add(new ExtendedPoint(antenna_b.x + offset_x, antenna_b.y + offet_y, "#"));

                    }
                }
            }

            // filter out duplicates and out-of-bounds anti nodes
            var validAntiNodes = new List<ExtendedPoint>();
            foreach (var node in antiNodes)
            {
                if (!ContainsExtendedPoint(validAntiNodes, node) && cityMap.isPointInBounds(node))
                {
                    validAntiNodes.Add(node);
                }
            }


            //CheckExampleSolution(validAntiNodes);

            // update the position in the map to visualize it
            foreach (var node in validAntiNodes)
            {
                cityMap.getPointAt(node.x, node.y).setIsAntiNode();
                //Console.WriteLine($"Antinode at {node.ToString()}");
            }
            Console.WriteLine("\n--------------------------------------------------\n");
            cityMap.printMap();
            Console.WriteLine($"Found {validAntiNodes.Count} antinodes");
        }

        public void SolvePart2(Map<ExtendedPoint> cityMap)
        {
            // sort the antennas by frequency
            var frequencyTable = new Hashtable();
            var antennas = cityMap.Points.FindAll(p => p.display != ".").ToList();

            foreach (var antenna in antennas)
            {
                if (frequencyTable.ContainsKey(antenna.display))
                {
                    ((List<ExtendedPoint>)frequencyTable[antenna.display]).Add(antenna);
                }
                else
                {
                    frequencyTable[antenna.display] = new List<ExtendedPoint>() { antenna };
                }
            }

            // generate the offsets between each antenna within a frequency
            var antiNodes = new List<ExtendedPoint>();
            foreach (var frequency in frequencyTable.Keys)
            {
                var currentFrequencyAntennas = ((List<ExtendedPoint>)frequencyTable[frequency]);
                for (int i = 0; i < currentFrequencyAntennas.Count - 1; i++)
                {
                    for (int j = i + 1; j < currentFrequencyAntennas.Count; j++)
                    {
                        var antenna_a = currentFrequencyAntennas[i];
                        var antenna_b = currentFrequencyAntennas[j];

                        var offset_x = (antenna_b.x - antenna_a.x);
                        var offet_y = (antenna_b.y - antenna_a.y);



                        antiNodes.Add(new ExtendedPoint(antenna_a.x, antenna_a.y, $"{antenna_a.frequency}#"));
                        antiNodes.Add(new ExtendedPoint(antenna_b.x, antenna_b.y, $"{antenna_b.frequency}#"));

                        var nextPointPostitiveDirection = new ExtendedPoint(antenna_b.x + offset_x, antenna_b.y + offet_y, "#");

                        while (cityMap.isPointInBounds(nextPointPostitiveDirection))
                        {
                            antiNodes.Add(nextPointPostitiveDirection);
                            nextPointPostitiveDirection = new ExtendedPoint(nextPointPostitiveDirection.x + offset_x, nextPointPostitiveDirection.y + offet_y, "#");
                        }


                        var nextPointNegativeDirection = new ExtendedPoint(antenna_a.x - offset_x, antenna_a.y - offet_y, "#");
                        while (cityMap.isPointInBounds(nextPointNegativeDirection))
                        {
                            antiNodes.Add(nextPointNegativeDirection);
                            nextPointNegativeDirection = new ExtendedPoint(nextPointNegativeDirection.x - offset_x, nextPointNegativeDirection.y - offet_y, "#");
                        }
                    }
                }
            }

            // filter out duplicates and out-of-bounds anti nodes
            var validAntiNodes = new List<ExtendedPoint>();
            foreach (var node in antiNodes)
            {
                if (!ContainsExtendedPoint(validAntiNodes, node) && cityMap.isPointInBounds(node))
                {
                    validAntiNodes.Add(node);
                }
            }


            CheckExampleSolution(validAntiNodes, 2);

            // update the position in the map to visualize it
            foreach (var node in validAntiNodes)
            {
                cityMap.getPointAt(node.x, node.y).setIsAntiNode();
                //Console.WriteLine($"Antinode at {node.ToString()}");
            }
            Console.WriteLine("\n--------------------------------------------------\n");
            cityMap.printMap();
            Console.WriteLine($"Found {validAntiNodes.Count} antinodes");
        }

        public bool CheckExampleSolution(List<ExtendedPoint> antiNodes, int step)
        {
            var DEBUG_KNOWN_EXAMPLE_ANTINODES = new List<ExtendedPoint>();
            if (step == 1)
            {
                DEBUG_KNOWN_EXAMPLE_ANTINODES = new List<ExtendedPoint>() {
                new ExtendedPoint(6,0,"#"),
                new ExtendedPoint(11,0,"#"),

                new ExtendedPoint(3,1,"#"),

                new ExtendedPoint(4,2,"#"),
                new ExtendedPoint(10,2,"#"),

                new ExtendedPoint(2,3,"#"),

                new ExtendedPoint(9,4,"#"),

                new ExtendedPoint(1,5,"#"),
                new ExtendedPoint(6,5,"A#"),

                new ExtendedPoint(3,6,"#"),

                new ExtendedPoint(0,7,"#"),
                new ExtendedPoint(7,7,"#"),

                new ExtendedPoint(10,10,"#"),
                new ExtendedPoint(10,11,"#"),
            };
            }
            else if (step == 2)
            {
                // TODO should be 34 nodes (some antennas are maybe also 
                DEBUG_KNOWN_EXAMPLE_ANTINODES = new List<ExtendedPoint>() {
                new ExtendedPoint(0,0,"#"),
                new ExtendedPoint(1,0,"#"),
                new ExtendedPoint(6,0,"#"),
                new ExtendedPoint(11,0,"#"),

                new ExtendedPoint(1,1,"#"),
                new ExtendedPoint(3,1,"#"),

                new ExtendedPoint(2,2,"#"),
                new ExtendedPoint(4,2,"#"),
                new ExtendedPoint(10,2,"#"),

                new ExtendedPoint(2,3,"#"),
                new ExtendedPoint(3,3,"#"),

                new ExtendedPoint(9,4,"#"),

                new ExtendedPoint(1,5,"#"),
                new ExtendedPoint(5,5,"#"),
                new ExtendedPoint(6,5,"A#"),
                new ExtendedPoint(11,5,"#"),

                new ExtendedPoint(3,6,"#"),
                new ExtendedPoint(6,6,"#"),

                new ExtendedPoint(0,7,"#"),
                new ExtendedPoint(5,7,"#"),
                new ExtendedPoint(7,7,"#"),

                new ExtendedPoint(2,8,"#"),

                new ExtendedPoint(4,9,"#"),

                new ExtendedPoint(1,10,"#"),
                new ExtendedPoint(10,10,"#"),

                new ExtendedPoint(3,11,"#"),
                new ExtendedPoint(10,11,"#"),
                new ExtendedPoint(11,11,"#"),

                // the antennas that are not already added above
                new ExtendedPoint(8,1,"0#"),
                new ExtendedPoint(5,2,"0#"),
                new ExtendedPoint(7,3,"0#"),
                new ExtendedPoint(4,4,"0#"),
                new ExtendedPoint(8,8,"A#"),
                new ExtendedPoint(9,9,"A#"),

                };
            }

            var validPoints = antiNodes.Where(node => ContainsExtendedPoint(DEBUG_KNOWN_EXAMPLE_ANTINODES, node)).ToList();
            var invalidPoints = antiNodes.Except(validPoints).ToList();
            var missingPoints = DEBUG_KNOWN_EXAMPLE_ANTINODES.Where(node => !ContainsExtendedPoint(validPoints, node)).ToList();

            Console.WriteLine("\n\n+++++++++++++++++++++++++++++++++++++++++++++++++\n");

            Console.WriteLine($"found {antiNodes.Count} antinodes of {DEBUG_KNOWN_EXAMPLE_ANTINODES.Count} valid antinodes\n");

            Console.WriteLine($"Valid Points ({validPoints.Count} / {DEBUG_KNOWN_EXAMPLE_ANTINODES.Count}):");
            foreach (var item in validPoints)
            {
                Console.WriteLine($"\t- {item.ToString()}");
            }



            Console.WriteLine($"\nInvalid Points ({invalidPoints.Count}):");
            foreach (var item in invalidPoints)
            {
                Console.WriteLine($"\t- {item.ToString()}");
            }

            Console.WriteLine($"\nMissing Points ({missingPoints.Count}):");
            foreach (var item in missingPoints)
            {
                Console.WriteLine($"\t- {item.ToString()}");
            }

            return validPoints.Count == antiNodes.Count;
        }

        public bool ContainsExtendedPoint(List<ExtendedPoint> list, ExtendedPoint point)
        {
            foreach (var item in list)
            {
                if (item.IsEqualPosition(point)) return true;
            }
            return false;
        }

    }

    [DebuggerDisplay("{display}: ({x},{y})")]
    internal class ExtendedPoint : Point
    {
        public ExtendedPoint(int x, int y, string display) : base(x, y, display)
        {
            if (display != ".")
            {
                frequency = display[0];
            }
        }

        public char? frequency { get; set; }

        public bool isAntiNode { get; private set; } = false;

        public void setIsAntiNode()
        {
            isAntiNode = true;

            if (frequency != null)
            {
                display = frequency.ToString() + "#";
            }
            else
            {
                display = "#";
            }
        }

        override
        public string ToString()
        {
            return $"{display}: ({x:D2},{y:D2})";
        }


        public bool IsEqual(ExtendedPoint p)
        {
            return (x == p.x && y == p.y && frequency == p.frequency);
        }

        public bool IsEqualPosition(ExtendedPoint p)
        {
            return (x == p.x && y == p.y);
        }
    }

}
