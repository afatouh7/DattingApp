using Api.Dtos;
using Api.Entity;

namespace Api.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByNameAsync(string name);
        Task<IEnumerable<MemeberDto>> GetMembersAsync();
        Task<MemeberDto> GetMemberAsync(string username);
    }
}
