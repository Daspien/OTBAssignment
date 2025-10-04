using OTBAssignment.Model;

namespace OTBAssignment.Helpers
{
    public static class AirportHelper
    {
        private static Dictionary<Airport, IEnumerable<Airport>> Mapping = new Dictionary<Airport, IEnumerable<Airport>>()
        {
            {
                Airport.LND, [Airport.LGW, Airport.LTN] 
            },
            {
                Airport.ANY, [Airport.LTN, Airport.LGW, Airport.PMI, Airport.AGP, Airport.MAN, Airport.TFS, Airport.LPA]
            }
        };

        public static IEnumerable<Airport> GetCombinedAirports(Airport airport)
        {
            if (Mapping.TryGetValue(airport, out IEnumerable<Airport>? value))
                return value;
            return [airport];
        }
    }
}
