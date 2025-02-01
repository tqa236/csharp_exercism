using System;

public class Clock : IEquatable<Clock>
{
    private int hours;
    private int minutes;

    public Clock(int hours, int minutes)
    {
        NormalizeTime(hours, minutes);
    }

    private void NormalizeTime(int hours, int minutes)
    {
        int totalMinutes = (hours * 60 + minutes) % (24 * 60);
        if (totalMinutes < 0)
        {
            totalMinutes += 24 * 60;
        }
        this.hours = totalMinutes / 60;
        this.minutes = totalMinutes % 60;
    }

    public Clock Add(int minutesToAdd) => new Clock(this.hours, this.minutes + minutesToAdd);

    public Clock Subtract(int minutesToSubtract) => new Clock(this.hours, this.minutes - minutesToSubtract);

    public override string ToString() => $"{hours:D2}:{minutes:D2}";

    public override bool Equals(object obj) => Equals(obj as Clock);

    public bool Equals(Clock other)
    {
        if (other == null)
            return false;
        return this.hours == other.hours && this.minutes == other.minutes;
    }

    public override int GetHashCode() => HashCode.Combine(hours, minutes);
}
