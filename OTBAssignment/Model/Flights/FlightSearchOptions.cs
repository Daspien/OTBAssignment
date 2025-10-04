namespace OTBAssignment.Model.Flights
{
    public  class FlightSearchOptions
    {
        public Airport From { get; }
        public Airport To { get; }
        public DateTime DepartureDate { get; }

        public FlightSearchOptions(Airport from, Airport to, DateTime departure)
        {
            From = from;
            To = to;
            DepartureDate = departure;
        }
    }
}
