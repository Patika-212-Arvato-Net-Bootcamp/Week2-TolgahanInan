using System.ComponentModel.DataAnnotations;

namespace Week2_Tolgahaninan.Models
{
    public class Bootcamp
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int UserCount { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
