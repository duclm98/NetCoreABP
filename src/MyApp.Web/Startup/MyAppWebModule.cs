using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyApp.Configuration;
using MyApp.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;

namespace MyApp.Web.Startup
{
    [DependsOn(
        typeof(MyAppApplicationModule), 
        typeof(MyAppEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class MyAppWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public MyAppWebModule(IWebHostEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(MyAppConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<MyAppNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(MyAppApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyAppWebModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MyAppWebModule).Assembly);
        }
    }
}
