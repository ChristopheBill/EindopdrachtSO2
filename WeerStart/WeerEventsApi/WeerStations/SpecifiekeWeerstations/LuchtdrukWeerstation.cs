using WeerEventsApi.Steden;

namespace WeerEventsApi.WeerStations.SpecifiekeWeerstations
{
    public class LuchtdrukWeerstation : AbstractWeerStation
    {
        public LuchtdrukWeerstation(Stad locatie) : base(locatie) { }
        protected override Meting GenereerMeting()
        {
            DateTime dateTime = DateTime.Now;
            double waarde = _random.NextDouble() * 50 + 950; // 950 hPa tot 1000 hPa
            var meting = new Meting(dateTime,
                Math.Round(waarde, 1),
                Eenheid.HectoPascal,
                Locatie
            );
            return meting;
        }
    }
    
}
