using System.ComponentModel.DataAnnotations.Schema;

namespace Webapi.Nc7.Movies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public ClassificationType Classification { get; set; }
        public DateTime CreationDate { get; set; }

        [ForeignKey("CategoryId")]
        public int categoryId { get; set; }
        public Category Category { get; set; }

        public enum ClassificationType { 
            Seven,
            Thirteen,
            Sixteen,
            Eightteen
        }

    }
}
