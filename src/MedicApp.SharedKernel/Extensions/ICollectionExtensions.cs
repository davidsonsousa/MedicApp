namespace MedicApp.SharedKernel.Extensions;

public static class ICollectionExtensions
{
    public static void AddRange<T>(this ICollection<T> destination, IEnumerable<T>? source)
    {
        Guard.Against.Null(source, nameof(source));

        if (destination is List<T> list)
        {
            list.AddRange(source);
        }
        else
        {
            foreach (var item in source)
            {
                destination.Add(item);
            }
        }
    }
}
