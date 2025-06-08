using WeerEventsApi.Steden;

namespace WeerEventsApi.WeerStations.SpecifiekeWeerstations
{
    public class NeerslagWeerstation : AbstractWeerStation
    {
        public NeerslagWeerstation(Stad locatie) : base(locatie) { }
        public override Meting GenereerMeting()
        {
            double waarde = _random.NextDouble() * 20; // 0 tot 20 mm/h
            var meting = new Meting(DateTime.Now,
                Math.Round(waarde, 1),
                Eenheid.MillimeterPerVierkanteMeterPerUur,
                Locatie
            );
            return meting;
        }
    }
    
}
