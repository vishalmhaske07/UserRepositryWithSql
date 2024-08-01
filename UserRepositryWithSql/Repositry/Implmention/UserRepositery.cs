using UserRepositryWithSql.Data;
using UserRepositryWithSql.Models;
using UserRepositryWithSql.Repositry.InterFace;

namespace UserRepositryWithSql.Repositry.Implmention
{
    public class UserRepositery : IUser
    {
        private readonly UserDbContext _userDb;

        public UserRepositery(UserDbContext usercontext)
        {
            _userDb = usercontext;
        }

        public int CreateUser(User user)
        {
            int result = -1;
            if (result==null)
            {
                result = 0;
            }
            else
            {
                _userDb.Users.Add(user);
                _userDb.SaveChanges();
                result=user.Id;
            }
            return result;
        }

        public int DeleteUser(int id)
        {
            _userDb.Users.Remove(GetUserById(id));
            return _userDb.SaveChanges();
        }

        public void Dispose()
        {
           _userDb.Dispose();
        }

        public IEnumerable<User> GetAllUsers()
        {
            var AllUser = _userDb.Users.ToList();
                return AllUser;
        }

        public User GetUserById(int id)
        {
           var userID=_userDb.Users.Where(x=>x.Id==id).FirstOrDefault();
            return userID;
        }

        public int UpdateUser(User user)
        {
               var UserID=_userDb.Users.Where(x=>x.Id==user.Id).FirstOrDefault();
           if (UserID != null)
            {
                UserID.Id = user.Id;
                UserID.Name = user.Name;
                UserID.Email = user.Email;
                UserID.Position = user.Position;

                _userDb.SaveChanges();
                return UserID.Id;
            }
           return  -1;
        }
    }
}
