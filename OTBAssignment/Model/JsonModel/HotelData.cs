using Newtonsoft.Json;

namespace OTBAssignment.Model.JsonModel
{
    public class HotelData
    {
        [JsonProperty("id")]
        public required int Id { get; set; }

        [JsonProperty("name")]
        public required string Name { get; set; }

        [JsonProperty("arrival_date")]
        public required DateTime ArrivalDate { get; set; }

        [JsonProperty("price_per_night")]
        public required decimal PricePerNight { get; set; }

        [JsonProperty("local_airports")]
        public required IEnumerable<string> LocalAirports { get; set; }

        [JsonProperty("nights")]
        public required int Nights { get; set; }

    }
}