using System;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private readonly DateTime _firstDayOfMonth;
    private readonly DateTime _lastDayOfMonth;

    public Meetup(int month, int year)
    {
        _firstDayOfMonth = new DateTime(year, month, 1);
        _lastDayOfMonth = _firstDayOfMonth.AddMonths(1).AddDays(-1);
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule) => schedule switch
        {
            Schedule.Teenth => FindTeenth(dayOfWeek),
            Schedule.Last => FindLast(dayOfWeek),
            _ => FindByWeekNumber(dayOfWeek, schedule)
        };

    private DateTime FindTeenth(DayOfWeek dayOfWeek)
    {
        var current = _firstDayOfMonth.AddDays(12);
        
        while (current.Day <= 19)
        {
            if (current.DayOfWeek == dayOfWeek)
                return current;
            current = current.AddDays(1);
        }

        throw new ArgumentException("No teenth day found for specified day of week");
    }

    private DateTime FindLast(DayOfWeek dayOfWeek)
    {
        var current = _lastDayOfMonth;
        
        while (current >= _firstDayOfMonth)
        {
            if (current.DayOfWeek == dayOfWeek)
                return current;
            current = current.AddDays(-1);
        }

        throw new ArgumentException("No last day found for specified day of week");
    }

    private DateTime FindByWeekNumber(DayOfWeek dayOfWeek, Schedule schedule)
    {
        var current = _firstDayOfMonth;
        var weekCount = 0;
        var targetWeek = schedule switch
        {
            Schedule.First => 0,
            Schedule.Second => 1,
            Schedule.Third => 2,
            Schedule.Fourth => 3,
            _ => throw new ArgumentException("Invalid schedule")
        };

        while (current <= _lastDayOfMonth)
        {
            if (current.DayOfWeek == dayOfWeek)
            {
                if (weekCount == targetWeek)
                    return current;
                weekCount++;
            }
            current = current.AddDays(1);
        }

        throw new ArgumentException("No matching day found for specified schedule");
    }
}