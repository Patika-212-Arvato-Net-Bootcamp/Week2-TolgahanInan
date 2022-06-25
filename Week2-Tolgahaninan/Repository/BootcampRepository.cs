
using System.Xml.Linq;
using Week2_Tolgahaninan.Data;
using Week2_Tolgahaninan.Models;
using Week2_Tolgahaninan.Repository.IRepository;

namespace Week2_Tolgahaninan.Repository
    
{
    public class BootcampRepository : IBootcampRepository
    {
        private readonly ApplicationDbContext _db;

        public BootcampRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public Bootcamp GetBootcamp(int bootcampId)
        {
            return _db.bootcamps.FirstOrDefault(data => data.Id == bootcampId);
        }


        public bool CreateBootcamp(Bootcamp bootcamp)
        {
            _db.bootcamps.Add(bootcamp);
            return Save();
        }

        public bool DeleteBootcamp(Bootcamp bootcamp)
        {
            _db.bootcamps.Remove(bootcamp);
            return Save();
        }
        public bool UpdateBootcamp(Bootcamp bootcamp)
        {
            _db.bootcamps.Update(bootcamp);
            return Save();
        }
        public bool DeleteUserFromBootcamp(Bootcamp bootcamp, User user)
        {
            throw new NotImplementedException();
        }

        public bool ApproveUser(Bootcamp bootcamp, User user)
        {
            throw new NotImplementedException();
        }

        public bool BootcampExists(string bootcampName)
        {
            bool value = _db.bootcamps.Any(data => data.Name.ToLower().Trim() == bootcampName.ToLower().Trim());
            return value;
        }

        public bool BootcampExists(int bootcampId)
        {
            return _db.bootcamps.Any(data => data.Id == bootcampId);
        }

        public bool Save()
        {
           return _db.SaveChanges() >=0 ?true : false;
        }

       
    }
}
