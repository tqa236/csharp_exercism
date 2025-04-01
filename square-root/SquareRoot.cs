public static class SquareRoot
{
    public static int Root(int number)
    {
        if (number < 1)
        {
            throw new ArgumentException("Number must be a positive whole number.");
        }

        int left = 1;
        int right = number;

        while (left <= right)
        {
            int middle = left + (right - left) / 2;
            int square = middle * middle;

            if (square == number)
            {
                return middle;
            }
            else if (square < number)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return right;
    }
}
