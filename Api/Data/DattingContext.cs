using Api.Entity;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class DattingContext:DbContext
    {
        public DattingContext(DbContextOptions<DattingContext> options) : base(options)
        {

        }
        public DbSet<AppUser> Users { get; set; }
    }
}
