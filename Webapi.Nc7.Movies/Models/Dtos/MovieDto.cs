using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webapi.Nc7.Movies.Models.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }
        public string ImagePath { get; set; }
        [Required(ErrorMessage = "La descripcion es obligatoria")]
        public string Description { get; set; }
        [Required(ErrorMessage = "La duracion es obligatoria")]
        public string Duration { get; set; }
        public ClassificationType Classification { get; set; }
        public DateTime CreationDate { get; set; }

        public int categoryId { get; set; }

        public enum ClassificationType
        {
            Seven,
            Thirteen,
            Sixteen,
            Eightteen
        }
    }
}
