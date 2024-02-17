using BackTask.Database.Entities;

namespace BackTask.Dto
{
    public class CreateCustomerDto
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
     
    }
}
