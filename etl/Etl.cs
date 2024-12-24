using System.Collections.Generic;
using System.Linq;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old) => old
            .SelectMany(kv => kv.Value.Select(letter => new KeyValuePair<string, int>(letter.ToLower(), kv.Key)))
            .ToDictionary(pair => pair.Key, pair => pair.Value);
}
