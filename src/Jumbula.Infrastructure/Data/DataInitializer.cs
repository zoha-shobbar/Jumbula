using Microsoft.EntityFrameworkCore;

namespace Jumbula.Infrastructure.Data;
public class DataInitializer
{
    public static void Initialize(DataContext context)
    {
        context.Database.Migrate();
    }
}
