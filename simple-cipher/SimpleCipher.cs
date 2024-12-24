using System;
using System.Linq;
using System.Text;

public class SimpleCipher
{
    private static readonly Random random = new Random();
    
    public string Key { get; set; } = new string(Enumerable.Range(0, 100)
        .Select(_ => (char)('a' + random.Next(26)))
        .ToArray());

    public SimpleCipher() { }

    public SimpleCipher(string key) => Key = key;

    public string Encode(string plaintext)
    {
        var result = new StringBuilder();
        for (int i = 0; i < plaintext.Length; i++)
        {
            int shift = Key[i % Key.Length] - 'a';
            char c = (char)('a' + (plaintext[i] - 'a' + shift) % 26);
            result.Append(c);
        }
        return result.ToString();
    }

    public string Decode(string ciphertext)
    {
        var result = new StringBuilder();
        for (int i = 0; i < ciphertext.Length; i++)
        {
            int shift = Key[i % Key.Length] - 'a';
            char c = (char)('a' + (ciphertext[i] - 'a' - shift + 26) % 26);
            result.Append(c);
        }
        return result.ToString();
    }
}