using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DBContexts;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController: ControllerBase
    {
        private static AppDBContext _context;
        public UsersController(AppDBContext context)
        {
            _context = context;
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getOne(int id){
            var user = await _context.Users.FindAsync(id);
            return Ok(user);
        }

        [HttpPost()]
        public async Task<IActionResult> Add(User user) {
            var result = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            Console.WriteLine("insert result",result);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, User user)
        {
           User user_tobe_updated = await _context.Users.FindAsync(id);
           Console.WriteLine(user_tobe_updated);
           return Ok(user_tobe_updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var user = await _context.Users.FindAsync(id) ?? throw new BadHttpRequestException("User not exist");
            var deleteRes = _context.Users.Remove(user);
            Console.WriteLine(deleteRes);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
