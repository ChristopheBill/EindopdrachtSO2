using WeerEventsApi.Facade.Dto;
using WeerEventsApi.WeerStations;

namespace WeerEventsApi.WeerBerichten.Managers
{
    public class WeerBericht
    {
        public WeerBerichtDto GenereerWeerBericht(IEnumerable<Meting> metingen)
        {
            Thread.Sleep(5000); // Simuleer vertraging voor het genereren van een weerbericht


            return new WeerBerichtDto
            {
                Timestamp = DateTime.Now,
                Inhoud = string.Join(", ", metingen.Select(m => $"{m.Locatie.Naam}: {m.Waarde} {m.Eenheid}")),
            };
        }
    }
}
