namespace OTBAssignment.Model
{
    public class HolidaySearchResult
    {
        public string TotalPrice { get; set; }
        public FlightInfo Flight { get; set; }
        public HotelInfo Hotel { get; set; }

        public HolidaySearchResult(string totalPrice, FlightInfo flight, HotelInfo hotel)
        {
            TotalPrice = totalPrice;
            Flight = flight;
            Hotel = hotel;
        }
    }
}
