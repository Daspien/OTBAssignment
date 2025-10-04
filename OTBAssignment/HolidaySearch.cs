using OTBAssignment.Model;
using Newtonsoft.Json;
using OTBAssignment.Model.JsonModel;

namespace OTBAssignment
{
    public class HolidaySearch : IHolidaySearch
    {
        private string DepartingFrom { get; set; }
        private string TravelingTo { get; set; }
        private string DepartureDate { get; set; }
        private short Duration { get; set; }

        private readonly string FlightsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", "FlightData.json");
        private readonly string HotelsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", "HotelData.json");

        public HolidaySearch(string departingFrom, string travelingTo, string departureDate, short duration)
        {
            DepartingFrom = departingFrom;
            TravelingTo = travelingTo;
            DepartureDate = departureDate;
            Duration = duration;
        }

        public async Task<IEnumerable<HolidaySearchResult>> GetResults()
        {
            var results = new List<HolidaySearchResult>();
            var flightJson = await File.ReadAllTextAsync(FlightsFilePath);
            var flights = JsonConvert.DeserializeObject<List<FlightData>>(flightJson);
            var hotelJson = await File.ReadAllTextAsync(HotelsFilePath);
            var hotels = JsonConvert.DeserializeObject<List<HotelData>>(hotelJson);
            var holidaySearchResult = new HolidaySearchResult("0", new FlightInfo(flights.First().Id, flights.First().From, flights.First().To), new HotelInfo(hotels.First().Id, hotels.First().Name, (hotels.First().PricePerNight * Duration).ToString()));
            results.Add(holidaySearchResult);
            return results;
        }

    }
}
