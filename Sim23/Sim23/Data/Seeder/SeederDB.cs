using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Sim23.Constants;
using Sim23.Data.Entities;
using Sim23.Data.Entities.Identity;

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
                // seed items
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
                // seed users
                var userManager = scope.ServiceProvider
               .GetRequiredService<UserManager<UserEntity>>();

                var roleManager = scope.ServiceProvider
                    .GetRequiredService<RoleManager<RoleEntity>>();
                if (!context.Roles.Any())
                {
                    RoleEntity admin = new RoleEntity
                    {
                        Name = Roles.Admin,
                    };
                    RoleEntity user = new RoleEntity
                    {
                        Name = Roles.User,
                    };
                    var result = roleManager.CreateAsync(admin).Result;
                    result = roleManager.CreateAsync(user).Result;
                }

                if (!context.Users.Any())
                {
                    UserEntity user = new UserEntity
                    {
                        FirstName = "Mykola",
                        LastName = "Burdiugh",
                        Email = "burdadmin@gmail.com",
                        UserName = "burdiugh",
                    };
                    var result = userManager.CreateAsync(user, "123456")
                        .Result;
                    if (result.Succeeded)
                    {
                        result = userManager
                            .AddToRoleAsync(user, Roles.Admin)
                            .Result;
                    }
                }

            }
        }
    }
}
