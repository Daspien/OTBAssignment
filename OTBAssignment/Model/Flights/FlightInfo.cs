namespace OTBAssignment.Model.Flights
{
    public class FlightInfo
    {
        public int Id { get; }
        public string DepartingFrom { get; }
        public string TravelingTo { get; }
        public decimal Price { get; }
        public FlightInfo(int id, string departingFrom, string travelingTo, decimal price)
        {
            Id = id;
            DepartingFrom = departingFrom;
            TravelingTo = travelingTo;
            Price = price;
        }
    }
}
