using Microsoft.EntityFrameworkCore;
using ministers_of_sweden.api.Entities;

namespace ministers_of_sweden.api.Data
{
    public class MinistersOfSwedenContext : DbContext
    {

        public DbSet<Minister> Ministers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<AcademicField> AcademicFields {get; set;}
        public MinistersOfSwedenContext(DbContextOptions options) : base(options){ }

    }
}