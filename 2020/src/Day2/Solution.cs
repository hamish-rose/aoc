using System.Collections.Generic;
using System.Linq;

namespace Solutions.Day2
{
    public static class Solution
    {
        /// <summary>
        /// Determines whether the password parameter matches the password rule. rule is in the format:
        /// 1-3 a, this means that the password must contain a at least 1 time and at most 3 times.
        /// </summary>
        /// <param name="passwordRule"></param>
        /// <param name="password"></param>
        /// <returns> whether the pw is valid.</returns>
        public static bool IsValidPassword(string passwordRule, string password)
        {
            int delimiter = passwordRule.IndexOf(' ');
            string occurrences = passwordRule.Substring(0, delimiter);
            char requiredChar = passwordRule.Substring(delimiter + 1)[0];

            List<int> constraints = occurrences.Split('-')
                .Select(int.Parse)
                .ToList();

            (int min, int max) = (constraints[0], constraints[1]);

            int count = password
                            .GroupBy(x => x)
                            .SingleOrDefault(x => x.Key == requiredChar)
                            ?.Count()
                        ?? 0;

            return count >= min && count <= max;
        }
    }
}