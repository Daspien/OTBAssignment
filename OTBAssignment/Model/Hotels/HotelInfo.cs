namespace OTBAssignment.Model.Hotels
{
    public class HotelInfo
    {
        public int Id { get; }
        public string Name { get; }
        public decimal PricePerNight { get; }
        public decimal TotalPrice { get; }
        public HotelInfo(int id, string name, decimal price, decimal totalPrice)
        {
            Id = id;
            Name = name;
            PricePerNight = price;
            TotalPrice = totalPrice;
        }
    }
}
