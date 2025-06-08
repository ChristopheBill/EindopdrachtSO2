using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Steden.Managers;
using WeerEventsApi.Weerberichten.Managers;
using WeerEventsApi.WeerStations.Managers;

namespace WeerEventsApi.Facade.Controllers;

public class DomeinController : IDomeinController
{
    private readonly IStadManager _stadManager;
    private readonly WeerStationManager _weerstationManager;
    private readonly IWeerbericht _weerbericht;

    public DomeinController(IStadManager stadManager, WeerStationManager weerStationManager, IWeerbericht weerbericht)
    {
        _stadManager = stadManager;
        _weerstationManager = weerStationManager;
        _weerbericht = weerbericht;
    }

    public IEnumerable<StadDto> GeefSteden()
    {
        return _stadManager.GeefSteden().Select(s => new StadDto
        {
            Naam = s.Naam,
            Beschrijving = s.Beschrijving,
            GekendVoor = s.GekendVoor
        });
    }

    public IEnumerable<WeerStationDto> GeefWeerstations()
    {
        //TODO
        return _weerstationManager.GeefWeerstations().Select(ws => new WeerStationDto
        {
            Soort = ws.GetType().ToString(),
            Stad = ws.Locatie.Naam
        });
    }

    public IEnumerable<MetingDto> GeefMetingen()
    {
        //TODO
        return _weerstationManager.GeefMetingen().Select(m => new MetingDto
        {
            Locatie = m.Locatie.Naam,
            Waarde = m.Waarde,
            Eenheid = m.Eenheid.ToString(),
            Moment = m.Moment
        });
    }

    public void DoeMetingen()
    {
        //TODO
        _weerstationManager.DoeMetingen();
    }

    public WeerBerichtDto GeefWeerbericht()
    {
        //TODO
        var bericht = _weerstationManager.GeefMetingen();
        return _weerbericht.GenereerWeerBericht(bericht);
    }
}