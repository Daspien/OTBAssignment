using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using OTBAssignment.Model.JsonModel;
using OTBAssignment.Helpers;

namespace OTBAssignment.Model.Flights
{
    public class JsonFlightsProvider : IFlightProvider
    {
        private readonly string FlightsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", "FlightData.json");

        public async Task<IQueryable<FlightData>> GetAll()
        {
            if (!File.Exists(FlightsFilePath))
                return new List<FlightData>().AsQueryable();
            var flightJson = await File.ReadAllTextAsync(FlightsFilePath);
            var jsonOptions = new JsonSerializerSettings();
            jsonOptions.Converters.Add(new StringEnumConverter());
            var flights = JsonConvert.DeserializeObject<List<FlightData>>(flightJson, jsonOptions);

            if (flights is null)
                return new List<FlightData>().AsQueryable();

            return flights.AsQueryable();
        }

        public async Task<IQueryable<FlightData>> GetBestFlights(FlightSearchOptions options)
        {
            if (!File.Exists(FlightsFilePath))
                return new List<FlightData>().AsQueryable();
            var flightJson = await File.ReadAllTextAsync(FlightsFilePath);
            var jsonOptions = new JsonSerializerSettings();
            jsonOptions.Converters.Add(new StringEnumConverter());
            var flights = JsonConvert.DeserializeObject<List<FlightData>>(flightJson, jsonOptions);

            if (flights is null)
                return new List<FlightData>().AsQueryable();

            var bestFlights = flights.Where(flight => AirportHelper.GetCombinedAirports(options.From).Contains(flight.From) && AirportHelper.GetCombinedAirports(options.To).Contains(flight.To) && options.DepartureDate == flight.DepartureDate).
                OrderBy(flight => flight.Price);

            return bestFlights.AsQueryable();
        }
    }
}
