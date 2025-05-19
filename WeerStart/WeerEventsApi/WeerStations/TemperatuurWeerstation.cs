using System;
using WeerEventsApi.Steden;

namespace WeerEventsApi.WeerStations
{
    public class TemperatuurWeerstation : AbstractWeerStation
    {
        public TemperatuurWeerstation(Stad locatie) : base(locatie) { }

        protected override Meting GenereerMeting()
        {
            double waarde = _random.NextDouble() * 45 - 10; // -10°C tot 35°C
            return new Meting
            {
                Moment = DateTime.Now,
                Waarde = Math.Round(waarde, 1),
                Eenheid = Eenheid.GradenCelsius,
                Locatie = Locatie
            };
        }
    }
}
