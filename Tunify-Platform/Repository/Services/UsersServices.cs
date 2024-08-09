using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repository.Interfaces;

namespace Tunify_Platform.Repository.Services
{
    public class UsersServices: IUsers                                          
    {

        public readonly TunifyDBContext _context;

        public UsersServices(TunifyDBContext tunifyDBContext)
        {
            _context= tunifyDBContext;
        }

        public async Task<Users> AddUser(Users user)
        {
            _context.Users.Add(user);
           await _context.SaveChangesAsync();
            return user;
        }

        public async Task<Users> DeleteUser(int id)
        {
            var data =  await getUser(id);
            _context.Users.Remove(data);
            _context.SaveChanges();
            return null;

        }

        public async Task<List<Users>> getAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Users> getUser(int id)
        {
          
            return await _context.Users.FindAsync(id);
        }

        public async Task<Users> UpdateUser(Users user, int id)
        {
            var data=await getUser(id);//await is a must 
            data = user;
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
