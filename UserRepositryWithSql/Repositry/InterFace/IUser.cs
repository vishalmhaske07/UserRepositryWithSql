using UserRepositryWithSql.Models;

namespace UserRepositryWithSql.Repositry.InterFace
{
    public interface IUser :IDisposable
    {
        IEnumerable<User>GetAllUsers();
        User GetUserById(int id);
        int CreateUser(User user);
        int UpdateUser(User user);
        int DeleteUser(int id);
    }
}
