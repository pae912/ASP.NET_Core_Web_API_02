using Dapper;
using System.Data;
using TodoItems.Dtos;
using TodoItems.Models;
using Microsoft.Data.SqlClient;

namespace TodoItems.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectString = DBUtil.ConnectionString();
        public async Task<IEnumerable<User>> GetAll()
        {

            string sqlQuery = "SELECT * FROM Users";
            using (var connection = new SqlConnection(_connectString))
            {
                var users = await connection.QueryAsync<User>(sqlQuery);
                return users.ToList();
            }
        }
        public async Task<User> GetById(Guid id)
        {
            string sqlQuery = "SELECT * FROM Users WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectString))
            {
                return await connection.QuerySingleAsync<User>(sqlQuery, new { Id = id });
            }
        }
        public async Task Create(CreateUserDTO createUserDTO)
        {
            string sqlQuery = "INSERT into Users (Id, Firstname, Lastname, Email) values(@Id, @Firstname, @Lastname, @Email)";
            var parameters = new DynamicParameters();
            parameters.Add("Id", Guid.NewGuid(), DbType.Guid);
            parameters.Add("Firstname", createUserDTO.Firstname, DbType.String);
            parameters.Add("Lastname", createUserDTO.Lastname, DbType.String);
            parameters.Add("Email", createUserDTO.Email, DbType.String);
            using (var connection = new SqlConnection(_connectString))
            {
                var r = await connection.ExecuteAsync(sqlQuery, parameters);
                Console.Write(r);
            }
        }


    }
}
