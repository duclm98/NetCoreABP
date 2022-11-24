using MyApp.EntityFrameworkCore;

namespace MyApp.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly MyAppDbContext _context;

        public TestDataBuilder(MyAppDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}