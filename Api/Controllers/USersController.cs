using Api.Data;
using Api.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class USersController : ControllerBase
    {
        private readonly DattingContext _context;

        public USersController(DattingContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<AppUser>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
        [HttpGet("{id}")]
        public async Task<AppUser> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }
    }
}
