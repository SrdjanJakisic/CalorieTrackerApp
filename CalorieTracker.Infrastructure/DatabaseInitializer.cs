using CalorieTracker.Infrastructure.Data;
using CalorieTracker.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Infrastructure
{
    public class DatabaseInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await context.Database.MigrateAsync();

            string[] roles = { "Admin", "User" };
            foreach (var role in roles)
            {
                if(!await roleManager.RoleExistsAsync(role)) await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();

            var adminEmail = config["AdminSeed:Email"];
            var adminPassword = config["AdminSeed:Password"];

            if (await userManager.FindByEmailAsync(adminEmail!) == null)
            {
                var admin = new ApplicationUser
                {
                    Email = adminEmail,
                    UserName = adminEmail
                };

                await userManager.CreateAsync(admin, adminPassword!);
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
