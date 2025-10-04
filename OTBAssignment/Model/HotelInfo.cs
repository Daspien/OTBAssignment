namespace OTBAssignment.Model
{
    public class HotelInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public HotelInfo(int id, string name, string price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
