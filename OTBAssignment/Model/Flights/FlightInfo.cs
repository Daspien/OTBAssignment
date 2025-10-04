namespace OTBAssignment.Model.Flights
{
    public class FlightInfo
    {
        public int Id { get; }
        public string DepartingFrom { get; }
        public string TravelingTo { get; }
        public FlightInfo(int id, string departingFrom, string travelingTo)
        {
            Id = id;
            DepartingFrom = departingFrom;
            TravelingTo = travelingTo;
        }
    }
}
