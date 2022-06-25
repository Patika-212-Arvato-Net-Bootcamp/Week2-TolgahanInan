using Week2_Tolgahaninan.Models;

namespace Week2_Tolgahaninan.Repository.IRepository
{
    public interface IUserRepository
    {
        ICollection<Bootcamp> GetBootcamps();
        Bootcamp GetBootcamp(int bootcampId);

        bool UserExists(int userId);

        bool JoinBootcamp(int bootcampId , int userId);
        bool BringBootcamps(Bootcamp bootcamp, User user);

        bool Save();
    }
}
