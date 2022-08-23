using Microsoft.EntityFrameworkCore;
using Talent.Backend.DataAccessEF;

namespace Talent.Backend.UnitTest
{
    public class TestBase
    {
        public EFContext BuildContext()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
                //.UseInMemoryDatabase("backendApi")
                .UseSqlServer("Server=LAPTOP-NOTLMK8N;Database=backendApi;Integrated Security=True")
                .EnableSensitiveDataLogging()
                .Options;

            return new EFContext(options);
        }
    }
}
