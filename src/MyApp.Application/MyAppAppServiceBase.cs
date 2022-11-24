using Abp.Application.Services;

namespace MyApp
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class MyAppAppServiceBase : ApplicationService
    {
        protected MyAppAppServiceBase()
        {
            LocalizationSourceName = MyAppConsts.LocalizationSourceName;
        }
    }
}