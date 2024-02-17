using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackTask.Database.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        [ForeignKey("CityId")]  
        public City City { get; set; }

        public int CountryId { get; set; }
        [ForeignKey("CountryId")]  
        public Country Country { get; set; }
    }
}
