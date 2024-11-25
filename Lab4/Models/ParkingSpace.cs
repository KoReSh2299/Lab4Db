namespace Lab4.Models
{
    public class ParkingSpace
    {
        public int Id { get; set; }
        public bool IsPenalty { get; set; }
        public int? CarId { get; set; }
        public Car? Car { get; set; }
    }
}
