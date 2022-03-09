using Microsoft.EntityFrameworkCore;
using TryFastEndpointsApp.Entities;

namespace TryFastEndpointsApp.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
          : base(options)
        { }
        public DbSet<User> Users { get; set; }
    }
}