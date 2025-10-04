using OTBAssignment.Model;
using OTBAssignment.Model.JsonModel;
using OTBAssignment.Model.Flights;
using OTBAssignment.Model.Hotels;

namespace OTBAssignment
{
    public class HolidaySearch(IFlightProvider flightProvider, IHotelProvider hotelProvider) : IHolidaySearch
    {
        public async Task<IEnumerable<HolidaySearchResult>> GetResults(Airport departingFrom, Airport travelingTo, DateTime departureDate, short duration)
        {
            var bestHotels = await hotelProvider.GetBestHotels(GetHotelOptions(travelingTo, departureDate, duration));
            var bestFlights = await flightProvider.GetBestFlights(GetFlightOptions(departingFrom, travelingTo, departureDate));
            return await GetAllResultsSorted(bestHotels, bestFlights, duration);
        }

        private Task<IEnumerable<HolidaySearchResult>> GetAllResultsSorted(IQueryable<HotelData> hotels, IQueryable<FlightData> flights, short duration)
        {
            var results = new List<HolidaySearchResult>();
            foreach (var hotel in hotels)
            {
                foreach (var flight in flights)
                {
                    var holidaySearchResult = new HolidaySearchResult(hotel.PricePerNight * duration + flight.Price,
                        GetFlightInfo(flight.Id, flight.From, flight.To, flight.Price),
                        GetHotelInfo(hotel.Id, hotel.Name, hotel.PricePerNight, hotel.PricePerNight * duration));
                    results.Add(holidaySearchResult);
                }
            }
            return Task.FromResult(results.AsEnumerable());
        }

        private FlightInfo GetFlightInfo(int id, Airport from, Airport to, decimal price)
        {
            return new FlightInfo(id, from.ToString(), to.ToString(), price);
        }
        private HotelInfo GetHotelInfo(int id, string name, decimal price, decimal totalPrice)
        {
            return new HotelInfo(id, name, price, totalPrice);
        }

        private HotelSearchOptions GetHotelOptions(Airport destination, DateTime departure, short duration)
        {
            return new HotelSearchOptions(destination, departure, duration);
        }

        private FlightSearchOptions GetFlightOptions(Airport from, Airport to, DateTime departure)
        {
            return new FlightSearchOptions(from, to, departure);
        }
    }
}
