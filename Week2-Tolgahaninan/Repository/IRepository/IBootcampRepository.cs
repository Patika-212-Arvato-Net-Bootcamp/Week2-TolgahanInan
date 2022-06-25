using Week2_Tolgahaninan.Models;
namespace Week2_Tolgahaninan.Repository.IRepository
{
    public interface IBootcampRepository
    {
       
        bool CreateBootcamp(Bootcamp bootcamp);
        bool UpdateBootcamp(Bootcamp bootcamp);
        bool DeleteBootcamp(Bootcamp bootcamp);

        Bootcamp GetBootcamp(int bootcampId);

        bool BootcampExists(string bootcampName);
        bool BootcampExists(int bootcampId);

        bool ApproveUser(Bootcamp bootcamp , User user);
        bool DeleteUserFromBootcamp (Bootcamp bootcamp , User user);

        bool Save();
    }
}
