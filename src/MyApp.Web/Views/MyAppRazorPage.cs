using Abp.AspNetCore.Mvc.Views;

namespace MyApp.Web.Views
{
    public abstract class MyAppRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected MyAppRazorPage()
        {
            LocalizationSourceName = MyAppConsts.LocalizationSourceName;
        }
    }
}
