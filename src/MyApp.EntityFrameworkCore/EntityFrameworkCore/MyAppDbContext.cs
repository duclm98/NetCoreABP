using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyApp.Users;

namespace MyApp.EntityFrameworkCore
{
    public class MyAppDbContext : AbpDbContext
    {
        public DbSet<User> Users { get; set; }

        public MyAppDbContext(DbContextOptions<MyAppDbContext> options)
            : base(options)
        {

        }
    }
}
