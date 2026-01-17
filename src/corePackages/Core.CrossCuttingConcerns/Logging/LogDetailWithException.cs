
namespace Core.CrossCuttingConcerns.Logging
{
    public class LogDetailWithException : LogDetail
    {
        public string ExceptionMessage { get; set; }

        public LogDetailWithException()
        {
            ExceptionMessage = string.Empty;
        }

        public LogDetailWithException(string fullName,
         string methodName, string user, string exceptionMessage,
          List<LogParameter> logParameters) : base(fullName, methodName, user, logParameters)
        {
            ExceptionMessage = exceptionMessage;
        }
    }
}