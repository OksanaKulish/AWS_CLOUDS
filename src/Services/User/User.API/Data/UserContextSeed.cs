using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using User.API.Entities;

namespace User.API.Data
{
    public class UserContextSeed
    {
        public static void SeedData(IMongoCollection<Users> userCollection)
        {
            bool existUser = userCollection.Find(p => true).Any();
            if (!existUser)
            {
                userCollection.InsertManyAsync(GetPreconfiguredUsers());
            }
        }
        private static IEnumerable<Users> GetPreconfiguredUsers()
        {
            return new List<Users>()
            {
                new Users(){
                    Id = "OKKU-A",
                    Name = "test_name",
                    CompanyName = "test_company_name",
                    ImageFile = "test_image_file"
                },
                new Users(){
                    Id = "OKKU-B",
                    Name = "test_name_1",
                    CompanyName = "test_company_name_1",
                    ImageFile = "test_image_file_1"
                },
                new Users(){
                    Id = "OKKU-C",
                    Name = "test_name_2",
                    CompanyName = "test_company_name_2",
                    ImageFile = "test_image_file_2"
                }
            };
        }

    }
}
