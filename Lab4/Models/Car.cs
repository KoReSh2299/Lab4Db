using System.ComponentModel;

namespace Lab4.Models
{
    public class Car
    {
        public int Id { get; set; }
        [DisplayName("Брэнд")]
        public string Brand { get; set; } = null!;
        [DisplayName("Номер автомобиля")]
        public string Number { get; set; } = null!;
        public int ClientId { get; set; }
        [DisplayName("Клиент")]
        public Client Client { get; set; } = null!;
        public ICollection<ParkingSpace> ParkingSpaces { get; set; } = [];
    }
}
