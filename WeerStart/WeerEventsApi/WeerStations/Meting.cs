using static WeerEventsApi.WeerStations.AbstractWeerStation;
using WeerEventsApi.Steden;

namespace WeerEventsApi.WeerStations
{
    public class Meting
    {
        public Meting(DateTime moment, double waarde, Eenheid eenheid, Stad locatie)
        {
            Moment = moment;
            Waarde = waarde;
            Eenheid = eenheid;
            Locatie = locatie;
        }

        public DateTime Moment { get; set; }
        public double Waarde { get; set; }
        public Eenheid Eenheid { get; set; }
        public Stad Locatie { get; set; }
    }
}
