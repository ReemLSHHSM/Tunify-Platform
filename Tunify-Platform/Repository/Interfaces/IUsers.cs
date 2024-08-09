using Tunify_Platform.Models;

namespace Tunify_Platform.Repository.Interfaces
{
    public interface IUsers
    {


        Task<List<Users>> getAllUsers();

        Task<Users> getUser(int id);

        Task<Users> AddUser(Users user);

        Task<Users> UpdateUser(Users user,int id);

        Task<Users> DeleteUser(int id);





    }
}
