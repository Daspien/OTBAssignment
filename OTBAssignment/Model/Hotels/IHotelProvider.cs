using OTBAssignment.Model.Flights;
using OTBAssignment.Model.JsonModel;

namespace OTBAssignment.Model.Hotels
{
    public interface IHotelProvider
    {
        public Task<IQueryable<HotelData>> GetAll();
        public Task<IQueryable<HotelData>> GetBestHotels(HotelSearchOptions options);
    }
}
