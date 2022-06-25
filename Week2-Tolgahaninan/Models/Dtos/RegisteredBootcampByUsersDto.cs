namespace Week2_Tolgahaninan.Models.Dtos
{
    public class RegisteredBootcampByUsersDto
    {
        public int id { get; set; }
        public int bootcampId { get; set; }
        public string userId { get; set; }

        public string status { get; set; }
    }
}
