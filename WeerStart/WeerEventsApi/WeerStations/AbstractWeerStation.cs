using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Steden;

namespace WeerEventsApi.WeerStations
{
    public abstract class AbstractWeerStation
    {
        private List<Meting> _metingen = new();
        protected readonly Random _random = new();

        public Stad Locatie { get; }
        public abstract Meting GenereerMeting();
        protected AbstractWeerStation(Stad locatie)
        {
            Locatie = locatie;
        }
        protected void MetingToevoegen(Meting meting)
        {
            _metingen.Add(meting);
        }
        public event Action<Meting>? MetingGegenereerd;
    }
}
