using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace MyApp.EntityFrameworkCore
{
    [DependsOn(
        typeof(MyAppCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class MyAppEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyAppEntityFrameworkCoreModule).GetAssembly());
        }
    }
}