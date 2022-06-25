using System.ComponentModel.DataAnnotations;

namespace Week2_Tolgahaninan.Models.Dtos
{
    public class BootcampDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
   
        public int UserCount { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
