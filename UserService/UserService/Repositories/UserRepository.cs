using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using UserService.Models;

namespace UserService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _dbConnectionString = Environment.GetEnvironmentVariable("USER_SERVICE_DB_CONN_STRING");

        public async Task<User> GetUserByEmail(string email)
        {
            string sql = @"SELECT * FROM users where email=@Email";

            using (var connection = new NpgsqlConnection(_dbConnectionString))
            {
                var user = await connection.QueryAsync<User>(sql, new
                {
                    email
                });
                return user.FirstOrDefault();
            }
        }

        public async Task<User> SaveUser(User user)
        {
            string insertQuery = @"insert into users (email, id, password, salt, role, name, lastname,createdAt)
                                values (@Email, @Id,@Password,@salt,@role,@name,@lastname,@createdAt);";

            using (IDbConnection db = new NpgsqlConnection(this._dbConnectionString))
            {
                var affectedRows = await db.ExecuteAsync(insertQuery, user);
                if (affectedRows == 1)
                {
                    return user;
                }
            }

            return null;
        }
    }
}