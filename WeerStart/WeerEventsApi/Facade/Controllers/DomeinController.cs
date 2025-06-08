using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Steden.Managers;
using WeerEventsApi.WeerStations.Managers;

namespace WeerEventsApi.Facade.Controllers;

public class DomeinController : IDomeinController
{
    private readonly IStadManager _stadManager;
    private readonly WeerStationManager _weerstationManager;

    public DomeinController(IStadManager stadManager, WeerStationManager weerStationManager)
    {
        _stadManager = stadManager;
        _weerstationManager = weerStationManager;
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
        throw new NotImplementedException();
    }
}