using System;
using System.Threading.Tasks;
using Abp.TestBase;
using MyApp.EntityFrameworkCore;
using MyApp.Tests.TestDatas;

namespace MyApp.Tests
{
    public class MyAppTestBase : AbpIntegratedTestBase<MyAppTestModule>
    {
        public MyAppTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<MyAppDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<MyAppDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<MyAppDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<MyAppDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<MyAppDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<MyAppDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<MyAppDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<MyAppDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
