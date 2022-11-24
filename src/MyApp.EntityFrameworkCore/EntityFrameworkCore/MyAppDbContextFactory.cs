using MyApp.Configuration;
using MyApp.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MyApp.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class MyAppDbContextFactory : IDesignTimeDbContextFactory<MyAppDbContext>
    {
        public MyAppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyAppDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(MyAppConsts.ConnectionStringName)
            );

            return new MyAppDbContext(builder.Options);
        }
    }
}