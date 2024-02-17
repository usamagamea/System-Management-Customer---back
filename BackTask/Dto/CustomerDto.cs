using BackTask.Database.Entities;

namespace BackTask.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public CountryDto Country { get; set; }
        public CityDto City { get; set; }
    }
}
