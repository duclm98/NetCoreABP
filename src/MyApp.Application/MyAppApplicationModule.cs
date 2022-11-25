using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AutoMapper;
using System;
using System.Linq;

namespace MyApp
{
    [DependsOn(
        typeof(MyAppCoreModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpAutoMapperModule))]
    public class MyAppApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(x =>
                    (x.FullName ?? "").Contains("MyApp.Application")
                ).ToList();

            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                //config.CreateMap<User, LoginDto>()
                //    .ForMember(u => u.UserId, options => options.MapFrom(input => input.Id));
                //config.AddProfile<UserMapping>();

                // Tự động initialize các profile mapping
                foreach (var assembly in assemblies)
                {
                    assembly.GetTypes()
                        .Where(x => x.IsSubclassOf(typeof(Profile)))
                        .Select(Activator.CreateInstance)
                        .OfType<Profile>()
                        .ToList()
                        .ForEach(x => config.AddProfile(x));
                }
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyAppApplicationModule).GetAssembly());
        }
    }
}