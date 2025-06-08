using WeerEventsApi.WeerStations;

namespace WeerEventsApi.Facade.Dto;

public class MetingDto
{
    //TODO
    public string Locatie { get; internal set; }
    public double Waarde { get; internal set; }
    public string Eenheid { get; internal set; }
    public DateTime Moment { get; internal set; }
}