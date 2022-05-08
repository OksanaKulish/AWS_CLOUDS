using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.API.Entities;

namespace User.API.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<Users>> GetUsers();
        Task<Users> GetUser(string id);
        Task<IEnumerable<Users>> GetUserByName(string name);
        Task CreateUser(Users user);
        Task<bool> UpdateUser(Users user);
        Task<bool> DeleteUser(string id);
    }
}
