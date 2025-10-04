namespace OTBAssignment.Model.Flights
{
    public  class FlightSearchOptions
    {
        public Airport From { get; set; }
        public Airport To { get; set; }
        public DateTime DepartureDate { get; set; }

        public FlightSearchOptions(Airport from, Airport to, DateTime departure)
        {
            From = from;
            To = to;
            DepartureDate = departure;
        }
    }
}
