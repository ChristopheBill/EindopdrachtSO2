using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Steden;
using WeerEventsApi.WeerStations;
using WeerEventsApi.WeerStations.SpecifiekeWeerstations;

namespace WeerEventsApi.Logging.Factories
{
    public static class WeerStationFactory
    {
        private static readonly Random _random = new();
        public static List<AbstractWeerStation> Maak12WillekeurigeWeerstations(List<Stad> steden)
        {
            if (steden == null || steden.Count == 0)
                throw new ArgumentException("De lijst met steden mag niet leeg zijn.", nameof(steden));

            var weerstations = new List<AbstractWeerStation>();

            for (int i = 0; i < 12; i++)
            {
                var stad = steden[_random.Next(steden.Count)];
                weerstations.Add(MaakWillekeurigWeerstationVoorStad(stad));
            }

            return weerstations;
        }

        public static AbstractWeerStation MaakWillekeurigWeerstationVoorStad(Stad stad)
        {
            if (stad == null)
                throw new ArgumentNullException(nameof(stad));

            return _random.Next(4) switch
            {
                0 => new TemperatuurWeerstation(stad),
                1 => new NeerslagWeerstation(stad),
                2 => new WindWeerstation(stad),
                3 => new LuchtdrukWeerstation(stad),
                _ => throw new InvalidOperationException("Ongeldige keuze voor weerstationtype.")
            };
        }
    }
}
