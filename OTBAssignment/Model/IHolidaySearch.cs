namespace OTBAssignment.Model
{
    public interface IHolidaySearch
    {
        public Task<IEnumerable<HolidaySearchResult>> GetResults(Airport departingFrom, Airport travelingTo, DateTime departureDate, short duration);
    }
}
