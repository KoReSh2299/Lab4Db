using System.ComponentModel;

namespace Lab4.Models
{
    public class ParkingSpace
    {
        [DisplayName("Номер места")]
        public int Id { get; set; }
        [DisplayName("Вид стоянки")]
        public bool IsPenalty { get; set; }
        public int? CarId { get; set; }
        [DisplayName("Автомобиль")]
        public Car? Car { get; set; }
    }
}
