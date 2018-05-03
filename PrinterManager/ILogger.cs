namespace PrinterManager
{
    public interface ILogger
    {
        void Log(object source, LoggerEventArgs args);
        void Register(Manager manager);
        void Unregister(Manager manager);
    }
}
