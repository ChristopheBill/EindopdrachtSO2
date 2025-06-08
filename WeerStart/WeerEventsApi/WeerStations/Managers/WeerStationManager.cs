using WeerEventsApi.Logging;
using WeerEventsApi.Logging.Decorators;
using WeerEventsApi.Logging.Factories;
using WeerEventsApi.Steden;

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

        public IEnumerable<AbstractWeerStation> GeefWeerstations()
        {
            return _weerStations.AsReadOnly();
        }

        public void SetupRandomWeerstations(IEnumerable<Stad> steden, int aantalWeerstations)
        {
            if (steden == null || !steden.Any())
            {
                throw new ArgumentException("De lijst met steden mag niet null of leeg zijn.", nameof(steden));
            }
            if (aantalWeerstations <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(aantalWeerstations), "Het aantal weerstations moet groter dan 0 zijn.");
            }
            var random = new Random();
            for (int i = 0; i < aantalWeerstations; i++)
            {
                var stad = steden.ElementAt(random.Next(steden.Count()));
                var weerStation = WeerStationFactory.MaakWillekeurigWeerstationVoorStad(stad); // Aangenomen dat RandomWeerStation een implementatie is van AbstractWeerStation
                VoegWeerstationToe(weerStation);
            }
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
