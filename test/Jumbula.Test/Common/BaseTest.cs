using Jumbula.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Jumbula.Test.Common;
public class BaseTest
{
    protected readonly HttpClient TestClient;
    protected BaseTest()
    {
        var appFactory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.RemoveAll(typeof(DataContext));
                    services.AddDbContext<DataContext>(options =>
                    {
                        options.UseInMemoryDatabase("Tests.Jumbula");
                    });
                });
            });
        TestClient = appFactory.CreateClient();
    }
}
