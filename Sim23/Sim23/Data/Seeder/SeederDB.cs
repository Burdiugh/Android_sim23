using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Sim23.Data.Entities;

namespace Sim23.Data.Seeder
{
    public static class SeederDB
    {
        
        public static void SeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();
                context.Database.Migrate();
                if (!context.Categories.Any())
                {
                    var notebook = new CategoryEntity
                    {
                        Name = "Laptop",
                        DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                        Priority = 1,
                        Image = "1.jpg",
                        IsDeleted = false,
                        Description = "For confident users."
                    };
                    context.Categories.Add(notebook);
                    context.SaveChanges();
                    var clothes = new CategoryEntity
                    {
                        Name = "Clothes",
                        DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                        Priority = 2,
                        Image = "2.jpg",
                        IsDeleted = false,
                        Description = "Classic clothes for everyones taste."
                    };
                    context.Categories.Add(clothes);
                    context.SaveChanges();
                }
            }
        }
    }
}
