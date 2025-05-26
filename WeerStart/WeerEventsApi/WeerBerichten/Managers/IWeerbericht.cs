using WeerEventsApi.Facade.Dto;
using WeerEventsApi.WeerStations;

namespace WeerEventsApi.Weerberichten.Managers
{
    public interface IWeerbericht
    {
        WeerBerichtDto GenereerWeerBericht(IEnumerable<Meting> metingen);
    }
}
