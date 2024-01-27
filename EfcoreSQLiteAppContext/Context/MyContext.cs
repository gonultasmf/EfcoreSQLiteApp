using EfcoreSQLiteAppContext.Models;
using Microsoft.EntityFrameworkCore;

namespace EfcoreSQLiteAppContext.Context;

public class MyContext : DbContext
{
    public MyContext()
    {
        Database.Migrate();
    }

    public MyContext(DbContextOptions options) : base(options)
    {
        Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite();


    public DbSet<User> Users { get; set; }
}
