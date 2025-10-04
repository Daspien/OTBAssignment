namespace OTBAssignment.Model
{
    public class FlightInfo
    {
        public int Id { get; set; }
        public string DepartingFrom { get; set; }
        public string TravelingTo { get; set; }
        public FlightInfo(int id, string departingFrom, string travelingTo)
        {
            Id = id;
            DepartingFrom = departingFrom;
            TravelingTo = travelingTo;
        }
    }
}
