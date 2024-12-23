using System;

class WeighingMachine
{
    public WeighingMachine(int precision)
    {
        Precision = precision;
    }

    public int Precision { get; }
    public double TareAdjustment { get; set; } = 5;

    private double weight;
    public double Weight
    {
        get => weight;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Weight cannot be negative.");
            weight = value;
        }
    }

    public string DisplayWeight
    {
        get
        {
            double displayWeight = Math.Round(Weight - TareAdjustment, Precision);
            return $"{displayWeight.ToString($"F{Precision}")} kg";
        }
    }
}