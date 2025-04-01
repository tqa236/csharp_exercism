public static class Change
{
    public static int[] FindFewestCoins(int[] coins, int target)
    {
        if (target < 0)
        {
            throw new ArgumentException("Target cannot be negative.");
        }

        int[] minCoins = new int[target + 1];
        int[] lastCoin = new int[target + 1];

        for (int i = 1; i <= target; i++)
        {
            minCoins[i] = int.MaxValue - 1;
            foreach (int coin in coins)
            {
                if (i - coin >= 0 && minCoins[i - coin] + 1 < minCoins[i])
                {
                    minCoins[i] = minCoins[i - coin] + 1;
                    lastCoin[i] = coin;
                }
            }
        }

        if (minCoins[target] == int.MaxValue - 1)
        {
            throw new ArgumentException("No combination of coins can make up the target value.");
        }

        List<int> coinsUsed = new List<int>();
        while (target > 0)
        {
            coinsUsed.Add(lastCoin[target]);
            target -= lastCoin[target];
        }

        return coinsUsed.ToArray();
    }
}
