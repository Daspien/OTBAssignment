namespace OTBAssignment.Model.Hotels
{
    public class HotelSearchOptions
    {
        public Airport Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public short Duration { get; set; }

        public HotelSearchOptions(Airport destination, DateTime departure, short duration)
        {
            Destination = destination;
            DepartureDate = departure;
            Duration = duration;
        }
    }
}
