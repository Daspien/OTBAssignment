using OTBAssignment.Model.JsonModel;

namespace OTBAssignment.Model.Flights
{
    public interface IFlightProvider
    {
        public Task<IQueryable<FlightData>> GetAll();
        public Task<IQueryable<FlightData>> GetBestFlights(FlightSearchOptions options);
    }
}
