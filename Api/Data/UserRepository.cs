using Api.Dtos;
using Api.Entity;
using Api.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DattingContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DattingContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<MemeberDto> GetMemberAsync( string username)
        {
            return await _context.Users.Where(x => x.Username == username)
            .ProjectTo<MemeberDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<MemeberDto>> GetMembersAsync()
        {
            return await _context.Users
            .ProjectTo<MemeberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByNameAsync(string name)
        {
            return await _context.Users.Include(p=>p.Photos).SingleOrDefaultAsync(x => x.Username == name); 

        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            var users = await _context.Users.Include(p => p.Photos).ToListAsync();
            return users;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync ()> 0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
