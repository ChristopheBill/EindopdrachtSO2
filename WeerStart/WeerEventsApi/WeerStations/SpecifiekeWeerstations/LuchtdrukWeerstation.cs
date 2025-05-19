using WeerEventsApi.Steden;

namespace WeerEventsApi.WeerStations.SpecifiekeWeerstations
{
    public class LuchtdrukWeerstation : AbstractWeerStation
    {
        public LuchtdrukWeerstation(Stad locatie) : base(locatie) { }
        protected override Meting GenereerMeting()
        {
            double waarde = _random.NextDouble() * 50 + 950; // 950 hPa tot 1000 hPa
            return new Meting
            {
                Moment = DateTime.Now,
                Waarde = Math.Round(waarde, 1),
                Eenheid = Eenheid.HectoPascal,
                Locatie = Locatie
            };
        }
    }
    
}
