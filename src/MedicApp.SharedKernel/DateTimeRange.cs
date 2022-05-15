namespace MedicApp.SharedKernel;

public class DateTimeRange : ValueObject<DateTimeRange>
{
    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public DateTimeRange(DateTime start, DateTime end)
    {
        Guard.Against.LowerPrecedeDate(start, end, "start");
        Start = start;
        End = end;
    }

    public DateTimeRange(DateTime start, TimeSpan duration) : this(start, start.Add(duration))
    {
    }

    public DateTimeRange() : this(DateTime.Now, DateTime.Now.AddHours(1))
    {

    }

    public int DurationInMinutes()
    {
        return (End - Start).Minutes;
    }

    public DateTimeRange NewEnd(DateTime newEnd)
    {
        return new DateTimeRange(Start, newEnd);
    }

    public DateTimeRange NewDuration(TimeSpan newDuration)
    {
        return new DateTimeRange(Start, newDuration);
    }

    public DateTimeRange NewStart(DateTime newStart)
    {
        return new DateTimeRange(newStart, End);
    }

    public static DateTimeRange CreateOneDayRange(DateTime day)
    {
        return new DateTimeRange(day, day.AddDays(1));
    }

    public static DateTimeRange CreateOneWeekRange(DateTime startDay)
    {
        return new DateTimeRange(startDay, startDay.AddDays(7));
    }

    public bool Overlaps(DateTimeRange dateTimeRange)
    {
        return Start < dateTimeRange.End
               && End > dateTimeRange.Start;
    }
}
