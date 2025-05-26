using WeerEventsApi.Facade.Dto;

namespace WeerEventsApi.Facade.Controllers;

public interface IDomeinController
{
    IEnumerable<StadDto> GeefSteden();
    
    IEnumerable<WeerStation> GeefWeerstations();

    IEnumerable<MetingDto> GeefMetingen();
    
    void DoeMetingen();
    
    WeerBerichtDto GeefWeerbericht();
}