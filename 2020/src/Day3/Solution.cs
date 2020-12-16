using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions.Day3
{
    public static class Solution
    {
        /// <summary>
        /// Given the map input, and the gradient/slope variables, count the number
        /// of trees encountered before reaching the bottom/last line of the map
        /// </summary>
        /// <param name="mapInput"> map input, each value is a line of the map. repeated horizontally</param>
        /// <param name="right"> the horizontal component of the movement gradient</param>
        /// <param name="down"> the vertical component of the movement gradient</param>
        /// <returns> number of trees encountered before reaching the bottom.</returns>
        public static int CountTreesOnPath(IEnumerable<string> mapInput, int right, int down)
        {
            InfinitelyHorizontalMap map = new InfinitelyHorizontalMap(mapInput.ToArray());
            int trees = 0;

            while (!map.IsComplete)
            {
               (int x, int y) newLocation = map.Move(right, down);
               
                if (map.IsTree(newLocation.x, newLocation.y))
                {
                    trees++;
                }
            }

            return trees;
        }
    }

    public class InfinitelyHorizontalMap
    {
        private readonly string[] _lines;

        public (int x, int y) CurrentLocation { get; private set; }

        public bool IsTree(int x, int y)
        {
            if (x >= _lines[y].Length)
            {
                x %= _lines[y].Length;
            }

            return _lines[y][x] == '#';
        }

        public bool IsComplete { get; set; }

        public InfinitelyHorizontalMap(string[] lines)
        {
            _lines = lines;
            CurrentLocation = (0, 0);
        }

        public (int x, int y) Move(int right, int down)
        {
            if (CurrentLocation.y + down > _lines.Length)
            {
                throw new InvalidOperationException("Down movement would be outside the known map.");
            }

            CurrentLocation = (CurrentLocation.x + right, CurrentLocation.y + down);

            if (CurrentLocation.y == _lines.Length - 1)
            {
                IsComplete = true;
            }

            return (CurrentLocation.x, CurrentLocation.y);
        }
    }
}