namespace MedicApp.SharedKernel.Extensions;

public static class IResultExtensions
{
    public static T As<T>(this IResult result) where T : class
    {
        var value = ((Result<T>)result).Value;

        Guard.Against.Null(value, nameof(value));

        return value;
    }
}
