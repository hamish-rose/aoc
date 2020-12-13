using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Util
{
    public static class FileUtilities
    {
        /// <summary>
        /// Read lines from a file parsing each line as an int. Blows up if a line isn't an int so don't do that.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IEnumerable<int> ReadIntsFromFile(string path)
        {
            return File.ReadLines(path)
                .Select(int.Parse);
        }
    }
}