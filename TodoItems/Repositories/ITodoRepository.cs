using TodoItems.Models;
using TodoItems.Dtos;

namespace TodoItems.Repositories
{
    public interface ITodoRepository
    {
        // 新增 Todo 資料
        public Task Create(CreateTodoDTO createTodoDTO);
        // 查詢所有 Todos 資料
        public Task<IEnumerable<TodoItem>> GetAll();
        // 查詢指定 id 的單一 Todo 資料
        public Task<TodoItem> GetById(Guid id);
        // 修改指定 id 的 Todo 資料
        public Task Update(UpdateTodoDTO projectDTO, Guid id);
        // 刪除指定 id 的 Todo 資料
        public Task Delete(Guid id);
        // 查詢指定 user 的 id 的所有 Todos 資料
        public Task<IEnumerable<TodoItem>> GetByUser(Guid id);
    }

}
