using System.Text.Json.Serialization;

namespace OTBAssignment.Model.JsonModel
{
    public class FlightData
    {
        [JsonPropertyName("id")]
        public required int Id { get; set; }

        [JsonPropertyName("airline")]
        public required string Airline { get; set; }

        [JsonPropertyName("from")]
        public required string From { get; set; }

        [JsonPropertyName("to")]
        public required string To { get; set; }

        [JsonPropertyName("price")]
        public required decimal Price { get; set; }

        [JsonPropertyName("departure_date")]
        public required DateTime DepartureDate { get; set; }
    }
}
