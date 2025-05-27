using WeerEventsApi.Logging;

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
