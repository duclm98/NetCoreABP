using System.Threading.Tasks;
using MyApp.Web.Controllers;
using Shouldly;
using Xunit;

namespace MyApp.Web.Tests.Controllers
{
    public class HomeController_Tests: MyAppWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
