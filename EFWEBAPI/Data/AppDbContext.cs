using Microsoft.EntityFrameworkCore;

namespace EFWEBAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {

        }

    }
}
