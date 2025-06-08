using WeerEventsApi.Logging;
using WeerEventsApi.Logging.Decorators;

namespace WeerEventsApi.WeerStations.Managers
{
    public class WeerStationManager
    {
        private readonly List<AbstractWeerStation> _weerStations;
        private readonly IMetingLogger _metingLogger;

        public WeerStationManager(IMetingLogger metingLogger)
        {
            _metingLogger = metingLogger ?? throw new ArgumentNullException(nameof(metingLogger), "De meting logger mag niet null zijn.");
            _weerStations = new List<AbstractWeerStation>();
        }

        public void VoegWeerstationToe(AbstractWeerStation weerStation)
        {
            if (weerStation == null)
            {
                throw new ArgumentNullException(nameof(weerStation), "Het weerstation mag niet null zijn.");
            }

            weerStation.MetingGegenereerd += meting =>
            {
                _metingLogger.LogMeting(meting);
                _metingLogger.Log($"Meting geregistreerd: {meting.Locatie.Naam}, Waarde: {meting.Waarde} {meting.Eenheid}, Timestamp: {meting.Moment}");
                if (_metingLogger is JsonMetingLogger jsonLogger)
                {
                    jsonLogger.LogMeting(meting);
                }
                else if (_metingLogger is XmlMetingLogger xmlLogger)
                {
                    xmlLogger.LogMeting(meting);
                }
            };

            _weerStations.Add(weerStation);
        }

        private void meting(Meting obj)
        {
            throw new NotImplementedException();
        }

        //public WeerStationManager(List<AbstractWeerStation> weerStations)
        //{
        //    _weerStations = weerStations ?? throw new ArgumentNullException(nameof(weerStations), "De lijst met weerstations mag niet null zijn.");
        //}
        //public IEnumerable<AbstractWeerStation> GeefWeerstations()
        //{
        //    return _weerStations;
        //}
        //public void DoeMetingen()
        //{
        //    foreach (var station in _weerStations)
        //    {
        //        station.DoeMeting();
        //    }
        //}
    }
}
