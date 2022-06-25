using Week2_Tolgahaninan.Data;
using Week2_Tolgahaninan.Models;

namespace Week2_Tolgahaninan.Repository.IRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

   
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Bootcamp GetBootcamp(int bootcampId)
        {
            return _db.bootcamps.FirstOrDefault(data => data.Id == bootcampId);
        }

        public ICollection<Bootcamp> GetBootcamps()
        {
            return _db.bootcamps.OrderBy(data => data.Name).ToList();
        }
    


        public bool BringBootcamps(Bootcamp bootcamp, User user)
        {
            throw new NotImplementedException();
        }

      
        public bool JoinBootcamp(int bootcampId , int userId)
        {
            var model = new RegisteredBootcampsByUsers { bootcampId=bootcampId , userId=userId};
            _db.registeredBootcampsByUsers.Add(model);
            return Save();
        }
        public bool UserExists(int userId)
        {
            return _db.users.Any(data => data.Id == userId);
        }



        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

    }
}
