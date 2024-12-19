using System;
using System.Collections.Generic;

public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        var triangle = new List<List<int>>();

        for (int i = 0; i < rows; i++)
        {
            var row = new List<int>([1]);
            
            for (int j = 1; j < i; j++)
            {
                int value = triangle[i - 1][j - 1] + triangle[i - 1][j];
                row.Add(value);
            }

            if (i > 0)
            {
                row.Add(1);
            }

            triangle.Add(row);
        }

        return triangle;
    }
}
