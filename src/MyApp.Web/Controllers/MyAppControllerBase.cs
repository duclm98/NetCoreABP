using Abp.AspNetCore.Mvc.Controllers;

namespace MyApp.Web.Controllers
{
    public abstract class MyAppControllerBase : AbpController
    {
        protected MyAppControllerBase()
        {
            LocalizationSourceName = MyAppConsts.LocalizationSourceName;
        }
    }
}