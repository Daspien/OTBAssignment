using OTBAssignment.Model.Flights;
using OTBAssignment.Model.Hotels;

namespace OTBAssignment.Model
{
    public class HolidaySearchResult
    {
        public decimal TotalPrice { get; }
        public FlightInfo Flight { get; }
        public HotelInfo Hotel { get; }

        public HolidaySearchResult(decimal totalPrice, FlightInfo flight, HotelInfo hotel)
        {
            TotalPrice = totalPrice;
            Flight = flight;
            Hotel = hotel;
        }
    }
}
