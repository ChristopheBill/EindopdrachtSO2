using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Steden;

namespace WeerEventsApi.WeerStations
{
    public abstract class AbstractWeerStation
    {
        private List<Meting> _metingen;
        protected readonly Random _random = new();
        public Stad Locatie { get; }
        protected abstract Meting GenereerMeting();
    }
}
