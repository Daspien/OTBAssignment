using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using OTBAssignment.Model.JsonModel;
using OTBAssignment.Helpers;

namespace OTBAssignment.Model.Hotels
{
    public class JsonHotelProvider : IHotelProvider
    {
        private readonly string HotelsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", "HotelData.json");

        public async Task<IQueryable<HotelData>> GetAll()
        {
            if (!File.Exists(HotelsFilePath))
                return new List<HotelData>().AsQueryable();
            var hotelJson = await File.ReadAllTextAsync(HotelsFilePath);
            var jsonOptions = new JsonSerializerSettings();
            jsonOptions.Converters.Add(new StringEnumConverter());
            var hotels = JsonConvert.DeserializeObject<List<HotelData>>(hotelJson, jsonOptions);

            if (hotels is null)
                return new List<HotelData>().AsQueryable();

            return hotels.AsQueryable();
        }

        public async Task<IQueryable<HotelData>> GetBestHotels(HotelSearchOptions options)
        {
            if (!File.Exists(HotelsFilePath))
                return new List<HotelData>().AsQueryable();
            var hotelJson = await File.ReadAllTextAsync(HotelsFilePath);
            var jsonOptions = new JsonSerializerSettings();
            jsonOptions.Converters.Add(new StringEnumConverter());
            var hotels = JsonConvert.DeserializeObject<List<HotelData>>(hotelJson, jsonOptions);

            if (hotels is null)
                return new List<HotelData>().AsQueryable();

            var bestHotels = hotels.Where(hotel => hotel.LocalAirports.Any(localAirport => AirportHelper.GetCombinedAirports(options.Destination).Contains(localAirport)) && hotel.ArrivalDate == options.DepartureDate && hotel.Nights == options.Duration).
                OrderBy(hotel => hotel.PricePerNight);

            return bestHotels.AsQueryable();
        }
    }
}
