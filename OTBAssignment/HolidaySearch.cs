using OTBAssignment.Model;
using Newtonsoft.Json;
using OTBAssignment.Model.JsonModel;
using Newtonsoft.Json.Converters;
using OTBAssignment.Helpers;
using System.Linq;

namespace OTBAssignment
{
    public class HolidaySearch : IHolidaySearch
    {
        private Airport DepartingFrom { get; set; }
        private Airport TravelingTo { get; set; }
        private DateTime DepartureDate { get; set; }
        private short Duration { get; set; }

        private readonly string FlightsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", "FlightData.json");
        private readonly string HotelsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", "HotelData.json");

        public HolidaySearch(Airport departingFrom, Airport travelingTo, DateTime departureDate, short duration)
        {
            DepartingFrom = departingFrom;
            TravelingTo = travelingTo;
            DepartureDate = departureDate;
            Duration = duration;
        }

        public async Task<IEnumerable<HolidaySearchResult>> GetResults()
        {
            var results = new List<HolidaySearchResult>();
            var options = new JsonSerializerSettings();
            options.Converters.Add(new StringEnumConverter());
            var flightJson = await File.ReadAllTextAsync(FlightsFilePath);
            var flights = JsonConvert.DeserializeObject<List<FlightData>>(flightJson, options);
            var hotelJson = await File.ReadAllTextAsync(HotelsFilePath);
            var hotels = JsonConvert.DeserializeObject<List<HotelData>>(hotelJson, options);

            var compatibleFlights = flights.Where(flight => AirportHelper.GetCombinedAirports(DepartingFrom).Contains(flight.From) && AirportHelper.GetCombinedAirports(TravelingTo).Contains(flight.To) && DepartureDate == flight.DepartureDate);
            var compatibleHotels = hotels.Where(hotel => hotel.LocalAirports.Any(localAirport => AirportHelper.GetCombinedAirports(TravelingTo).Contains(localAirport)) && hotel.ArrivalDate == DepartureDate && hotel.Nights == Duration);

            var bestFlights = compatibleFlights.OrderBy(flight => flight.Price);
            var bestHotels = compatibleHotels.OrderBy(hotel => hotel.PricePerNight);

            var holidaySearchResult = new HolidaySearchResult(bestHotels.First().PricePerNight*Duration, new FlightInfo(bestFlights.First().Id, bestFlights.First().From.ToString(), bestFlights.First().To.ToString()), new HotelInfo(bestHotels.First().Id, bestHotels.First().Name, (bestHotels.First().PricePerNight).ToString()));
            results.Add(holidaySearchResult);
            return results;
        }

    }
}
