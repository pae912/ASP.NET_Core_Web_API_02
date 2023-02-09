using Dapper;
using System.Data;
using TodoItems.Dtos;
using TodoItems.Models;
using Microsoft.Data.SqlClient;

namespace TodoItems.Repositories
{
    public class TodoRepository : ITodoRepository

    {
        private readonly string _connectString = DBUtil.ConnectionString();
        public async Task Create(CreateTodoDTO createTodoDTO)
        {
            string sqlQuery = "INSERT into Todos (UserId, Title, Description, Id,Status) values(@UserId, @Title, @Description, @Id, @Status)";
            var parameters = new DynamicParameters();
            parameters.Add("Title", createTodoDTO.Title, DbType.String);
            parameters.Add("UserId", createTodoDTO.UserId, DbType.Guid);
            parameters.Add("Description", createTodoDTO.Description, DbType.String);
            parameters.Add("Status", TodoStatus.Todo, DbType.String);
            parameters.Add("Id", Guid.NewGuid(), DbType.Guid);
            using (var connection = new SqlConnection(_connectString))
            {
                var r = await connection.ExecuteAsync(sqlQuery, parameters);
                Console.Write(r);
            }
        }
        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            string sqlQuery = "SELECT * FROM Todos";
            using (var connection = new SqlConnection(_connectString))
            {
                var todos = await connection.QueryAsync<TodoItem>(sqlQuery);
                return todos.ToList();
            }
        }
        public async Task<TodoItem> GetById(Guid id)
        {
            string sqlQuery = "SELECT * FROM Todos WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectString))
            {
                var todo = await connection.QuerySingleAsync<TodoItem>(sqlQuery, new { Id = id });
                return todo;
            }
        }
        public async Task Update(UpdateTodoDTO updateTodoDTO, Guid id)
        {
            string sqlQuery = "UPDATE Todos SET Title = @Title, Status = @Status,Description = @Description WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Title", updateTodoDTO.Title, DbType.String);
            parameters.Add("Status", updateTodoDTO.Status, DbType.String);
            parameters.Add("Description", updateTodoDTO.Description, DbType.String);
            parameters.Add("Id", id, DbType.Guid);

            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }
        public async Task Delete(Guid id)
        {
            string query = "DELETE FROM Todos WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }
        public async Task<IEnumerable<TodoItem>> GetByUser(Guid id)
        {
            string sqlQuery = "SELECT * FROM Todos WHERE UserId = @UserId";
            using (var connection = new SqlConnection(_connectString))
            {
                IEnumerable<TodoItem> todos = await connection.QueryAsync<TodoItem>(sqlQuery,
                new { UserId = id });
                return todos;
            }
        }


    }
}
