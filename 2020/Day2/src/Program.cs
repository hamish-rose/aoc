using System;
using System.Collections.Generic;
using System.Linq;
using Util;

namespace Day2
{
    class Program
    {
        /// <summary>
        /// Day 2 --  Count the passwords that match their rule. 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            IEnumerable<string> input = FileUtilities.ReadLinesFromFile("input.txt");

            int count = 0;
            
            foreach (string line in input)
            {
                List<string> inputs = line.Split(':')
                    .Select(x => x.Trim())
                    .ToList();

                if (Solution.IsValidPassword(inputs[0], inputs[1]))
                {
                    count++;
                }
            }
            
            Console.WriteLine(count);
        }
    }
}
