using System.ComponentModel.DataAnnotations;

namespace Webapi.Nc7.Movies.Models.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "El máximo de cáracteres es 100")]
        public string Name { get; set; }
        
    }
}
