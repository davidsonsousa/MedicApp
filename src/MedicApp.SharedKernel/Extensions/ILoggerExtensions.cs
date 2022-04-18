namespace MedicApp.SharedKernel.Extensions;

public static class ILoggerExtensions
{
    /// <summary>
    /// Log a debug entry with the method name
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="methodName">Name of the method</param>
    public static void DebugMethodCall(this ILogger logger, string methodName)
    {
        logger.LogDebug(Constants.DebugMessages.Method, methodName);
    }

    /// <summary>
    /// Log a debug entry with the method name and the method parameter with its value
    /// </summary>
    /// <typeparam name="TParameter"></typeparam>
    /// <param name="logger"></param>
    /// <param name="methodName">Name of the method</param>
    /// <param name="obj">Parameter of the method</param>
    public static void DebugMethodCall<TParameter>(this ILogger logger, string methodName, TParameter? obj)
    {
        var objName = obj?.GetType().Name ?? nameof(obj);
        logger.LogDebug(Constants.DebugMessages.MethodObjectValue, methodName, objName, obj);
    }

    /// <summary>
    /// Log a debug entry with the class name, method name and the method parameter with its value
    /// </summary>
    /// <typeparam name="TParameter"></typeparam>
    /// <param name="logger"></param>
    /// <param name="className">Name of the class</param>
    /// <param name="methodName">Name of the method</param>
    /// <param name="obj">Parameter of the method</param>
    public static void DebugMethodCall<TParameter>(this ILogger logger, string className, string methodName, TParameter? obj)
    {
        var objName = obj?.GetType().Name ?? nameof(obj);
        logger.LogDebug(Constants.DebugMessages.ClassMethodObjectValue, className, methodName, objName, obj);
    }

    /// <summary>
    /// Log an error with the exception, class name and method name
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="ex">Exception object</param>
    /// <param name="className">Name of the class</param>
    /// <param name="methodName">Name of the method</param>
    public static void ErrorMethodCall(this ILogger logger, Exception? ex, string className, string methodName)
    {
        logger.LogError(ex, Constants.DebugMessages.ClassMethod, className, methodName);
    }
}
