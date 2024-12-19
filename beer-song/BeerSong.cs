using System.Text;

public static class BeerSong
{
    public static string Recite(int startBottles, int takeDown)
    {
        var result = new StringBuilder();
        int currentBottles = startBottles;

        for (int i = 0; i < takeDown; i++)
        {
            if (currentBottles == 0)
            {
                result.AppendLine("No more bottles of beer on the wall, no more bottles of beer.");
                result.AppendLine("Go to the store and buy some more, 99 bottles of beer on the wall.");
            }
            else if (currentBottles == 1)
            {
                result.AppendLine($"1 bottle of beer on the wall, 1 bottle of beer.");
                result.AppendLine($"Take it down and pass it around, no more bottles of beer on the wall.");
            }
            else if (currentBottles == 2)
            {
                result.AppendLine($"2 bottles of beer on the wall, 2 bottles of beer.");
                result.AppendLine($"Take one down and pass it around, 1 bottle of beer on the wall.");
            }
            else
            {
                result.AppendLine($"{currentBottles} bottles of beer on the wall, {currentBottles} bottles of beer.");
                result.AppendLine($"Take one down and pass it around, {currentBottles - 1} bottles of beer on the wall.");
            }

            if (i < takeDown - 1) 
            {
                result.AppendLine();
            }

            currentBottles--;
        }

        return result.ToString().TrimEnd();
    }
}
