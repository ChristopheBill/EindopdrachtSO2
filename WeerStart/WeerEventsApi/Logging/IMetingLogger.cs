using WeerEventsApi.WeerStations;

namespace WeerEventsApi.Logging;

public interface IMetingLogger
{
    void Log(string message);

    void LogMeting(Meting meting); 
    
}