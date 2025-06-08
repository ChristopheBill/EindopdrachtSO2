using WeerEventsApi.Logging.Decorators;
namespace WeerEventsApi.Logging.Factories;

public static class MetingLoggerFactory
{
    public static IMetingLogger Create(bool decorateWithJson = false, bool decorateWithXml = false)
    {
        //TODO Alle combinaties moeten mogelijk zijn (false,false | true,false | false,true | true,true)
        IMetingLogger metingLogger = new MetingLogger();

        if (decorateWithJson)
        {
            metingLogger = new JsonMetingLogger(metingLogger);
        }
        if (decorateWithXml)
        {
            metingLogger = new XmlMetingLogger(metingLogger);
        }

        return metingLogger;
    }
}