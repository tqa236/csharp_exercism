public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 2)
        {
            return new int[0];
        }

        bool[] isPrime = new bool[limit + 1];
        for (int i = 2; i <= limit; i++)
        {
            isPrime[i] = true;
        }

        for (int p = 2; p * p <= limit; p++)
        {
            if (isPrime[p])
            {
                for (int multiple = p * p; multiple <= limit; multiple += p)
                {
                    isPrime[multiple] = false;
                }
            }
        }
        var primes = new List<int>();
        for (int i = 2; i <= limit; i++)
        {
            if (isPrime[i])
            {
                primes.Add(i);
            }
        }

        return primes.ToArray();
    }
}
