using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Steden;
using WeerEventsApi.WeerStations;
using WeerEventsApi.WeerStations.SpecifiekeWeerstations;

namespace WeerEventsApi.Logging.Factories
{
    public static class WeerStationFactory
    {
        private static readonly Random _random = new();
        public static AbstractWeerStation MaakWeerStation(Stad stad, int soort)
        {
            switch (soort)
            {
                case 0:
                    return new TemperatuurWeerstation(stad);
                    case 1:
                    return new NeerslagWeerstation(stad);
                    case 2:
                    return new WindWeerstation(stad);
                    case 3:
                    return new LuchtdrukWeerstation(stad);
                    default:
                    throw new InvalidOperationException("Ongeldige keuze voor weerstationtype.");
            };
        }

        public static AbstractWeerStation MaakWillekeurigWeerstationVoorStad(Stad stad)
        {
            int soort = _random.Next(0, 4);
            return MaakWeerStation(stad, soort);
        }
    }
}
