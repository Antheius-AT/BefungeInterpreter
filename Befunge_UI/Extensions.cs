using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Befunge_UI
{
    public static class Extensions
    {
        public static List<int> AllIndexesOf(this string source, char value)
        {
            if (string.IsNullOrWhiteSpace(source))
                throw new ArgumentNullException(nameof(source), "Source string must not be null.");

            var indexes = new List<int>();
            int current = 0;

            do
            {
                current = source.IndexOf(value, current);

                if (current >= 0)
                {
                    indexes.Add(current);
                    current++;
                }

            } while (current >= 0);

            return indexes;
        }
    }
}
