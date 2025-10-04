namespace OTBAssignment.Model.Hotels
{
    public class HotelSearchOptions
    {
        public Airport Destination { get; }
        public DateTime DepartureDate { get; }
        public short Duration { get; }

        public HotelSearchOptions(Airport destination, DateTime departure, short duration)
        {
            Destination = destination;
            DepartureDate = departure;
            Duration = duration;
        }
    }
}
