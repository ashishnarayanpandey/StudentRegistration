using Microsoft.EntityFrameworkCore;

namespace StudentRegistration.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<TblCountry> tblCountries { get; set; }
        public DbSet<TblState> tblStates { get; set; }
        public DbSet<TblCity> tblCities { get; set; }
    }
}
