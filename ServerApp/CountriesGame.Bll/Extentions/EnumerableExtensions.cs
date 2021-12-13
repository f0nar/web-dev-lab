using System;
using System.Collections.Generic;
using System.Linq;

namespace CountriesGame.Bll.Extentions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var random = new Random();
            var buffer = source.ToList();
            for (int i = 0; i < buffer.Count; i++)
            {
                int j = random.Next(i, buffer.Count);
                yield return buffer[j];

                buffer[j] = buffer[i];
            }
        }
    }
}