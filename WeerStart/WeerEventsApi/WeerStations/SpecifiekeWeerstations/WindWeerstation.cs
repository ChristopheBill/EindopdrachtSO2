using WeerEventsApi.Steden;

namespace WeerEventsApi.WeerStations.SpecifiekeWeerstations
{
    public class WindWeerstation : AbstractWeerStation
    {
        public WindWeerstation(Stad locatie) : base(locatie) { }
        protected override Meting GenereerMeting()
        {
            double waarde = _random.NextDouble() * 150; // 0 tot 150 km/h
            var meting = new Meting(DateTime.Now,
                Math.Round(waarde, 1),
                Eenheid.KilometerPerUur,
                Locatie
            );
            return meting;
        }
    }
}

