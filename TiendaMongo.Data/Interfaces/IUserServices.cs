using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TiendaMondo.Model;

namespace TiendaMongo.Data.Interfaces
{
    public interface IUserServices
    {
        public Task<UserModel> CreateUser(UserModel userModel);

        public Task<List<UserModel>> FindAll();

        public Task<UserModel> FindByEmail(string email);

        public Task DeleteByEmail(string email);
    }
}
