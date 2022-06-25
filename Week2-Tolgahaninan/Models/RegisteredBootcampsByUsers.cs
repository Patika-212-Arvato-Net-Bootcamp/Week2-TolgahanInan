using System.ComponentModel.DataAnnotations;

namespace Week2_Tolgahaninan.Models
{
    public class RegisteredBootcampsByUsers
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int bootcampId { get; set; }
        [Required]
        public int userId { get; set; }

        [Required]
        public string status { get; set; }
    }
}
