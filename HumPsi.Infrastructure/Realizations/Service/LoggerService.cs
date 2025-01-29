using HumPsi.Application.IService;
using ILogger = Serilog.ILogger;

namespace HumPsi.Infrastructure.Realizations.Service;


public class LoggerService(ILogger logger) : ILoggerService
{
    public void LogInformation(string msg)
    {
        logger.Information(msg);
    }

    public void LogWarning(string msg)
    {
        logger.Warning(msg);
    }

    public void LogTrace(string msg)
    {
        logger.Information(msg);
    }

    public void LogDebug(string msg)
    {
        logger.Debug(msg);
    }

    public void LogError(object request, string errorMsg)
    {
        string requestType = request.GetType().ToString();
        string requestClass = requestType.Substring(requestType.LastIndexOf('.') + 1);
        logger.Error($"{requestClass} handled with the error: {errorMsg}");
    }
}