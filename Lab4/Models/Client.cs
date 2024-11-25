using System.ComponentModel;

namespace Lab4.Models
{
    public class Client
    {
        public int Id { get; set; }
        [DisplayName("Фамилия")]
        public string Surname { get; set; } = null!;
        [DisplayName("Имя")]
        public string Name { get; set; } = null!;
        [DisplayName("Отчество")]
        public string MiddleName { get; set; } = null!;
        public ICollection<Car> Cars { get; set; } = [];
    }
}
