using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions.Day3
{
    public static class Solution
    {
        public static int CountTreesOnPath(IEnumerable<string> mapInput)
        {
            InfinitelyHorizontalMap map = new InfinitelyHorizontalMap(mapInput.ToArray());
            int trees = 0;

            while (!map.IsComplete)
            {
                map.Move(3, 1);
               
                if (map.IsTree(map.CurrentLocation.x, map.CurrentLocation.y))
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
            if (x > _lines[y].Length)
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

        public void Move(int right, int down)
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
        }
    }
}