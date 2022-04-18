namespace MedicApp.SharedKernel.Extensions;
public static class IReturnValueExtensions
{
    public static T As<T>(this IReturnValue returnValue) where T : class
    {
        var value = ((ReturnValue<T>)returnValue).Value;

        Guard.Against.Null(value, nameof(value));

        return value;
    }
}
