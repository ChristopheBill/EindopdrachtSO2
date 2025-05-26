using Microsoft.OpenApi.Validations;
using System;
using WeerEventsApi.Steden;

namespace WeerEventsApi.WeerStations.SpecifiekeWeerstations
{
    public class TemperatuurWeerstation : AbstractWeerStation
    {
        public TemperatuurWeerstation(Stad locatie) : base(locatie) { }

        protected override Meting GenereerMeting()
        {
            double waarde = _random.NextDouble() * 45 - 10; // -10°C tot 35°C
            var meting = new Meting (DateTime.Now,
                Math.Round(waarde, 1),
                Eenheid.GradenCelsius,
                Locatie
            );
            return meting;
        }
    }
}
