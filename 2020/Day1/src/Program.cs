using System;
using System.Collections.Generic;
using System.Linq;
using Util;

namespace Day1
{
    class Program
    {
        /// <summary>
        /// Day 1 --  Find the two entries that sum to 2020; what do you get if you multiply them together?
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<int> input = FileUtilities.ReadIntsFromFile("input.txt")
                .ToList();
            
            var result = Solution.FindPairWithSum(input, 2020);
            Console.WriteLine(result.Item1 * result.Item2); //996996
        }
    }
}