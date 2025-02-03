using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaMondo.Model;
using Microsoft.Extensions.Options;
using TiendaMongo.Data.Interfaces;

namespace TiendaMongo.Data.Services
{
    public class UserServices : IUserServices
    {
        private readonly IMongoCollection<UserModel> _users;
        private MongoConfiguration _configuration;
        private MongoClient _client;
        public UserServices(MongoClient mongoclient, IOptions<MongoConfiguration> mongoConfig) 
        {
            _client = mongoclient;
            _configuration = mongoConfig.Value ?? throw new ArgumentNullException(nameof(mongoConfig));

            var mongoDb = _client.GetDatabase(_configuration.DataBase);
            _users = mongoDb.GetCollection<UserModel>(_configuration.Collection);
        }

        public async Task<UserModel> CreateUser(UserModel user)
        {
            await _users.InsertOneAsync(user);
            return user;
        }
    }
}
