using Microsoft.EntityFrameworkCore;
using Movie.Models;

namespace Movie.Data
{
    public class ApiContext: DbContext
    {
        public DbSet<MovieApp>? Movies { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
    }
}
