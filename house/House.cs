using System.Linq;
using System.Text;

public static class House
{
    private static readonly (string subject, string action)[] parts = new[]
    {
        ("house", "Jack built"),
        ("malt", "lay in"),
        ("rat", "ate"),
        ("cat", "killed"),
        ("dog", "worried"),
        ("cow with the crumpled horn", "tossed"),
        ("maiden all forlorn", "milked"),
        ("man all tattered and torn", "kissed"),
        ("priest all shaven and shorn", "married"),
        ("rooster that crowed in the morn", "woke"),
        ("farmer sowing his corn", "kept"),
        ("horse and the hound and the horn", "belonged to")
    };

    public static string Recite(int verseNumber)
    {
        var verse = new StringBuilder("This is the ");
        
        for (int i = verseNumber - 1; i >= 0; i--)
        {
            verse.Append(parts[i].subject);
            
            if (i > 0)
            {
                verse.Append(" that ");
                verse.Append(parts[i].action);
                verse.Append(" the ");
            }
            else
            {
                verse.Append(" that ");
                verse.Append(parts[i].action);
            }
        }
        
        verse.Append('.');
        return verse.ToString();
    }

    public static string Recite(int startVerse, int endVerse) => string.Join("\n",
            Enumerable.Range(startVerse, endVerse - startVerse + 1)
                     .Select(verse => Recite(verse)));
}