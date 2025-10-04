using System.Text.Json.Serialization;

namespace OTBAssignment.Model.JsonModel
{
    public class HotelData
    {
        [JsonPropertyName("id")]
        public required int Id { get; set; }

        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("arrival_date")]
        public required DateTime ArrivalDate { get; set; }

        [JsonPropertyName("price_per_night")]
        public required decimal PricePerNight { get; set; }

        [JsonPropertyName("local_airports")]
        public required IEnumerable<string> LocalAirports { get; set; }

        [JsonPropertyName("nights")]
        public required int Nights { get; set; }

    }
}