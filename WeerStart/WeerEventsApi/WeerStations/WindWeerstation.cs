using WeerEventsApi.Steden;

namespace WeerEventsApi.WeerStations
{
    public class WindWeerstation : AbstractWeerStation
    {
        public WindWeerstation(Stad locatie) : base(locatie) { }
        protected override Meting GenereerMeting()
        {
            double waarde = _random.NextDouble() * 150; // 0 tot 150 km/h
            return new Meting
            {
                Moment = DateTime.Now,
                Waarde = Math.Round(waarde, 1),
                Eenheid = Eenheid.KilometerPerUur,
                Locatie = Locatie
            };
        }
    }
}

