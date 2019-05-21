using System;
using System.Collections.Generic;


namespace Background.Common
{
    public interface ILogger
    {
        bool IsDebugEnabled { get; }

        void Debug(object message, Exception e = null);
        void Info(object message, Exception e = null);
        void Error(object message, Exception e = null);

        void DebugFormat(string message, params object[] args);
        void InfoFormat(string message, params object[] args);
        void ErrorFormat(string message, params object[] args);
        List<string> GetRecentExceptionMessages();
    }
}
