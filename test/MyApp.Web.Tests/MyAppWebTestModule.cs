using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyApp.Web.Startup;
namespace MyApp.Web.Tests
{
    [DependsOn(
        typeof(MyAppWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class MyAppWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyAppWebTestModule).GetAssembly());
        }
    }
}