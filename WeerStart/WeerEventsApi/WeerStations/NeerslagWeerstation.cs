using WeerEventsApi.Steden;

namespace WeerEventsApi.WeerStations
{
    public class NeerslagWeerstation : AbstractWeerStation
    {
        public NeerslagWeerstation(Stad locatie) : base(locatie) { }
        protected override Meting GenereerMeting()
        {
            double waarde = _random.NextDouble() * 20; // 0 tot 20 mm/h
            return new Meting
            {
                Moment = DateTime.Now,
                Waarde = Math.Round(waarde, 1),
                Eenheid = Eenheid.MillimeterPerVierkanteMeterPerUur,
                Locatie = Locatie
            };
        }
    }
    
}
