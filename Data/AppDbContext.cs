using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Ajax_crud.Models;

namespace Ajax_crud.Data
{
    public class AppDbContext
    {
        public class AppDbContexts : DbContext
        {
            public AppDbContexts(DbContextOptions<AppDbContexts> options) : base(options)
            { }

            public DbSet<StudentModel> Students { get; set; }
            public DbSet<CountryListingModel> Country { get; set; }
        }
    }
}
