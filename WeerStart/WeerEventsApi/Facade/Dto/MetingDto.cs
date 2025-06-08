using WeerEventsApi.WeerStations;

namespace WeerEventsApi.Facade.Dto;

public class MetingDto
{
    //TODO
    public string Locatie { get; internal set; }
    public double Waarde { get; internal set; }
    public Eenheid Eenheid { get; internal set; }
    public DateTime Moment { get; internal set; }
}