using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    readonly private List<int> list;
    public HighScores(List<int> list) => this.list = list;

    public List<int> Scores() => list;

    public int Latest() => list.Last();

    public int PersonalBest() => list.Max();

    public List<int> PersonalTopThree() => list.OrderByDescending(r => r).Take(3).ToList();
}