using Newtonsoft.Json;

namespace OTBAssignment.Model.JsonModel
{
    public class FlightData
    {
        [JsonProperty("id")]
        public required int Id { get; set; }

        [JsonProperty("airline")]
        public required string Airline { get; set; }

        [JsonProperty("from")]
        public required string From { get; set; }

        [JsonProperty("to")]
        public required string To { get; set; }

        [JsonProperty("price")]
        public required decimal Price { get; set; }

        [JsonProperty("departure_date")]
        public required DateTime DepartureDate { get; set; }
    }
}
