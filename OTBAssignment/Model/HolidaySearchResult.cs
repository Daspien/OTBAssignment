namespace OTBAssignment.Model
{
    public class HolidaySearchResult
    {
        public decimal TotalPrice { get; set; }
        public FlightInfo Flight { get; set; }
        public HotelInfo Hotel { get; set; }

        public HolidaySearchResult(decimal totalPrice, FlightInfo flight, HotelInfo hotel)
        {
            TotalPrice = totalPrice;
            Flight = flight;
            Hotel = hotel;
        }
    }
}
