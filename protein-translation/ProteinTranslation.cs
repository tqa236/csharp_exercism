using System.Collections.Generic;

public static class ProteinTranslation
{
    public static string[] Proteins(string strand)
    {
        var codonToProtein = new Dictionary<string, string>
        {
            { "AUG", "Methionine" },
            { "UUU", "Phenylalanine" },
            { "UUC", "Phenylalanine" },
            { "UUA", "Leucine" },
            { "UUG", "Leucine" },
            { "UCU", "Serine" },
            { "UCC", "Serine" },
            { "UCA", "Serine" },
            { "UCG", "Serine" },
            { "UAU", "Tyrosine" },
            { "UAC", "Tyrosine" },
            { "UGU", "Cysteine" },
            { "UGC", "Cysteine" },
            { "UGG", "Tryptophan" },
            { "UAA", "STOP" },
            { "UAG", "STOP" },
            { "UGA", "STOP" }
        };

        var proteins = new List<string>();
        for (int i = 0; i < strand.Length; i += 3)
        {
            string codon = strand.Substring(i, 3);

            if (codonToProtein[codon] == "STOP")
            {
                break;
            }

            proteins.Add(codonToProtein[codon]);
        }

        return proteins.ToArray();
    }
}
