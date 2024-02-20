using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackTask.Dto
{
    public class UpdateCustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
