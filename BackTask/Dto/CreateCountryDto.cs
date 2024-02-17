using System.ComponentModel.DataAnnotations;

namespace BackTask.Dto
{
    public class CreateCountryDto
    {
        [Required]
        public string Name { get; set; }
    }
}
