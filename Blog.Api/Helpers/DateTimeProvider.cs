namespace Blog.Api.Helpers;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime DateTimeNow()
    {
        return DateTime.Now;
    }
}