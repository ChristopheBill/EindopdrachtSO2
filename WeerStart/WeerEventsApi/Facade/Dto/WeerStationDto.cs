using WeerEventsApi.Steden;
using WeerEventsApi.WeerStations;

namespace WeerEventsApi.Facade.Dto;

public class WeerStationDto
{
    private List<Meting> _metingen;
    protected readonly Random _random = new();
    public Stad Locatie { get; }
    //protected Meting GenereerMeting();
}