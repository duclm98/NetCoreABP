using Microsoft.EntityFrameworkCore;

namespace MyApp.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<MyAppDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for MyAppDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
