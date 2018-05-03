using System;

namespace PrinterManager
{
    public class LoggerEventArgs : EventArgs
    {
        public string Message { get; private set; }

        public LoggerEventArgs(string message)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }
    }
}
