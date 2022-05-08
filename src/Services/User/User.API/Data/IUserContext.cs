
using MongoDB.Driver;
using User.API.Entities;

namespace User.API.Data
{
    public interface IUserContext
    {
        public IMongoCollection<Users> Users { get; }
    }
}
