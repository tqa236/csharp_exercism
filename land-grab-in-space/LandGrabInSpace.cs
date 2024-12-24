using System;
using System.Collections.Generic;
using System.Linq;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot
{
    public Coord TopLeft { get; }
    public Coord TopRight { get; }
    public Coord BottomLeft { get; }
    public Coord BottomRight { get; }

    public Plot(Coord topLeft, Coord topRight, Coord bottomLeft, Coord bottomRight)
    {
        TopLeft = topLeft;
        TopRight = topRight;
        BottomLeft = bottomLeft;
        BottomRight = bottomRight;
    }

    public override bool Equals(object obj)
    {
        if (obj is Plot other)
        {
            return TopLeft.Equals(other.TopLeft) &&
                   TopRight.Equals(other.TopRight) &&
                   BottomLeft.Equals(other.BottomLeft) &&
                   BottomRight.Equals(other.BottomRight);
        }
        return false;
    }

    public override int GetHashCode() => HashCode.Combine(TopLeft, TopRight, BottomLeft, BottomRight);
}


public class ClaimsHandler
{
    private readonly List<Plot> _claims = new();
    private Plot? _lastClaim;

    public void StakeClaim(Plot plot)
    {
        _claims.Add(plot);
        _lastClaim = plot;
    }

    public bool IsClaimStaked(Plot plot) => _claims.Contains(plot);

    public bool IsLastClaim(Plot plot) => _lastClaim.HasValue && _lastClaim.Value.Equals(plot);

    public Plot GetClaimWithLongestSide()
    {
        if (!_claims.Any())
            throw new InvalidOperationException("No claims have been staked.");

        return _claims.OrderByDescending(GetLongestSide).First();
    }

    private static double GetLongestSide(Plot plot)
    {
        double side1 = Math.Abs(plot.TopRight.X - plot.TopLeft.X);
        double side2 = Math.Abs(plot.TopRight.Y - plot.BottomRight.Y);
        return Math.Max(side1, side2);
    }
}
