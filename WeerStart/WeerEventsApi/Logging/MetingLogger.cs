using WeerEventsApi.WeerStations;

namespace WeerEventsApi.Logging;

public class MetingLogger : IMetingLogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
    public void LogMeting(Meting meting)
    {
        if (meting == null)
        {
            throw new ArgumentNullException(nameof(meting), "De meting mag niet null zijn.");
        }
        // Default implementation to log a meting
        Log($"Meting: {meting.Locatie.Naam}, Waarde: {meting.Waarde} {meting.Eenheid}, Timestamp: {meting.Moment}");
        
    }
}