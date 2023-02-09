using TodoItems.Models;
using TodoItems.Dtos;

namespace TodoItems.Repositories
{
    public interface IUserRepository
    {
        // 查詢所有 Users 資料
        public Task<IEnumerable<User>> GetAll();
        // 查詢指定 id 的單一 User 資料
        public Task<User> GetById(Guid id);
        // 新增 User 資料
        public Task Create(CreateUserDTO createUserDTO);
    }

}
