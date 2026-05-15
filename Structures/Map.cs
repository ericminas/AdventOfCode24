using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode24.Structures
{
    internal class Point
    {
        public int x { get; set; }

        public int y { get; set; }

        public string display { get; set; }

        public Point(int x, int y, string display)
        {
            this.x = x;
            this.y = y;
            this.display = display;
        }

        override
       public string ToString()
        {
            return $"{display}: ({x},{y})";
        }
    }

    internal class Map<TPoint> where TPoint : Point
    {
        public List<TPoint> Points { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        // Factory function used to create the appropriate point type
        public Map(string[] rows, Func<int, int, string, TPoint> pointFactory)
        {
            Points = new List<TPoint>();

            for (int y = 0; y < rows.Length; y++)
            {
                char[] split = rows[y].ToCharArray();

                for (int x = 0; x < split.Length; x++)
                {
                    Points.Add(pointFactory(x, y, split[x].ToString()));
                }
            }

            width = rows[0].Length;
            height = rows.Length;
        }

        public void updatePoint(int x, int y, string newDisplay)
        {
            Points.Find(p => p.x == x && p.y == y).display = newDisplay;
        }

        public TPoint getPointAt(int x, int y)
        {
            return Points.Find(p => p.x == x && p.y == y);
        }

        public bool isPointInBounds(TPoint point)
        {
            return point.x >= 0 && point.x < width && point.y >= 0 && point.y < height;
        }

        public void printMap()
        {
            // Determine the widest display string (minimum width of 2 for alignment)
            int cellWidth = Math.Max(
                2,
                Points.Max(p => p.display?.Length ?? 0)
            );

            // Print header row
            Console.Write("x> ");
            for (int x = 0; x < width; x++)
            {
                Console.Write($"{x:D2}".PadRight(cellWidth + 1));
            }
            Console.WriteLine();

            // Print each row
            for (int y = 0; y < height; y++)
            {
                // Row label
                Console.Write($"{y:D2} ");

                for (int x = 0; x < width; x++)
                {
                    TPoint point = Points.First(p => p.x == x && p.y == y);

                    // Left-align each display value within the cell width
                    Console.Write((point.display ?? "").PadRight(cellWidth + 1));
                }

                Console.WriteLine();
            }
        }
    }
}
