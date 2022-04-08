namespace MedicApp.SharedKernel.Extensions;

public static class GuardClauseExtensions
{
    public static void LowerPrecedeDate(this IGuardClause guardClause, DateTime value, DateTime dateToPrecede, string parameterName)
    {
        if (value >= dateToPrecede)
        {
            throw new ArgumentOutOfRangeException(parameterName);
        }
    }
}
