using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Weerberichten.Managers;
using WeerEventsApi.WeerStations;

namespace WeerEventsApi.WeerBerichten.Proxies
{
    public class WeerBerichtProxy : IWeerbericht
    {
        private readonly IWeerbericht _weerBericht;
        private DateTime _lastCacheTime;
        private WeerBerichtDto _cachedWeerBericht;
        public WeerBerichtProxy(IWeerbericht weerBerichtManager)
        {
            _weerBericht = weerBerichtManager;
            _lastCacheTime = DateTime.MinValue;
        }
        public WeerBerichtDto GenereerWeerBericht(IEnumerable<Meting> metingen)
        {
            if ((DateTime.Now - _lastCacheTime).TotalMinutes > 1 && _cachedWeerBericht != null)
            {
                _cachedWeerBericht = _weerBericht.GenereerWeerBericht(metingen);
                _lastCacheTime = DateTime.Now;
                return _cachedWeerBericht;
            }
            
            return _cachedWeerBericht;
        }
    }
}
