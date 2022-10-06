using Microsoft.EntityFrameworkCore;
using myprogramApi.Models;

namespace myprogramApi.Data
{
    public class MyProgramDbContext : DbContext
    {
        public MyProgramDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
