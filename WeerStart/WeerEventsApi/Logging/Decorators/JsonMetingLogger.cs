using WeerEventsApi.WeerStations;

namespace WeerEventsApi.Logging.Decorators
{
    public class JsonMetingLogger : IMetingLogger
    {
        private IMetingLogger _metingLogger;

        public JsonMetingLogger(IMetingLogger metingLogger)
        {
            _metingLogger = metingLogger ?? throw new ArgumentNullException(nameof(metingLogger), "De meting logger mag niet null zijn.");
        }

        public void Log (string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Het bericht mag niet null of leeg zijn.", nameof(message));
            }
            // Log the message using the IMetingLogger
            _metingLogger.Log(message);
        }

        public void LogMeting(Meting meting)
        {
            if (meting == null)
            {
                throw new ArgumentNullException(nameof(meting), "De meting mag niet null zijn.");
            }
            // Serialize the meting object to JSON
            string jsonMeting = System.Text.Json.JsonSerializer.Serialize(meting);
            // Log the JSON string using the IMetingLogger
            _metingLogger.Log(jsonMeting);
        }
    }
}
