using System;
using System.Collections.Generic;

public static class Strain
{
    public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));
        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate));
            
        return KeepIterator(collection, predicate);
    }

    private static IEnumerable<T> KeepIterator<T>(IEnumerable<T> collection, Func<T, bool> predicate)
    {
        foreach (var item in collection)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }

    public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));
        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate));
            
        return DiscardIterator(collection, predicate);
    }

    private static IEnumerable<T> DiscardIterator<T>(IEnumerable<T> collection, Func<T, bool> predicate)
    {
        foreach (var item in collection)
        {
            if (!predicate(item))
            {
                yield return item;
            }
        }
    }
}