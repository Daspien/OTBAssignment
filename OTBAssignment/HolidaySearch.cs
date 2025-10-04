using OTBAssignment.Model;
using Newtonsoft.Json;
using OTBAssignment.Model.JsonModel;
using Newtonsoft.Json.Converters;
using OTBAssignment.Helpers;
using System.Linq;
using OTBAssignment.Model.Flights;
using OTBAssignment.Model.Hotels;

namespace OTBAssignment
{
    public class HolidaySearch(IFlightProvider flightProvider, IHotelProvider hotelProvider) : IHolidaySearch
    {
        public async Task<IEnumerable<HolidaySearchResult>> GetResults(Airport departingFrom, Airport travelingTo, DateTime departureDate, short duration)
        {
            var results = new List<HolidaySearchResult>();
            var bestHotels = await hotelProvider.GetBestHotels(GetHotelOptions(travelingTo, departureDate, duration));
            var bestFlights = await flightProvider.GetBestFlights(GetFlightOptions(departingFrom, travelingTo, departureDate));
            var holidaySearchResult = new HolidaySearchResult(bestHotels.First().PricePerNight * duration, GetFlightInfo(bestFlights.First().Id, bestFlights.First().From, bestFlights.First().To), GetHotelInfo(bestHotels.First().Id, bestHotels.First().Name, bestHotels.First().PricePerNight));
            results.Add(holidaySearchResult);
            return results;
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
