using System.ComponentModel.DataAnnotations;

namespace Webapi.Nc7.Movies.Models.Dtos
{
    public class NewCategoryDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(60, ErrorMessage = "El máximo de cáracteres es 100")]
        public string Name { get; set; }
    }
}
