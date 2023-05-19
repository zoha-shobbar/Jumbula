using Jumbula.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jumbula.Infrastructure.Data;
public class DataInitializer
{
    public static void Initialize(DataContext context)
    {
        context.Database.Migrate();
        SeedData(context);
    }

    public static void SeedData(DataContext context)
    {
        bool isInsuranceExist = context.Set<Insurance>().Any();
        if (!isInsuranceExist)
        {
            Insurance insurance = new()
            {
                Id = Guid.Parse("4c730f1e-d036-435f-9ecb-3a4fbcbe1111"),
                CompanyName = "Insurance 1",
                CompanyPhone = "0935935935",
                ExternalId = Guid.NewGuid(),
                PolicyNumber = "1",
            };

            context.Set<Insurance>().Add(insurance);
            context.SaveChanges();
        }
    }
}
