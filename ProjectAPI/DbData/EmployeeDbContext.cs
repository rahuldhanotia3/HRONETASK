using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;

namespace ProjectAPI.DbData
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
