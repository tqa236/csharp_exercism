using System.Threading.Tasks;

public static class RnaTranscription
{
    public static string ToRna(string strand)
    {
        char[] rna = strand.ToCharArray();
        
        Parallel.ForEach(rna, (nucleotide, state, index) =>
        {
            rna[index] = nucleotide switch
            {
                'G' => 'C',
                'C' => 'G',
                'T' => 'A',
                'A' => 'U',
                _ => nucleotide
            };
        });

        return new string(rna);
    }
}
