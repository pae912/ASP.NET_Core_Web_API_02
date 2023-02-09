using Microsoft.AspNetCore.Mvc;
using TodoItems.Dtos;
using TodoItems.Repositories;


namespace TodoItems.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserRepository _userRepository;
        public UsersController(ILogger<UsersController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var Data = await _userRepository.GetAll();
                return Ok(new
                {
                    Success = true,
                    Message = "all users returned.",
                    Data
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetById(Guid userId)
        {
            try
            {
                var Data = await _userRepository.GetById(userId);
                return Ok(new
                {
                    Success = true,
                    Message = "User fetched.",
                    Data
                });
            }

            catch (Exception ex) //8
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDTO createUserDTO)
        {
            try
            {
                await _userRepository.Create(createUserDTO);
                return Ok(new
                {
                    Success = true,
                    Message = "Todo item created."
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }


    }
}
