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
                    var holidaySearchResult = new HolidaySearchResult(hotel.PricePerNight * duration, GetFlightInfo(flight.Id, flight.From, flight.To), GetHotelInfo(hotel.Id, hotel.Name, hotel.PricePerNight));
                    results.Add(holidaySearchResult);
                }
            }
            return Task.FromResult(results.AsEnumerable());
        }

        private FlightInfo GetFlightInfo(int id, Airport from, Airport to)
        {
            return new FlightInfo(id, from.ToString(), to.ToString());
        }
        private HotelInfo GetHotelInfo(int id, string name, decimal price)
        {
            return new HotelInfo(id, name, price);
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
