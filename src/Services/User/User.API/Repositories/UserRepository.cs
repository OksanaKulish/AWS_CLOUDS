using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.API.Data;
using User.API.Entities;

namespace User.API.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly IUserContext _context;

        public UserRepository(IUserContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateUser(Users user)
        {
            await _context.Users.InsertOneAsync(user);
        }

        public async Task<bool> DeleteUser(string id)
        {
            FilterDefinition<Users> filter =
                Builders<Users>.Filter.Eq(u => u.Id, id);
            DeleteResult deleteResult = await _context
                .Users
                .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<Users> GetUser(string id)
        {
            return await _context
                 .Users
                 .Find(u => u.Id == id)
                 .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Users>> GetUserByName(string name)
        {
            FilterDefinition<Users> filter =
                Builders<Users>.Filter.Eq(u => u.Name, name);

            return await _context
                .Users
                .Find(filter)
                .ToListAsync();
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
            return await _context
                .Users
                .Find(u => true)
                .ToListAsync();
        }

        public async Task<bool> UpdateUser(Users user)
        {
            var updateResult = await _context
                .Users
                .ReplaceOneAsync(filter: g =>
                g.Id == user.Id, replacement: user);

            return updateResult.IsAcknowledged
                && updateResult.ModifiedCount > 0;
        }
    }
}
