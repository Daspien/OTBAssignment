namespace OTBAssignment.Model
{
    public interface IHolidaySearch
    {
        public Task<IEnumerable<HolidaySearchResult>> GetResults();
    }
}
