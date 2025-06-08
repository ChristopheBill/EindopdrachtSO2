using WeerEventsApi.WeerStations;

namespace WeerEventsApi.Logging.Decorators
{
    public class XmlMetingLogger : IMetingLogger
    {
        private readonly IMetingLogger _metingLogger;

        public XmlMetingLogger(IMetingLogger metingLogger)
        {
            _metingLogger = metingLogger ?? throw new ArgumentNullException(nameof(metingLogger), "De meting logger mag niet null zijn.");
        }

        public void Log(string message)
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
            // Serialize the meting object to XML
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Meting));
            using (var stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, meting);
                string xmlMeting = stringWriter.ToString();
                // Log the XML string using the IMetingLogger
                _metingLogger.Log(xmlMeting);
            }
        }
    }
}
