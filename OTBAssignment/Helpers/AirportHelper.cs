using OTBAssignment.Model;

namespace OTBAssignment.Helpers
{
    public static class AirportHelper
    {
        private static Dictionary<Airport, IEnumerable<Airport>> Mapping = new Dictionary<Airport, IEnumerable<Airport>>()
        {
            {
                Airport.LND, [Airport.LGW, Airport.LTN] 
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
