using System;
using System.Collections.Generic;

public static class AccumulateExtensions
{
    public static IEnumerable<U> Accumulate<T, U>(this IEnumerable<T> collection, Func<T, U> func)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));
        if (func == null) throw new ArgumentNullException(nameof(func));

        foreach (var item in collection)
        {
            yield return func(item);
        }
    }
}
